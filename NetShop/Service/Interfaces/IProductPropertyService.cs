using NetShop.Models;
using System.Collections.Generic;
using System.Linq;

namespace NetShop.Service.Interfaces
{
    public interface IProductPropertyService
    {
        List<ProductProperty> GetAll();

        List<ProductProperty> ReturnCharac(int id);

        List<Filters> Filter(int id);

        List<ProductProperty> JoinWithPropertyLanguage(int id, string language);
    }
}
