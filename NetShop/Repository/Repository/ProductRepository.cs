using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NetShop.Models;
using NetShop.Repository.Interface;
using System.Collections.Generic;
using System.Linq;

namespace NetShop.Repository.Repository
{
	public class ProductRepository : IProductRepository
	{
		private ApplicationContext _context;

		public ProductRepository(ApplicationContext context) 
		{ 
		   _context = context;
		}

      
		public List<Product> GetAll()
		{
            var list = _context.Products.OrderBy(x => x.Id).ToList();
           
			return list;
		}

        public List<Product> JoinWithProductLanguage(string lang)
        {
          
            var products = from p in _context.Products
                           join pl in _context.ProductLanguages
                           on p.Id equals pl.ProductId
                           where pl.Language == lang
                           select new Product
                           {
                               Id = p.Id,
                               Image = p.Image,
                               CategoryId = p.CategoryId,
                               Address = p.Address,
                               PriceIncome= p.PriceIncome,
                               PriceOutCome= p.PriceOutCome,
                               ProductLanguages= p.ProductLanguages,
                               Properties= p.Properties,
                               BarCode= p.BarCode,
                               Count = p.Count,
                               LongDesc = pl.LongDesc,
                               ShortDesc= pl.ShortDesc,
                               StockId = p.StockId,
                               Name = p.Name,
                               Category = p.Category
                              
                           };
          
            return products.ToList();
        }

        public List<Product> GetByCategoryId(int id, string lang)
        {
            var products = JoinWithProductLanguage(lang);
            return products.Where(x => x.CategoryId == id).ToList();
        }

        public List<Product> GetByCategory(int categoryId)
        {
           return _context.Products.Where(x => x.CategoryId == categoryId).ToList();
        }

        public Product GetProduct(int id, string lang)
        {
          
            var products = JoinWithProductLanguage(lang);
            return products.FirstOrDefault(x => x.Id == id);
        }

       
		public List<Product> Filter(int id, int pricemin, int pricemax, List<Filters> filters, string lang)
		{
            var list = new List<Product>();
            if (lang == "ru")
            {
                list = _context.Products.Include(x => x.Properties).Where(p => p.CategoryId == id).ToList();
            }
            else
            {
                list = JoinWithProductLanguage(lang);
            }
            List<string> filter = new List<string>();

          
            foreach (var item in filters)
            {
                var filter2 = item.FilterModels.Where(x => x.IsSelected).ToList();
                if (filter2.Count > 0)
                {
                    filter.AddRange(filter2.Select(x => x.Value));
                    list = list.Where(x => x.Properties.Any(x => filter.Contains(x.Value))).ToList();
                }
            }

            if (pricemin != 0 && pricemax != 0)
            {
                list = list.Where(x => x.PriceOutCome > pricemin && x.PriceOutCome < pricemax).ToList();
            }
            else if (pricemin != 0 && pricemax == 0)
            {
                list = list.Where(x => x.PriceOutCome > pricemin).ToList();
            }
            else if (pricemin == 0 && pricemax != 0)
            {
                list = list.Where(x => x.PriceOutCome < pricemax).ToList();
            }
            else if (pricemin == 0 && pricemax == 0)
            {
                return list.ToList();
            }

            return list.ToList();
		}

        public List<Product> Search(string search)
        {
            var list = GetAll();
            if (search != null)
            {
                list = list.Where(x => x.Name.ToLower().Contains(search.ToLower())).ToList();
            }
            if (list.Count() == 0)
            {
                var russian = new List<string>() { "а", "б", "в", "г", "д", "е", "ж", "з", "и", "й", "к", "л", "м", "н", "о", "п", "р", "с", "т", "у", "ф", "х", "к" };
                var english = new List<string>() { "a", "b", "v", "g", "d", "e", "j", "z", "i", "y", "c", "l", "m", "n", "o", "p", "r", "s", "t", "u", "f", "h", "k" };
                for (int i = 0; i < russian.Count; i++)
                {
                    search = search.Replace(russian[i], english[i]);
                }
           
                var newproduct = GetAll().Where(x => x.Name.ToLower().Contains(search.ToLower())).ToList();
                if(newproduct.Count() == 0) 
                {
                    for (int i = 0; i < english.Count; i++)
                    {
                        search = search.Replace(english[i], russian[i]);
                    }
                    var newproducts = GetAll().Where(x => x.Name.ToLower().Contains(search.ToLower())).ToList();
                    return newproducts;
                }
                return newproduct;
            }
            return list;
        }

		public List<Product> Sort(string sort)
		{
			var list = _context.Products.ToList();
			switch(sort) 
			{
				case "price":
					list = _context.Products.OrderByDescending(x => x.PriceOutCome).ToList();
					break;
                case "-price":
                    list = _context.Products.OrderBy(x => x.PriceOutCome).ToList();
                    break;
                case "begin":
                    list = _context.Products.OrderBy(x => x.Name).ToList();
                    break;
                case "finish":
                    list = _context.Products.OrderByDescending(x => x.Name).ToList();
                    break;
                default:
					list = _context.Products.ToList();
					break;
			}

			return list;
		}

        public Product GetProductById(int id)
        {
            return _context.Products.FirstOrDefault(x => x.Id == id);
        }
    }
}
