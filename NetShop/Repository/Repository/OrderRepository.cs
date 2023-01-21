using Microsoft.AspNetCore.Http;
using NetShop.Models;
using NetShop.Repository.Interface;
using System.Collections.Generic;
using System.Linq;

namespace NetShop.Repository.Repository
{
    public class OrderRepository : IOrderRepository
    {
        private ApplicationContext _context;

        public OrderRepository(ApplicationContext context)
        {
            _context = context;
        }

        public int TotalSum(Order order)
        {
            int sum = 0;

            foreach (var item in order.BasketProducts)
            {
                for (int i = 0; i < item.Count; i++)
                {
                    sum += item.Product.Price;
                }
            }

            return sum;
        }

        public List<string> AddToOrderBasket(Order order)
        {
            List<string> list = new List<string>();
            string str = "";
            foreach (var item in order.BasketProducts)
            {
                str = $"{item.Product.Id} {item.Count}";
                list.Add(str);
            }
            return list;
        }


        public void Create(Order order)
        {
            order.Date = System.DateTime.Now;
            order.Status = 20;
            _context.Orders.Add(order);
            _context.SaveChanges();
        }

        public List<Order> GetAll()
        {
           return _context.Orders.ToList();
        }
    }
}
