using NetShop.Models.Helpers;
using System.Security.Claims;

namespace NetShop.Service.Interfaces
{
    public interface IAccountService
    {
        ClaimsIdentity Register(RegisterViewModel model);

        ClaimsIdentity Login(LoginViewModel model);
    }
}
