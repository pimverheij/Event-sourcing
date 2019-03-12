using System;
using System.Collections.Generic;

namespace Eventsourcing.Models
{
    public class Customer
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Cart Cart { get; set; }
    }

    public class Cart
    {
        public Guid Id { get; set; }
        public IList<Product> Products { get; set; }
    }

    public class Product
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
    }

    public class PaymentInformation
    {
        public Guid Id { get; set; }
        public string IBAN { get; set; }
    }
}
