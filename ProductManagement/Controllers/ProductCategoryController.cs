using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using ProductManagement.Models;

namespace ProductManagement.Controllers
{
    [Authorize(Roles = "Admin")]
    public class ProductCategoryController : Controller
    {
        private ProductCategoryService _service;
        public IConfiguration _configuration { get; set; }
        public ProductCategoryController(IConfiguration configuration)
        {
            _configuration = configuration;
            var conString = _configuration["ConnectionStrings:Default"];
           _service = new ProductCategoryService(conString);

        }
        public IActionResult Index()
        {
            List<ProductCategoryModel> list = new List<ProductCategoryModel>();
            list = _service.GetList();
            return View(list);
        }
        public  IActionResult Create()
        {
            var model = new ProductCategoryModel();
            return View();
        }
        [HttpPost]
        public IActionResult Create(ProductCategoryModel model)
        {
            _service.Insert(model);
            return RedirectToAction("Index");
        }
        public IActionResult Edit(int id)
        {
            int _id = id;
            ProductCategoryModel model=_service.getProductCatagoryById(_id);
            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(ProductCategoryModel model)
        {
            _service.Update(model);
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
            int _id = id;
            var response= _service.removeProductCatagoryById(_id);
            TempData["response"] = JsonConvert.SerializeObject(response);
            return RedirectToAction("Index"); 
        }
    } 
}
