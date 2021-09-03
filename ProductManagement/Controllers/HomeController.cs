using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProductManagement.DbContexts;
using ProductManagement.Models;

namespace ProductManagement.Controllers
{
    /*[Authorize(Roles="Admin")]*/
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ADbContexts _dbContext;
        public HomeController(ILogger<HomeController> logger, ADbContexts dbContext)
        {
            _logger = logger;
            _dbContext = dbContext;
        }

        public IActionResult Index()
        {
            /*var product = new ProductDetails();*/
            List<ProductDetailsModel> productDetails = new List<ProductDetailsModel>();
            var products = _dbContext.ProductDetails.OrderByDescending(x => x.Click);
            foreach (var item in products)
            {
                var pD = new ProductDetailsModel();
                pD.Id = item.Id;
                pD.ProductName = item.ProductName;
                pD.Price = item.Price;
                pD.Description = item.Description;
                pD.Discount = item.Discount;
                if (pD.Discount != null)
                {
                    pD.DiscountedPrice = pD.Price - (pD.Price * (double)pD.Discount) / 100.0;
                }
                pD.Click = item.Click;
                productDetails.Add(pD);
            }
            return View(productDetails);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        public IActionResult GetProductByProductCategory(int id)
        {         
            var productDetail = new ProductDetails();
            var products = _dbContext.ProductDetails.Where(x => x.CategoryId == id).OrderByDescending(x => x.Click); 
            var cName = _dbContext.ProductCategory.SingleOrDefault(x => x.Id == id);

            List<ProductDetailsModel> productDetails = new List<ProductDetailsModel>();
            foreach (var item in products)
            {
                var pD = new ProductDetailsModel();
                pD.Id = item.Id;
                pD.ProductName = item.ProductName;
                pD.Price = item.Price;
                pD.Description = item.Description;
                pD.Discount = item.Discount;
                if (pD.Discount!= null)
                {
                    pD.DiscountedPrice = pD.Price-(pD.Price * (double)pD.Discount)/100.0;
                }                           
                productDetails.Add(pD);
            }
            ViewBag.Title = cName.CategoryName;
            return View(productDetails);
        }
        public IActionResult ProductDetailsForClient(int id)
        {
            /*var dbContext = new ADbContexts();*/
            var productDetail = new ProductDetailsModel();
            var product = _dbContext.ProductDetails.SingleOrDefault(x => x.Id == id);
            if (product != null)
            {
                product.Click += 1; 
                _dbContext.SaveChanges();
            }
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

            //Adding comments
            List<CommentsOnProduct> commentDetails = new List<CommentsOnProduct>();
            var commentsFromDb = _dbContext.Comment.Where(x=>x.ProductId==id);
            var ratingbyuser = _dbContext.Comment.SingleOrDefault(x => x.UserId == User.FindFirstValue(ClaimTypes.NameIdentifier) && x.ProductId == id);
            if (ratingbyuser != null)
            {
                productDetail.UserAlreadyRated = true;
            }
            else
            {
                productDetail.UserAlreadyRated = false;
            }
            foreach (var item in commentsFromDb) {
                var commentDetail = new CommentsOnProduct();
                commentDetail.Comment = item.Comments;
                commentDetail.Review = item.Review;

                var userInfo = _dbContext.Users.SingleOrDefault(x=>x.Id==item.UserId);
                commentDetail.UserName = userInfo.UserName;
                commentDetails.Add(commentDetail);
            }
            productDetail.Commnets = commentDetails;

            return View(productDetail);
        }
        [Authorize(Roles = "Admin,Customer")]
        [HttpPost]
        public IActionResult PostComment([FromBody] CommentModel model)
        {
            string uId = null;
            if (ModelState.IsValid)
            {
                var comment = new Comment();
                comment.Comments = model.Comments;
                comment.Review = model.Review;

                uId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                comment.UserId = uId;
                comment.ProductId = model.ProductId;
                _dbContext.Comment.Add(comment);
                _dbContext.SaveChanges();
            }
            var _username = _dbContext.Users.SingleOrDefault(x=>x.Id== uId);
            model.UserName = _username.UserName;
            return Json(model);
        }
    }
}
