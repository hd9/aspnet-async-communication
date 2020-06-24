using System;

namespace HildenCo.Core
{
    public class Product
    {
        public string Id => Guid.NewGuid().ToString();
        public string Slug { get; set; }
        public string Name { get; set; }
        public string Description { get; set; } = "todo";
        public decimal Price { get; set; }
        public string Currency { get; set; } = "USD";
        public DateTime CreatedOn => DateTime.UtcNow.AddYears(-3);
        public DateTime LastUpdate => DateTime.UtcNow.AddDays(-17);
    }
}
