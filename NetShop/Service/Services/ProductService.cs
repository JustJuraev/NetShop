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

		public List<Product> GetAll()
		{
			return _productRepository.GetAll();
		}
	}
}
