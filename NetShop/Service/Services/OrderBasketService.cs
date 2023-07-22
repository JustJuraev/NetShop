using NetShop.Models;
using NetShop.Repository.Interface;
using NetShop.Service.Interfaces;

namespace NetShop.Service.Services
{
    public class OrderBasketService : IOrderBasketService
    {
        private IOrderBasketRepository _repository;

        public OrderBasketService(IOrderBasketRepository repository)
        {
            _repository = repository;
        }

        public void Create(OrderBasket basket)
        {
           _repository.Create(basket);
        }
    }
}
