using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductManagement.DbContexts
{
    public class ProductDetails
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public int Price { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Description { get; set; }
        public double? Discount { get; set; }
        public int Stock { get; set; }
        public int Click { get; set; }
        public int CategoryId { get; set; }
        public string UserId { get; set; }
    }
}
