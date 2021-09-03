using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using ProductManagement.DbContexts;
using ProductManagement.Models;
using Newtonsoft.Json;
using ProductManagement.Services;

namespace ProductManagement.Controllers
{
    [Authorize(Roles = "Admin")]
    public class ProductDetailsController : Controller
    {
        private ProductCategoryService _service;
        public IConfiguration _configuration { get; set; }
        private readonly ADbContexts _dbContext;
        public ProductDetailsController(IConfiguration configuration, ADbContexts dbContext)
        {
            _dbContext = dbContext;
            _configuration = configuration;
            var conString = _configuration["ConnectionStrings:Default"];
            _service = new ProductCategoryService(conString);
        }
        public IActionResult Index()
        {
            /*var dbcontext = new ADbContexts();*/
            var productEntities = _dbContext.ProductDetails.ToList();
         
            var products = new List<ProductDetailsModel>();
            foreach (ProductDetails item in productEntities)
            {
                var product = new ProductDetailsModel();
                product.Id = item.Id;
                product.ProductName = item.ProductName;
                product.Price = item.Price;
                product.CreatedDate = item.CreatedDate;
                product.CategoryId = item.CategoryId;
                product.UserId = item.UserId;
                product.Stock = item.Stock;

                var createdBy = new CreatedBy();
                //createdBy.Name = _dbContext.Users.SingleOrDefault(x => x.Id == item.UserId);
                product.CreatedBy = createdBy;

                var category = new ProductCategoryDropdown();
                var categoryEntity = _dbContext.ProductCategory.SingleOrDefault(x => x.Id == item.CategoryId);
                category.CategoryName = categoryEntity.CategoryName;
                product.Category = category;

                products.Add(product);
            }
            return View(products);
        }

        public IActionResult Create()
        {
            var productsCD = new List<ProductCategoryDropdown>();
            var productsCatagories = new List<ProductCategoryModel>();
            productsCatagories = _service.GetList();
            var model = new ProductDetailsModel();
            /*var pC = new ProductCategoryDropdown();*/
            foreach (var item in productsCatagories){
                var pC = new ProductCategoryDropdown();
                pC.CategoryName = item.CategoryName;
                pC.Id = item.Id;
                productsCD.Add(pC);               
            }
            model.CategoryList = productsCD;
            return View(model);
        }

        [HttpPost]
        public IActionResult Create(ProductDetailsModel model)
        {
            /*var dbcontext = new ADbContexts();*/
            var pDEntity = new ProductDetails();
            pDEntity.Id = model.Id;
            pDEntity.Price = model.Price;
            pDEntity.ProductName = model.ProductName;
            pDEntity.CreatedDate = DateTime.Now;
            pDEntity.UserId = User.FindFirstValue(ClaimTypes.NameIdentifier); 
            pDEntity.Discount = model.Discount;
            pDEntity.Description = model.Description;
            pDEntity.Stock = pDEntity.Stock;
            pDEntity.CategoryId = model.CategoryId;
            pDEntity.Click = 0;
            _dbContext.ProductDetails.Add(pDEntity);
            _dbContext.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            /*var dbContext = new ADbContexts();*/
            var productDetail = new ProductDetailsModel();
            var product = _dbContext.ProductDetails.SingleOrDefault(x => x.Id == id);
            var category = _dbContext.ProductCategory.SingleOrDefault(x => x.Id == product.CategoryId);
            productDetail.Id = id;
            productDetail.ProductName = product.ProductName;
            productDetail.Price = product.Price;
            productDetail.Stock = product.Stock;
            productDetail.CategoryId = product.CategoryId;
            productDetail.Discount = product.Discount;
            productDetail.Description = product.Description;
            /*var categoryOfProduct = new ProductCategoryDropdown();
            categoryOfProduct.CategoryName = category.CategoryName;
            categoryOfProduct.Id = product.CategoryId;
            productDetail.Category = categoryOfProduct;*/

            var productsCD = new List<ProductCategoryDropdown>();
            var productsCatagories = new List<ProductCategoryModel>();
            productsCatagories = _service.GetList();
            foreach (var item in productsCatagories)
            {
                var pC = new ProductCategoryDropdown();
                pC.CategoryName = item.CategoryName;
                pC.Id = item.Id;
                productsCD.Add(pC);
            }
            productDetail.CategoryList = productsCD;

            return View(productDetail);
        }

        [HttpPost]
        public IActionResult Edit(ProductDetailsModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            /*var dbcontext = new ADbContexts();*/
            var pDEntity = _dbContext.ProductDetails.SingleOrDefault(x => x.Id == model.Id);
            if (pDEntity != null)
            {
                pDEntity.Price = model.Price;
                pDEntity.ProductName = model.ProductName;
                pDEntity.CreatedDate = DateTime.Now;
                pDEntity.UserId = User.FindFirstValue(ClaimTypes.NameIdentifier); 
                pDEntity.Discount = model.Discount;
                pDEntity.Stock = model.Stock;
                pDEntity.Description = model.Description;
                pDEntity.CategoryId = model.CategoryId;
                pDEntity.Click = 0;
                _dbContext.SaveChanges();
            }
 
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
            int _id = id;
            /*var dbcontext = new ADbContexts();*/
            var service = new ServiceResponse();
            try
            {
                var pEntity = _dbContext.ProductDetails.SingleOrDefault(x => x.Id == id);
                if (pEntity != null)
                {
                    _dbContext.ProductDetails.Remove(pEntity);
                    _dbContext.SaveChanges();
                }
                service.IsSuccess = true;
                service.Message = "Deletion completed";
            }
            catch
            {
                service.IsSuccess = false;
                service.Message = "This product is in user's cart so, you can not delete it";
            }
            TempData["response"] = JsonConvert.SerializeObject(service);           
            return RedirectToAction("Index");
        }
        public IActionResult Details(int id)
        {
            var productDetail = new ProductDetailsModel();
            var product = _dbContext.ProductDetails.SingleOrDefault(x => x.Id == id);
            if (product != null)
            {
                productDetail.Id = product.Id;
                productDetail.ProductName = product.ProductName;
                productDetail.Price = product.Price;
                productDetail.Description = product.Description;
                productDetail.Discount = product.Discount;
                productDetail.Click = product.Click;
                productDetail.Stock = product.Stock;
                if (product.Discount != null)
                {
                    productDetail.DiscountedPrice = product.Price - (product.Price * (double)product.Discount) / 100.0;
                }
            }          
            return View(productDetail);
        }
        
    }
}
