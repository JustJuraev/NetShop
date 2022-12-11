using Microsoft.AspNetCore.Mvc;
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

		public ProductController(IProductService productService)
		{
			_productService = productService;
		}

		public IActionResult Index()
		{
			return View(_productService.GetAll());
		}

		public IActionResult Privacy()
		{
			return View();
		}

		public IActionResult GetByCategory(int id)
		{
			return View(_productService.GetByCategory(id));
		}

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}
