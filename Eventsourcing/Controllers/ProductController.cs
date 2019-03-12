using System.Threading.Tasks;
using AutoMapper;
using Eventsourcing.Extensions;
using Eventsourcing.Messages.Commands;
using Eventsourcing.Messages.Events;
using Eventsourcing.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Eventsourcing.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly IEventRepository _eventRepository;
        private readonly IMapper _mapper;

        public ProductController(IMapper mapper, IEventRepository eventRepository, IProductService productService)
        {
            _mapper = mapper;
            _eventRepository = eventRepository;
            _productService = productService;
        }

        [HttpPost]
        public async Task<IActionResult> AddProduct(AddProduct command)
        {
            var events = await _eventRepository.GetEventsAsync(command.CorrolationId);

            if (!events.HasCartCreated())
            {
                var cartCreated = _mapper.Map<CartCreated>(command);
                await _eventRepository.SaveEventAsync(cartCreated);
            }

            var productAdded = _mapper.Map<ProductAdded>(command);
            var product = await _productService.GetProductAsync(command.ProductId);
            productAdded = _mapper.Map(product, productAdded);

            await _eventRepository.SaveEventAsync(productAdded);

            return CreatedAtAction(nameof(CustomerController.Get), new { Controller = "Customer", Id = command.CustomerId }, null);
        }
    }
}