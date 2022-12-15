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

        [HttpPost]
        public IActionResult AddProduct(int id)
        {
            BasketList.Add(GetSessionId(), _productService.GetAll().FirstOrDefault(x => x.Id == id));
            return RedirectToAction("Index");
        }
        public IActionResult Index()
        {
            return View(BasketList.GetBasket(GetSessionId()));
        }
    }
}
