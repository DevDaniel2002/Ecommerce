using System;
using System.Collections.Generic;

#nullable disable

namespace BackEndEcommerce.Models
{
    public partial class Product
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public decimal? Price { get; set; }
        public int? Quantity { get; set; }
        public string Description { get; set; }
        public bool? State { get; set; }
        public byte[] Image { get; set; }
    }
}
