using NetShop.Models;
using System.Collections.Generic;

namespace NetShop.Repository.Interface
{
    public interface IOrderRepository : IBaseRepository<Order>
    {
        void Create(Order order);

        int TotalSum(Order order);

        List<string> AddToOrderBasket(Order order);

        void Update(Order order);
    }
}
