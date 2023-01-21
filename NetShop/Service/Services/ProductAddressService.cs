using NetShop.Repository.Interface;
using NetShop.Service.Interfaces;
using System.Collections.Generic;

namespace NetShop.Service.Services
{
    public class ProductAddressService : IProductAddressService
    {
        private IProductAddressRepository _productAddressRepository;

        public ProductAddressService(IProductAddressRepository productAddressRepository) 
        { 
            _productAddressRepository = productAddressRepository;
        }

        public List<int> ReturnProductRegions(int id)
        {
            return _productAddressRepository.ReturnProductRegions(id);
        }
    }
}
