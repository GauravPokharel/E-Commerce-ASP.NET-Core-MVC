using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProductManagement.Models
{
    public class CartModel
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public string UserName { get; set; }
        public int OrderQuantity { get; set; }
        public string DeliveryDestination { get; set; }
        public bool DeliveryStatus { get; set; }
        public ProductDetailsForCart ProductInfo { get; set; }
    }


    public class ProductDetailsForCart
    { 
        public int ProductId { get; set; }
        public int Price { get; set; }
        public string ProductName { get; set; }
        public double? Discount { get; set; }
        public int Stock { get; set; }
        public double DiscountedPrice { get; set; }
        
    }
}
