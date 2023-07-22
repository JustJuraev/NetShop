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

        public List<Product> Filter(int id, int pricemin, int pricemax, List<Filters> filters, string lang)
        {
           return _productRepository.Filter(id,pricemin, pricemax, filters, lang);
        }

        public List<Product> GetAll()
		{
			return _productRepository.GetAll();
		}

        public List<Product> GetByCategory(int categoryId)
        {
            return _productRepository.GetByCategory(categoryId);
        }

        public List<Product> GetByCategoryId(int id, string lang)
        {
            return _productRepository.GetByCategoryId(id, lang);
        }

        public Product GetProduct(int id, string lang)
        {
            return _productRepository.GetProduct(id, lang);
        }

        public Product GetProductById(int id)
        {
            return _productRepository.GetProductById(id);
        }

        public List<Product> JoinWithProductLanguage(string lang)
        {
            return _productRepository.JoinWithProductLanguage(lang);
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
