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
