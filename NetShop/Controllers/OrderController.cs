using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;
using NetShop.Models;
using NetShop.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using Telegram.Bot;

namespace NetShop.Controllers
{
    public class OrderController : Controller
    {
        private IOrderService _orderService;
        private IProductService _productService;
        private static string token { get; set; } = "5941784465:AAFH0ieeUsuM5X3HrhDDsA9YhHDIYUS0ui8";
        private static TelegramBotClient client;
        public OrderController(IOrderService orderService, IProductService productService)
        {
            client = new TelegramBotClient(token);
            _orderService = orderService;
            _productService = productService;
        }

        public string GetSessionId()
        {
            HttpContext.Session.SetString("UserKey", "Product");
            TempData["Session"] = HttpContext.Session.Id;
            return TempData["Session"].ToString();
        }


        [HttpPost]
        public IActionResult RemoveProduct(int id)
        {
            BasketProduct basketProduct = new BasketProduct();
            basketProduct.Product = _productService.GetProduct(id);
            if (User.Identity.IsAuthenticated)
                BasketList.Remove(User.Identity.Name, basketProduct);
            else
                BasketList.Remove(GetSessionId(), basketProduct);

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult AddProduct(int id)
        {
            BasketProduct basketProduct = new BasketProduct();
            basketProduct.Product  = _productService.GetProduct(id);
            if(User.Identity.IsAuthenticated)
                 BasketList.Add(User.Identity.Name, basketProduct);
            else
                BasketList.Add(GetSessionId(), basketProduct);

            return RedirectToAction("Index");
        }

        public IActionResult Index()
        {
            Order order = new Order();
           
            if (!User.Identity.IsAuthenticated)
            {
                
                order.BasketProducts = BasketList.GetBasket(GetSessionId()).ToList();
                order.TotalSum = BasketList.TotalSum(GetSessionId());
                if (order.BasketProducts.Count > 0) 
                {
                    order.BasketProducts.Clear();
                    order.TotalSum = 0;
                }
              
            }
            else
            {
                order.BasketProducts = BasketList.GetBasket(User.Identity.Name).ToList();
                order.TotalSum = BasketList.TotalSum(User.Identity.Name);
            }
            
            return View(order);
        }

        private string GetBasket(Order order)
        {
            string str = "";
            foreach(var item in order.Basket)
            {
                
                var product = _productService.GetAll().FirstOrDefault(x => x.Id == Int32.Parse(item[0].ToString()));
                str += $"{item[2]} x {product.Name} \r\n";
            }

            return str;
        }

        [HttpPost]
        public IActionResult Index(Order order)
        {
            
            if (ModelState.IsValid)
            {
                order.TotalSum = _orderService.TotalSum(order);
                order.Basket = _orderService.AddToOrderBasket(order);


                foreach (var item in order.BasketProducts)
                {
                    var product = _productService.GetProduct(item.Product.Id);
                    var product_count = product.Count - item.Count;
                    product.Count = product_count;
                }

                _orderService.Create(order);

                client.SendTextMessageAsync("-1001835310535", "Новый заказ \r\n" +
                    $"Номер заказа: {order.Id}\r\n" + $"Адрес: {order.Address} \r\n" + $"Номер: {order.Number} \r\n"
                    + $"Общая сумма: {order.TotalSum} Сум \r\n" + "Товары \r\n"
                    + $"{GetBasket(order)}");
                return RedirectToAction("Index", "Product");
            }
            
            return View(order);
        }


    }
}
