using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NetShop.Models;
using NetShop.Service.Interfaces;
using System.Linq;

namespace NetShop.Controllers
{
    public class OrderController : Controller
    {
        private IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        public string GetSessionId()
        {
            HttpContext.Session.SetString("UserKey", "Product");
            TempData["Session"] = HttpContext.Session.Id;
            return TempData["Session"].ToString();
        }

        public IActionResult Index()
        {
            ViewBag.Basket = BasketList.GetBasket(GetSessionId()).Select(x => x.Name).ToList();
            ViewBag.Basket2 = BasketList.GetBasket(GetSessionId());
            return View();
        }

        [HttpPost]
        public IActionResult Index(Order order)
        {
            order.Basket = BasketList.GetBasket(GetSessionId()).Select(x => x.Name).ToList();
            _orderService.Create(order);
            return RedirectToAction("Index", "Product");
        }

        


    }
}
