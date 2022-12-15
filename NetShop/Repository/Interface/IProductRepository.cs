using NetShop.Models;
using System.Collections.Generic;

namespace NetShop.Repository.Interface
{
	public interface IProductRepository : IBaseRepository<Product>
	{
		Product GetProduct(int id);

		List<Product> GetByCategory(int categoryId);
		List<Product> Sort(string sort);

    }
}
