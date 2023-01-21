using NetShop.Models;
using NetShop.Repository.Interface;
using System.Collections.Generic;
using System.Linq;

namespace NetShop.Repository.Repository
{
    public class ProductAddressRepository : IProductAddressRepository
    {
        private ApplicationContext _context;

        public ProductAddressRepository(ApplicationContext context) 
        { 
            _context = context;
        }

        public List<int> ReturnProductRegions(int id)
        {
            return _context.ProductAddresses.Where(x => x.ProductId == id).Select(x => x.RegionId).ToList();
        }
    }
}
