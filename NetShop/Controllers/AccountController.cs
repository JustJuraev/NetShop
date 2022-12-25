using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using NetShop.Models.Helpers;
using NetShop.Service.Services;
using System.Security.Claims;
using System.Threading.Tasks;
using NetShop.Service.Interfaces;
using NetShop.Repository.Interface;
using System.Linq;

namespace NetShop.Controllers
{
    public class AccountController : Controller
    {
        private IAccountService _accountService;
        private IUserRepository _userRepository;
        public AccountController(IAccountService accountService, IUserRepository userRepository)
        {
            _accountService = accountService;
            _userRepository = userRepository;
        }


        [HttpGet]
        public IActionResult Register() => View();

        [HttpPost]
        public IActionResult Register(RegisterViewModel model)
        {
            var user = _userRepository.GetAll().FirstOrDefault(x => x.Name == model.Name);
            if (ModelState.IsValid)
            {
                if (user != null)
                {
                    ViewBag.Error = "Пользователь с таким логином уже есть";
                }
                else
                {
                    var response = _accountService.Register(model);

                    HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                        new ClaimsPrincipal(response));


                    return RedirectToAction("Index", "Product");
                }
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult Login() => View();
        [HttpPost]
        public IActionResult Login(LoginViewModel model)
        {
            var user = _userRepository.GetAll().FirstOrDefault(x => x.Name == model.Name);
            if (ModelState.IsValid)
            {
                if (user.Password != HashPasswordHelper.HashPassword(model.Password))
                {
                    ViewBag.Error = "Неправильный пароль";
                }
                else
                {
                    var response = _accountService.Login(model);

                    HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(response));

                    return RedirectToAction("Index", "Product");
                }
              
            }
            return View(model);
        }

        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Product");
        }
    }
}
