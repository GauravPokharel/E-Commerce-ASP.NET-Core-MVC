using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ProductManagement.DbContexts;
using ProductManagement.Models;
using Newtonsoft.Json;
using ProductManagement.Services;

namespace ProductManagement.Controllers
{
    [Authorize(Roles = "Admin,Customer")]
    public class CartController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly ADbContexts _dbContext;
        public CartController(UserManager<IdentityUser> userManager,
             SignInManager<IdentityUser> signInManager, RoleManager<IdentityRole> roleManager, ADbContexts dbContext)
        {
            _dbContext = dbContext;
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
        }
        public IActionResult Index()
        {
            string UserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var cartDetails = _dbContext.Cart.Where(x => x.UserId == UserId);
            List<CartModel> cartModels = new List<CartModel>();
            foreach (var item in cartDetails)
            {
                if (item.BuyOrder == false)
                {
                    var cartModel = new CartModel();
                    cartModel.Id = item.Id;
                    cartModel.OrderQuantity = item.OrderQuantity;
                    cartModel.DeliveryStatus = false;
                    cartModel.UserId = item.UserId;
                    var productInfoForCart = new ProductDetailsForCart();
                    productInfoForCart.ProductId = item.ProductId;
                    var product = _dbContext.ProductDetails.SingleOrDefault(x => x.Id == item.ProductId);

                    productInfoForCart.ProductName = product.ProductName;
                    productInfoForCart.Price = product.Price;
                    productInfoForCart.Discount = product.Discount;
                    if (product.Discount != null)
                    {
                        productInfoForCart.DiscountedPrice = product.Price - (product.Price * (double)product.Discount) / 100.0;
                    }
                    cartModel.ProductInfo = productInfoForCart;
                    cartModels.Add(cartModel);                    
                }
                
            }
            return View(cartModels);
        }

        [HttpPost]
        public IActionResult Add(ProductDetailsModel productModel)
        {
            //If product is already in cart
            string UserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var cartDetails = _dbContext.Cart.Where(x => x.UserId == UserId && x.BuyOrder==false);
            var productDetail = _dbContext.ProductDetails.SingleOrDefault(x => x.Id == productModel.Id);
            if (cartDetails!= null) 
            {
                bool increment = false;
                foreach (var item in cartDetails)
                {
                    if (item.ProductId == productModel.Id)
                    {                        
                        if(item.OrderQuantity + productModel.CartInfo.OrderQuantity > productDetail.Stock)
                        {
                            ServiceResponse service = new ServiceResponse();
                            service.IsSuccess = false;
                            service.Message = "Sorry we do not have enough stock. Item is not added in cart.";
                            TempData["response"] = JsonConvert.SerializeObject(service);
                            return RedirectToAction("Index");
                        }
                        item.OrderQuantity += productModel.CartInfo.OrderQuantity;
                        increment = true;
                        break;                        
                    }
                }
                if(increment== true)
                {
                    _dbContext.SaveChanges();
                    return RedirectToAction("Index");
                }                
            }  

            //If product is not in cart
            var cart = new Cart();
            cart.OrderQuantity = productModel.CartInfo.OrderQuantity;
            cart.ProductId = productModel.Id;
            cart.BuyOrder = false;
            cart.DeliveryStatus = false;
            cart.UserId= User.FindFirstValue(ClaimTypes.NameIdentifier);
            /*foreach (var item in User.Identities)
            {
                cart.UserId = item.
            }*/ 
            _dbContext.Cart.Add(cart);
            _dbContext.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            
            var cart = _dbContext.Cart.SingleOrDefault(x => x.Id == id);
            var product = _dbContext.ProductDetails.SingleOrDefault(x => x.Id == cart.ProductId);
            //string userId= User.FindFirstValue(ClaimTypes.NameIdentifier);
            //var cart= _dbContext.Cart.Where(x => (x.UserId == userId) && (x => x.ProductInfo.ProductId == id));
            var cartModel = new CartModel();
            cartModel.Id = cart.Id;
            cartModel.OrderQuantity = cart.OrderQuantity;
            var productInfoForCart = new ProductDetailsForCart();
            productInfoForCart.ProductId = cart.ProductId;
            productInfoForCart.ProductName = product.ProductName;
            productInfoForCart.Price = product.Price;
            productInfoForCart.Discount = product.Discount;
            productInfoForCart.Stock = product.Stock;
            if (product.Discount != null)
            {
                productInfoForCart.DiscountedPrice = product.Price - (product.Price * (double)product.Discount) / 100.0;
            }
            cartModel.ProductInfo = productInfoForCart;
            return View(cartModel);
        }
        [HttpPost]
        public IActionResult Edit(CartModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var cart = _dbContext.Cart.SingleOrDefault(x => x.Id == model.Id);
            if (cart != null)
            {
                cart.Id = model.Id;
                cart.OrderQuantity = model.OrderQuantity;
                cart.ProductId = model.ProductInfo.ProductId;
                cart.BuyOrder = false;
                cart.DeliveryStatus = false;
                cart.UserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                _dbContext.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var cartEntity = _dbContext.Cart.SingleOrDefault(x => x.Id == id);
            if (cartEntity != null)
            {
                _dbContext.Cart.Remove(cartEntity);
                _dbContext.SaveChanges();
            }
            return RedirectToAction("Index");
        }
        public IActionResult AddLocation(CartModel model)
        {
            string UserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var carts = _dbContext.Cart.Where(x => x.UserId == UserId && x.BuyOrder == false);
            
            if (carts != null)
            { foreach(var item in carts )
                {                    
                    var product = _dbContext.ProductDetails.SingleOrDefault(x => x.Id == item.ProductId);
                    if(product.Stock - item.OrderQuantity < 0)
                    {
                        OutOfStockResponse response = new OutOfStockResponse();
                        response.IsSuccess = false;
                        response.Message = " [Other products will be deliverd to delivery location] Sorry for inconvenient, we are out of stock for following products:";
                        response.ProductNames.Add(product.ProductName);
                        TempData["res"] = JsonConvert.SerializeObject(response);
                        return RedirectToAction("Index");
                    }
                    else if(product.Stock - item.OrderQuantity >= 0)
                    {
                        product.Stock -= item.OrderQuantity;
                        var cartsWithDeliveryStatus = _dbContext.Cart.SingleOrDefault(x => x.UserId == UserId && x.BuyOrder == true && x.DeliveryStatus == false &&x.ProductId==item.ProductId && x.DeliveryDestination== model.DeliveryDestination);
                        if (cartsWithDeliveryStatus!=null) {                        
                            cartsWithDeliveryStatus.OrderQuantity += item.OrderQuantity;
                            cartsWithDeliveryStatus.BuyOrder = true;
                            _dbContext.Remove(item);
                            }                                                
                        else
                        {
                            item.DeliveryDestination = model.DeliveryDestination;
                            item.BuyOrder = true;
                        }

                    }                    
                }              
                
                _dbContext.SaveChanges();
            }
            return RedirectToAction("Index","Home");
            
        }
        [Authorize(Roles= "Admin")]
        public IActionResult CartDetails()
        {
            var cartDetails = _dbContext.Cart.Where(x=>x.DeliveryStatus==false && x.BuyOrder==true).OrderBy(x => x.UserId);
            List<CartModel> cartModels = new List<CartModel>();
            foreach (var item in cartDetails)
            {
                var cartModel = new CartModel();
                cartModel.Id = item.Id;
                cartModel.OrderQuantity = item.OrderQuantity;
                cartModel.DeliveryStatus = false;
                cartModel.UserId = item.UserId;
                cartModel.DeliveryDestination = item.DeliveryDestination;

                //Get username
                var userdetail = _dbContext.Users.SingleOrDefault(x => x.Id==item.UserId);
                cartModel.UserName = userdetail.UserName;

                var productInfoForCart = new ProductDetailsForCart();
                productInfoForCart.ProductId = item.ProductId;
                var product = _dbContext.ProductDetails.SingleOrDefault(x => x.Id == item.ProductId);
                productInfoForCart.ProductName = product.ProductName;
                productInfoForCart.Price = product.Price;
                productInfoForCart.Discount = product.Discount;
                if (product.Discount != null)
                {
                    productInfoForCart.DiscountedPrice = product.Price - (product.Price * (double)product.Discount) / 100.0;
                }
                cartModel.ProductInfo = productInfoForCart;
                cartModels.Add(cartModel);
            }
            return View(cartModels);
        }
        [Authorize(Roles = "Admin")]
        public IActionResult Delivered(int id)
        {
            var cart = _dbContext.Cart.SingleOrDefault(x => x.Id == id);
            if (cart != null)
            {            
                cart.DeliveryStatus = true;
                _dbContext.SaveChanges();
            }
            return RedirectToAction("CartDetails");
        }
    }
}
