using NetShop.Models;
using NetShop.Repository.Interface;
using NetShop.Service.Interfaces;
using System.Collections.Generic;

namespace NetShop.Service.Services
{
	public class ProductService : IProductService
	{
		private IProductRepository _productRepository;

		public ProductService(IProductRepository productRepository) 
		{ 
		   _productRepository = productRepository;
		}

        public List<Product> Filter(int id, int pricemin, int pricemax, List<Filters> filters)
        {
           return _productRepository.Filter(id,pricemin, pricemax, filters);
        }

        public List<Product> GetAll()
		{
			return _productRepository.GetAll();
		}

        public List<Product> GetByCategory(int categoryId)
        {
            return _productRepository.GetByCategory(categoryId);
        }

        public Product GetProduct(int id)
        {
            return _productRepository.GetProduct(id);
        }

        public List<Product> Search(string search)
        {
            return _productRepository.Search(search);
        }

        public List<Product> Sort(string sort)
		{
			return _productRepository.Sort(sort);
		}

    }
}
