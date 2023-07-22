using NetShop.Models;
using System.Collections.Generic;
using System.Linq;

namespace NetShop.Repository.Interface
{
    public interface IProductPropertyRepository : IBaseRepository<ProductProperty>
    {
        List<ProductProperty> ReturnCharac(int id);

        List<Filters> Filter(int id);

        List<ProductProperty> JoinWithPropertyLanguage(int id, string language);
    }
}
