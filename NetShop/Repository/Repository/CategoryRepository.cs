using NetShop.Models;
using NetShop.Repository.Interface;
using System.Collections.Generic;
using System.Linq;

namespace NetShop.Repository.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private ApplicationContext _context;

        public CategoryRepository(ApplicationContext context)
        {
            _context = context;
        }

        public List<Category> JoinWithCategoryLanguage(string lang)
        {
            var categories = from c in _context.Categories
                             join cl in _context.CategoryLanguages
                             on c.Id equals cl.CategoryId
                             where cl.Language == lang
                             select new Category
                             {
                                 Id = c.Id,
                                 Image = c.Image,
                                 Name = cl.Name,
                                 Products = c.Products
                             };

            return categories.ToList();
        }

        public List<Category> GetAll()
        {
            return _context.Categories.ToList();
        }
    }
}
