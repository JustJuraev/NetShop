using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NetShop.Models;
using NetShop.Service.Interfaces;
using System.Linq;

namespace NetShop.Controllers
{
    public class BasketController : Controller
    {
        private IProductService _productService;

        public BasketController(IProductService productService)
        {
            _productService = productService;
        }

        public string GetSessionId()
        {
            HttpContext.Session.SetString("UserKey", "Product");
            TempData["Session"] = HttpContext.Session.Id;
            return TempData["Session"].ToString();
        }

        //private int TotalSum(string sessionId)
        //{
        //    int sum = 0;    
        //    foreach(var item in BasketList.GetBasket(sessionId))
        //    {
        //        sum += item.Price;
        //    }

        //    return sum;
        //}

        [HttpPost]
        public IActionResult Clear()
        {
            BasketList.Clear(GetSessionId());
            return RedirectToAction("Index");
        }


        [HttpPost]
        public IActionResult RemoveProduct(int id)
        {

            BasketProduct basketProduct = new BasketProduct();
            basketProduct.Product = _productService.GetProduct(id);
            BasketList.Remove(GetSessionId(), basketProduct);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult AddProduct(int id)
        {
            BasketProduct basketProduct = new BasketProduct();
            basketProduct.Product = _productService.GetProduct(id);
            BasketList.Add(GetSessionId(), basketProduct);
            return RedirectToAction("Index");
        }
        public IActionResult Index()
        {
            ViewBag.Sum = BasketList.TotalSum(GetSessionId());
            return View(BasketList.GetBasket(GetSessionId()));
        }
    }
}
