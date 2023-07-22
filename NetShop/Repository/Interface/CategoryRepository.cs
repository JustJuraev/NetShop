using NetShop.Models;
using System.Collections.Generic;

namespace NetShop.Repository.Interface
{
    public interface ICategoryRepository : IBaseRepository<Category>
    {
        List<Category> JoinWithCategoryLanguage(string lang);
    }
}
