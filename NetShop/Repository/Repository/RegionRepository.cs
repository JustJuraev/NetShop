using Microsoft.EntityFrameworkCore;
using NetShop.Models;
using NetShop.Repository.Interface;
using System.Collections.Generic;
using System.Linq;

namespace NetShop.Repository.Repository
{
    public class RegionRepository : IRegionRepository
    {
        private ApplicationContext _context;

        public RegionRepository(ApplicationContext context)
        {
            _context = context;
        }

        public List<Region> GetAll()
        {
            return _context.Regions.AsNoTracking().ToList();
        }
    }
}
