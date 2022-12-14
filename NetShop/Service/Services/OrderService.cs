using NetShop.Models;
using NetShop.Repository.Interface;
using NetShop.Service.Interfaces;
using System.Collections.Generic;

namespace NetShop.Service.Services
{
    public class OrderService : IOrderService
    {
        private IOrderRepository _orderRepository;

        public OrderService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public void Create(Order order)
        {
            _orderRepository.Create(order);
        }

        public List<Order> GetAll()
        {
            return _orderRepository.GetAll();
        }
    }
}
