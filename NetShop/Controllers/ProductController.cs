using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using NetShop.Models;
using NetShop.Repository.Interface;
using NetShop.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace NetShop.Controllers
{
	public class ProductController : Controller
	{
		private IProductService _productService;
		private IProductPropertyService _productPropertyService;
		private ICategoryService _categoryService;
		private IUserRepository _userRepository;
		private IProductAddressService _productAddress;
		private string defaultLanguage = "ru";
		public ProductController(IProductService productService, IProductPropertyService productPropertyService,
			ICategoryService categoryService, IUserRepository userRepository, IProductAddressService productAddress)
		{
			_productService = productService;
			_productPropertyService = productPropertyService;
			_categoryService = categoryService;
			_userRepository = userRepository;
			_productAddress = productAddress;
		}
		private string test = "";
		public IActionResult ChangeLanguage(string culture)
		{
			Response.Cookies.Append(CookieRequestCultureProvider.DefaultCookieName,
				CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture)),
				new CookieOptions() { Expires = DateTimeOffset.UtcNow.AddYears(1)});
			test = culture;
			return Redirect(Request.Headers["Referer"].ToString());
		}

		public IActionResult Index(string sort, string search, string testDefaultLanguage = "ru")
		{
            var list = new List<Product>();

            if (CultureInfo.CurrentCulture.Name != testDefaultLanguage)
            {
                list = _productService.JoinWithProductLanguage(CultureInfo.CurrentCulture.Name);
                ViewBag.Categories = _categoryService.JoinWithCategoryLanguage(CultureInfo.CurrentCulture.Name);
            }
            else
            {
                list = _productService.JoinWithProductLanguage(testDefaultLanguage); 
                list = _productService.Sort(sort);
                list = _productService.Search(search);
                ViewBag.Categories = _categoryService.GetAll();
            }

            return View(list);
        }

		public IActionResult Privacy()
		{
			return View();
		}

		public IActionResult GetByCategory(int id, int pricemin, int pricemax, List<Filters> filters, string testCurrentName = "ru")
		{
			ProductFilterModel productFilter = new ProductFilterModel();
			if(CultureInfo.CurrentCulture.Name != defaultLanguage) 
			   productFilter.Products = _productService.GetByCategoryId(id, CultureInfo.CurrentCulture.Name);
			else
			   productFilter.Products = _productService.GetByCategory(id);

			productFilter.Filters = _productPropertyService.Filter(id);
			ViewBag.Pricemin = pricemin;


           
            productFilter.Products = _productService.Filter(id, pricemin, pricemax, filters, testCurrentName);
           
            return View(productFilter);
		}

		public IActionResult GetProduct(int id)
		{
		
			//if (User.Identity.IsAuthenticated)
			//{
			//	ViewBag.UserRegion = _userRepository.ReturnByName(User.Identity.Name).RegionId;
			//	ViewBag.Regions = _productAddress.ReturnProductRegions(id);
			//}
			var product = new Product();

            if (CultureInfo.CurrentCulture.Name != defaultLanguage)
            {
                product = _productService.GetProduct(id, "uz");
				ViewBag.UZ = "uz";
				ViewBag.List = _productPropertyService.JoinWithPropertyLanguage(id, CultureInfo.CurrentCulture.Name);
            }
            else
            {
                product = _productService.GetProductById(id);
				ViewBag.DL = "ru";
                ViewBag.List = _productPropertyService.ReturnCharac(id);
            }

            return View(product);
		}

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}
