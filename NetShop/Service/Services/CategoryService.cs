using NetShop.Models;
using NetShop.Repository.Interface;
using NetShop.Service.Interfaces;
using System.Collections.Generic;

namespace NetShop.Service.Services
{
    public class CategoryService : ICategoryService
    {
        private ICategoryRepository _categoryRepository;

        public CategoryService(ICategoryRepository categoryRepository) 
        { 
            _categoryRepository = categoryRepository;
        }

        public List<Category> GetAll()
        {
           return _categoryRepository.GetAll();
        }

        public List<Category> JoinWithCategoryLanguage(string lang)
        {
            return _categoryRepository.JoinWithCategoryLanguage(lang);
        }
    }
}
