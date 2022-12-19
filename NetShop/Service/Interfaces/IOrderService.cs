using NetShop.Models;
using System.Collections.Generic;

namespace NetShop.Service.Interfaces
{
    public interface IOrderService
    {
        List<Order> GetAll();

        void Create(Order order);
    }
}
