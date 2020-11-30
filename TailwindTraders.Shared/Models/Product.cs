using System;

namespace TailwindTraders.Shared.Models
{
    public class Product
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public int StockUnits { get; set; }
        public Brand Brand { get; set; }
    }

    
}
