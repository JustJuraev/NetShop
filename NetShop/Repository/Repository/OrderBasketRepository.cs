using NetShop.Models;
using NetShop.Repository.Interface;

namespace NetShop.Repository.Repository
{
    public class OrderBasketRepository : IOrderBasketRepository
    {
        private ApplicationContext _context;

        public OrderBasketRepository(ApplicationContext context)
        {
            _context = context;
        }

        public void Create(OrderBasket basket)
        {
            _context.OrderItems.Add(basket);
            _context.SaveChanges();
        }
    }
}
