﻿namespace ECommerceAPI.Data.Models
{
    public class Address
    {
        public long Id { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string ZipCode { get; set; }
        public Customer Customer { get; set; }
    }
}
