using NetShop.Models;
using System.Collections.Generic;

namespace NetShop.Repository.Interface
{
	public interface IProductRepository : IBaseRepository<Product>
	{
		Product GetProduct(int id);

		List<Product> GetByCategory(int categoryId);
		List<Product> Sort(string sort);

		List<Product> Filter(int id, int pricemin, int pricemax, List<Filters> filters);

		List<Product> Search(string search);

		
    }
}
