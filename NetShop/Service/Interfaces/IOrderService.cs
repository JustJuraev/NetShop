using NetShop.Models;
using System.Collections.Generic;

namespace NetShop.Service.Interfaces
{
    public interface IOrderService
    {
        List<Order> GetAll();

        void Create(Order order);

        int TotalSum(Order order);

        List<string> AddToOrderBasket(Order order);

        void Update(Order order);
    }
}
