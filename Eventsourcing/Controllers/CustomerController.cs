using System;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Eventsourcing.Messages.Commands;
using Eventsourcing.Messages.Events;
using Eventsourcing.Models;
using Eventsourcing.Projectors;
using Eventsourcing.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Eventsourcing.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly IEventRepository _eventRepository;
        private readonly ICustomerProjector _customerProjector;
        private readonly IMapper _mapper;

        public CustomerController(IEventRepository eventRepository, ICustomerProjector customerProjector, IMapper mapper)
        {
            _eventRepository = eventRepository;
            _customerProjector = customerProjector;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> CreateCustomer(CreateCustomer command)
        {
            var customerCreated = _mapper.Map<CustomerCreated>(command);
            await _eventRepository.SaveEventAsync(customerCreated);

            return CreatedAtAction(nameof(CustomerController.Get), new { Id = command.CustomerId }, null);
        }

        [HttpGet("{Id}", Name = nameof(Get))]
        public async Task<ActionResult<Customer>> Get(Guid Id)
        {
            var events = await _eventRepository.GetEventsAsync(Id);

            if (!events.Any())
            {
                return NotFound();
            }

            var customer = _customerProjector.Project(events);
            return Ok(customer);
        }

    }
}
