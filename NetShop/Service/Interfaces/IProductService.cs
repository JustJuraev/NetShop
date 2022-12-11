using NetShop.Models;
using System.Collections.Generic;

namespace NetShop.Service.Interfaces
{
	public interface IProductService
	{
		List<Product> GetAll();
	}
}
