using System;

namespace TailwindTradersBlazorApp.Models
{
    public class Product
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public int StockUnits { get; set; }
        public Brand Brand { get; set; }
    }

    public class Brand
    {
        public string Name { get; set; }
    }
}
