using NetShop.Models;
using System.Collections.Generic;

namespace NetShop.Service.Interfaces
{
    public interface IPropertyService
    {
        List<Property> GetAll();
    }
}
