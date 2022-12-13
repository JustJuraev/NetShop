using NetShop.Models;
using NetShop.Repository.Interface;
using NetShop.Service.Interfaces;
using System.Collections.Generic;

namespace NetShop.Service.Services
{
    public class ProductPropertyService : IProductPropertyService
    {
        private IProductPropertyRepository _productProperty;

        public ProductPropertyService(IProductPropertyRepository productProperty)
        {
            _productProperty = productProperty;
        }

        public List<ProductProperty> GetAll()
        {
            return _productProperty.GetAll();
        }
    }
}
