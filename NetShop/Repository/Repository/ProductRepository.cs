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

	}
}
