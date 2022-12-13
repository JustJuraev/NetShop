using NetShop.Models;
using NetShop.Repository.Interface;
using System.Collections.Generic;
using System.Linq;

namespace NetShop.Repository.Repository
{
    public class ProductPropertyRepository : IProductPropertyRepository
    {
        private ApplicationContext _context;

        public ProductPropertyRepository(ApplicationContext context) 
        { 
            _context = context;
        }

        public List<ProductProperty> GetAll()
        {
            return _context.ProductProperties.ToList();
        }
    }
}
