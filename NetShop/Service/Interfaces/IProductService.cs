using Microsoft.EntityFrameworkCore.Query;
using NetShop.Models;
using System.Collections.Generic;

namespace NetShop.Service.Interfaces
{
	public interface IProductService
	{
		List<Product> GetAll();

		List<Product> Search(string search);

        Product GetProduct(int id);

		List<Product> GetByCategory(int categoryId);
		List<Product> Sort(string sort);

		List<Product> Filter(int id, int pricemin, int pricemax, List<Filters> filters);

		
    }
}
