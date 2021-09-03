using Microsoft.AspNetCore.Mvc;
using ProductManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductManagement.Vc
{
    public class AddLocationInCartViewComponent: ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var model = new CartModel();
            return View(model);
        }
    }
}
