using NetShop.Models;
using NetShop.Repository.Interface;
using NetShop.Service.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace NetShop.Service.Services
{
    public class ProductPropertyService : IProductPropertyService
    {
        private IProductPropertyRepository _productProperty;

        public ProductPropertyService(IProductPropertyRepository productProperty)
        {
            _productProperty = productProperty;
        }

        public List<Filters> Filter(int id)
        {
           return _productProperty.Filter(id);
        }

        public List<ProductProperty> GetAll()
        {
            return _productProperty.GetAll();
        }

        public List<ProductProperty> ReturnCharac(int id)
        {
            return _productProperty.ReturnCharac(id);
        }
    }
}
