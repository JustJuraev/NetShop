using NetShop.Models;
using System.Collections.Generic;

namespace NetShop.Service.Interfaces
{
    public interface ICategoryService 
    {
        List<Category> GetAll();

        List<Category> JoinWithCategoryLanguage(string lang);
    }
}
