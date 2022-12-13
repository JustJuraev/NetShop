using NetShop.Models;
using System.Collections.Generic;

namespace NetShop.Service.Interfaces
{
    public interface IProductPropertyService
    {
        List<ProductProperty> GetAll();
    }
}
