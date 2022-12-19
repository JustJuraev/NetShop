using NetShop.Models;

namespace NetShop.Repository.Interface
{
    public interface IOrderRepository : IBaseRepository<Order>
    {
        void Create(Order order);
    }
}
