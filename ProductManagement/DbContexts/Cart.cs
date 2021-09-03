using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductManagement.DbContexts
{
    public class Cart
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public int ProductId { get; set; }
        public int OrderQuantity { get; set; }
        public bool BuyOrder { get; set; }
        public string DeliveryDestination { get; set; }
        public bool DeliveryStatus { get; set; }
    }
}
