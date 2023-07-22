using Microsoft.EntityFrameworkCore.Query;
using NetShop.Models;
using System.Collections.Generic;

namespace NetShop.Service.Interfaces
{
	public interface IProductService
	{
		List<Product> GetAll();

		List<Product> Search(string search);

        Product GetProduct(int id, string lang);

		List<Product> GetByCategory(int categoryId);
		List<Product> Sort(string sort);

		List<Product> Filter(int id, int pricemin, int pricemax, List<Filters> filters, string lang);

        List<Product> JoinWithProductLanguage(string lang);

        Product GetProductById(int id);

		List<Product> GetByCategoryId(int id, string lang);
    }
}
