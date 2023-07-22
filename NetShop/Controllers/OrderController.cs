using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;
using NetShop.Models;
using NetShop.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using Telegram.Bot;

namespace NetShop.Controllers
{
    public class OrderController : Controller
    {
        private IOrderService _orderService;
        private IProductService _productService;
        private ILogService _service;
        private IOrderBasketService _orderBasketService;
        private static string token { get; set; } = "5941784465:AAFH0ieeUsuM5X3HrhDDsA9YhHDIYUS0ui8";
        private static TelegramBotClient client;
        public OrderController(IOrderService orderService, IProductService productService, ILogService service, IOrderBasketService orderBasketService)
        {
            client = new TelegramBotClient(token);
            _orderService = orderService;
            _productService = productService;
            _service = service;
            _orderBasketService = orderBasketService;
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
            basketProduct.Product = _productService.GetProductById(id);
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
            basketProduct.Product  = _productService.GetProductById(id);
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
                //order.BasketProducts = BasketList.GetBasket(GetSessionId()).ToList();
                //order.TotalSum = BasketList.TotalSum(GetSessionId());
                return RedirectToAction("Login", "Account");
            }
            else
            {
                order.BasketProducts = BasketList.GetBasket(User.Identity.Name).ToList();
                order.TotalSum = BasketList.TotalSum(User.Identity.Name);
            }
            
            return View(order);
        }

        //private string GetBasket(Order order)
        //{
        //    string str = "";
        //    foreach(var item in order.Basket)
        //    {
                
        //        var product = _productService.GetAll().FirstOrDefault(x => x.Id == Int32.Parse(item[0].ToString()));
        //        str += $"{item[2]} x {product.Name} \r\n";
        //    }

        //    return str;
        //}

        [HttpPost]
        public IActionResult Index(Order order)
        {
            
            if (ModelState.IsValid)
            {
                order.TotalSum = _orderService.TotalSum(order);
                //    order.Basket = _orderService.AddToOrderBasket(order);
                string info = "";
                _orderService.Create(order);
                foreach (var item in order.BasketProducts)
                {
                    var product = _productService.GetProductById(item.Product.Id);
                    var product_count = product.Count - item.Count;
                    product.Count = product_count;
                    _service.AddLog(item);
                    var orderBasket = new OrderBasket
                    {
                        ProductName = product.Name,
                        ProductCount = item.Count,
                        ProductId = product.Id,
                        Price = product.PriceOutCome * item.Count,
                        OrderId = order.Id
                    };
                    info += $"{item.Count} X {product.Name} \r\n";
                    _orderBasketService.Create(orderBasket);
                }
               // _orderService.Update(order);


                client.SendTextMessageAsync("-1001835310535", "Новый заказ \r\n" +
                    $"Номер заказа: {order.Id}\r\n" + $"Адрес: {order.Address} \r\n" + $"Номер: {order.Number} \r\n"
                    + $"Общая сумма: {order.TotalSum} Сум \r\n" + "Товары \r\n"
                    + $"{info}");
                return RedirectToAction("Index", "Product");
            }
            
            return View(order);
        }


    }
}
