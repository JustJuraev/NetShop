using NetShop.Models;
using NetShop.Repository.Interface;
using System.Collections.Generic;
using System.Linq;

namespace NetShop.Repository.Repository
{
    public class PropertyRepository : IPropertyRepository
    {
        private ApplicationContext _context;

        public PropertyRepository(ApplicationContext context) 
        { 
            _context = context;
        }

        public List<Property> GetAll() 
        {
            return _context.Properties.ToList();
        }
    }
}
