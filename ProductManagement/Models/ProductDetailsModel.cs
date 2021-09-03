using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProductManagement.Models
{
    public class ProductDetailsModel
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public int Price { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Description { get; set; }
        public double? Discount { get; set; }
        public double DiscountedPrice { get; set; }
        public int Click { get; set; }
        public int Stock { get; set; }
        public int CategoryId { get; set; }
        public string UserId { get; set; }
        public ProductCategoryDropdown Category { get; set; }
        public CreatedBy CreatedBy { get; set; }
        public List<ProductCategoryDropdown> CategoryList {get; set;}
        public bool UserAlreadyRated { get; set; }
        public List<CommentsOnProduct> Commnets { get; set; }
        public AddToCartDetail CartInfo  { get; set; }
    }
    public class ProductCategoryDropdown
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }
    }
    public class CreatedBy
    {
        public string Name { get; set; }
    }
    public class AddToCartDetail
    {
        public int OrderQuantity { get; set; }
    }
    public class CommentsOnProduct
    {
        public string Comment { get; set; }
        public int Review { get; set; }
        public string UserName { get; set; }
    }
}
