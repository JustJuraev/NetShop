using NetShop.Models;
using System.Collections.Generic;

namespace NetShop.Repository.Interface
{
	public interface IProductRepository : IBaseRepository<Product>
	{
		Product GetProductById(int id);

        List<Product> GetByCategory(int categoryId);
		List<Product> Sort(string sort);

		List<Product> Filter(int id, int pricemin, int pricemax, List<Filters> filters, string lang);

		List<Product> Search(string search);
		List<Product> JoinWithProductLanguage(string lang);

		Product GetProduct(int id, string lang);

		List<Product> GetByCategoryId(int id, string lang);
    }
}
