using Microsoft.EntityFrameworkCore;
using NetShop.Models;
using NetShop.Repository.Interface;
using System.Collections.Generic;
using System.Linq;

namespace NetShop.Repository.Repository
{
	public class ProductRepository : IProductRepository
	{
		private ApplicationContext _context;

		public ProductRepository(ApplicationContext context) 
		{ 
		   _context = context;
		}

		public List<Product> GetAll()
		{
			return _context.Products.ToList();
		}

        public List<Product> GetByCategory(int categoryId)
        {
           return _context.Products.Where(x => x.CategoryId == categoryId).ToList();
        }

        public Product GetProduct(int id)
        {
            return _context.Products.FirstOrDefault(x => x.Id == id);
        }

       
		public List<Product> Filter(int id, int pricemin, int pricemax, List<Filters> filters)
		{
			var list = _context.Products.Include(x => x.Properties).Where(p => p.CategoryId == id);
            List<string> filter = new List<string>();

          
            foreach (var item in filters)
            {
                var filter2 = item.FilterModels.Where(x => x.IsSelected).ToList();
                if (filter2.Count > 0)
                {
                    filter.AddRange(filter2.Select(x => x.Value));
                    list = list.Where(x => x.Properties.Any(x => filter.Contains(x.Value)));
                }
            }

            if (pricemin != 0 && pricemax != 0)
            {
                list = list.Where(x => x.Price > pricemin && x.Price < pricemax);
            }
            else if (pricemin != 0 && pricemax == 0)
            {
                list = list.Where(x => x.Price > pricemin);
            }
            else if (pricemin == 0 && pricemax != 0)
            {
                list = list.Where(x => x.Price < pricemax);
            }
            else if (pricemin == 0 && pricemax == 0)
            {
                return list.ToList();
            }

            return list.ToList();
		}

		public List<Product> Sort(string sort)
		{
			var list = _context.Products.ToList();
			switch(sort) 
			{
				case "price":
					list = _context.Products.OrderByDescending(x => x.Price).ToList();
					break;
                case "-price":
                    list = _context.Products.OrderBy(x => x.Price).ToList();
                    break;
                case "begin":
                    list = _context.Products.OrderBy(x => x.Name).ToList();
                    break;
                case "finish":
                    list = _context.Products.OrderByDescending(x => x.Name).ToList();
                    break;
                default:
					list = _context.Products.ToList();
					break;
			}

			return list;
		}
    }
}
