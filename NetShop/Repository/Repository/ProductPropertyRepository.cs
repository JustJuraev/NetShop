using Microsoft.EntityFrameworkCore;
using NetShop.Models;
using NetShop.Repository.Interface;
using System.Collections.Generic;
using System.Linq;

namespace NetShop.Repository.Repository
{
    public class ProductPropertyRepository : IProductPropertyRepository
    {
        private ApplicationContext _context;
        
        public ProductPropertyRepository(ApplicationContext context) 
        { 
            _context = context;
        }

        public List<ProductProperty> GetAll()
        {
            return _context.ProductProperties.ToList();
        }

        public List<ProductProperty> ReturnCharac(int id)
        {
           
            return _context.ProductProperties.Include(p => p.Property).Where(p => p.ProductId == id).ToList(); 
        }

        public List<ProductProperty> JoinWithPropertyLanguage(int id, string language)
        {
            var propertys = from py in _context.Properties
                            join pyl in _context.PropertyLanguages
                            on py.Id equals pyl.PropertyId
                            where pyl.Language == language
                            select new Property
                            {
                                Id = py.Id,
                                Value = pyl.Value
                            };

            var Productpropertys = from pro in _context.ProductProperties
                                   join py in propertys
                                   on pro.PropertyId equals py.Id
                                   select new ProductProperty
                                   { 
                                      Id= pro.Id,
                                      Product = pro.Product,
                                      ProductId = pro.ProductId,
                                      Property = pro.Property,
                                      PropertyId= pro.PropertyId,
                                      PropertyLanguage =pro.PropertyLanguage,
                                      Value = py.Value,
                                      PPValue = pro.Value
                                   };



            return Productpropertys.Where(x => x.ProductId == id).ToList();
        }

        public List<Filters> Filter(int id)
        {
            Dictionary<string, Filters> filters = new Dictionary<string, Filters>();

            List<FilterModel> FilterModels = _context.ProductProperties
                .Include(p => p.Property)
                .Include(p => p.Product)
                .Where(x => x.Product.CategoryId == id)
                .OrderBy(x => x.Property.Value)
                .GroupBy(x => new FilterModel { Name = x.Property.Value, Value = x.Value, PropertyId = x.Property.Id})
                .Select(x => x.Key)
                .ToList();

            foreach (var item in FilterModels)
            {
                if(filters.ContainsKey(item.Name))
                {
                    filters[item.Name].FilterModels.Add(item);
                    continue;
                }
                List<FilterModel> newList = new List<FilterModel>();
                newList.Add(item);
                filters.Add(item.Name,new Filters() { FilterModels = newList, PropertyName = item.Name });
            }

            return filters.Values.ToList();
        }
    }
}
