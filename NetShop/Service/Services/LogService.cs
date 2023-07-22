using NetShop.Models;
using NetShop.Repository.Interface;
using NetShop.Service.Interfaces;

namespace NetShop.Service.Services
{
    public class LogService : ILogService
    {
        private ILogRepository _repository;

        public LogService(ILogRepository repository)
        {
            _repository = repository;
        }

        public void AddLog(BasketProduct product)
        {
            _repository.AddLog(product);
        }
    }
}
