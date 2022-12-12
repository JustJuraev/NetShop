using NetShop.Models;
using NetShop.Repository.Interface;
using NetShop.Service.Interfaces;
using System.Collections.Generic;

namespace NetShop.Service.Services
{
    public class PropertyService : IPropertyService
    {
        private IPropertyRepository _propertyRepository;

        public PropertyService(IPropertyRepository propertyRepository)
        {
            _propertyRepository = propertyRepository;
        }

        public List<Property> GetAll()
        {
            return _propertyRepository.GetAll();
        }
    }
}
