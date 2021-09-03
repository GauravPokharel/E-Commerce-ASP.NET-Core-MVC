using Microsoft.AspNetCore.Mvc;
using ProductManagement.DbContexts;
using ProductManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductManagement.Vc
{
    public class AddCommentsViewComponent : ViewComponent
    {
        private readonly ADbContexts _dbContext;
        public AddCommentsViewComponent( ADbContexts dbContext)
        {
            
            _dbContext = dbContext;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            List<CommentModel> model = new List<CommentModel>();
            var comments = _dbContext.Comment;
            
            return View(model);
        }
    }
}
