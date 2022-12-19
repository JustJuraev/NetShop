using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using NetShop.Models;
using NetShop.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace NetShop.Controllers
{
	public class ProductController : Controller
	{
		private IProductService _productService;
		private IProductPropertyService _productPropertyService;
		private ICategoryService _categoryService;
		public ProductController(IProductService productService, IProductPropertyService productPropertyService,
			ICategoryService categoryService)
		{
			_productService = productService;
			_productPropertyService = productPropertyService;
			_categoryService = categoryService;
		}

		public IActionResult Index(string sort)
		{
			var list = _productService.Sort(sort);
			ViewBag.Categories = _categoryService.GetAll();
			return View(list);
		}

		public IActionResult Privacy()
		{
			return View();
		}

		public IActionResult GetByCategory(int id, int pricemin, int pricemax, List<Filters> filters)
		{
			ProductFilterModel productFilter = new ProductFilterModel();
			productFilter.Products = _productService.GetByCategory(id);
			productFilter.Filters = _productPropertyService.Filter(id);
			ViewBag.Pricemin = pricemin;


           
            productFilter.Products = _productService.Filter(id, pricemin, pricemax, filters);
           
            return View(productFilter);
		}

		public IActionResult GetProduct(int id)
		{
			ViewBag.List = _productPropertyService.ReturnCharac(id);
			return View(_productService.GetProduct(id));
		}

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}
