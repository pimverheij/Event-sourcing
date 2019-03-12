using Eventsourcing.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Eventsourcing.Repositories
{
    public interface IProductService
    {
        Task<Product> GetProductAsync(Guid id);
    }

    public class InMemoryProductService : IProductService
    {
        private static List<Product> _products = new List<Product>()
        {
            new Product
            {
                Id = new Guid("60502b3a-fc05-49ae-a6cb-920635c327ea"),
                Name = "Clean Code",
                Price = 38.72M
            }
        };

        public Task<Product> GetProductAsync(Guid id)
        {
            return Task.FromResult(_products.Single(p => p.Id == id));
        }
    }
}
