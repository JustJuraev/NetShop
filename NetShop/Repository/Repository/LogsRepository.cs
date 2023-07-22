using NetShop.Models;
using NetShop.Repository.Interface;
using System.Linq;

namespace NetShop.Repository.Repository
{
    public class LogsRepository : ILogRepository
    {
        private ApplicationContext _context;

        public LogsRepository(ApplicationContext context)
        {
            _context = context;
        }

        public void AddLog(BasketProduct product)
        {
            var newproduct = product.Product;
            var log = new Log
            {
                BarCode = _context.Products.FirstOrDefault(x => x.Id == newproduct.Id).BarCode,
                TotalPrice = product.Count * newproduct.PriceOutCome,
                Count = product.Count,
                Type = "change",
                Time = System.DateTime.Now
            };

            _context.Logs.Add(log);
            _context.SaveChanges();
        }
    }
}
