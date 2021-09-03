using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using ProductManagement.DbContexts;
using ProductManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductManagement.Vc
{
    public class ClientNavBarViewComponent : ViewComponent
    {
        private ProductCategoryService _service;
        public IConfiguration _configuration { get; set; }
        public ClientNavBarViewComponent(IConfiguration configuration)
        {
            _configuration = configuration;
            var conString = _configuration["ConnectionStrings:Default"];
            _service = new ProductCategoryService(conString);
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            List<ProductCategoryModel> list = new List<ProductCategoryModel>();
            list = _service.GetList();
            return View(list);
        }
    }
}
