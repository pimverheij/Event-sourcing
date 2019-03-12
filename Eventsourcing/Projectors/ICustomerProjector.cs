using Eventsourcing.Messages;
using Eventsourcing.Messages.Events;
using Eventsourcing.Models;
using System.Collections.Generic;

namespace Eventsourcing.Projectors
{
    public interface ICustomerProjector
    {
        Customer Project(IEnumerable<IEvent> events);
    }

    public class CustomerProjector : ICustomerProjector
    {
        public Customer Project(IEnumerable<IEvent> events)
        {
            var customer = new Customer();

            foreach (var @event in events)
            {
                HandleEvent(customer, (dynamic)@event);
            }

            return customer;
        }

        private void HandleEvent(Customer customer, CustomerCreated @event)
        {
            customer.Id = @event.CustomerId;
            customer.Name = @event.Name;
        }

        private void HandleEvent(Customer customer, CartCreated @event)
        {
            customer.Cart = new Cart
            {
                Id = @event.CartId,
                Products = new List<Product>()
            };
        }

        private void HandleEvent(Customer customer, ProductAdded @event)
        {
            customer.Cart.Products.Add(new Product
            {
                Id = @event.ProductId,
                Name = @event.ProductName,
                Price = @event.ProductPrice
            });
        }
    }
}
