using Microsoft.AspNetCore.Http;
using NetShop.Models;
using NetShop.Models.Enum;
using NetShop.Models.Helpers;
using NetShop.Repository.Interface;
using NetShop.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace NetShop.Service.Services
{
    public class AccountService : IAccountService
    {
        private IUserRepository _userRepository;
        public AccountService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

       
        public ClaimsIdentity Login(LoginViewModel model)
        {
            var user =  _userRepository.GetAll().FirstOrDefault(x => x.Name == model.Name);

            if (user != null && user.Password == HashPasswordHelper.HashPassword(model.Password))
            {
                var result = Authenticate(user);
                return result;
            }

            return new ClaimsIdentity();
        }

        public ClaimsIdentity Register(RegisterViewModel model)
        {
           
            var user = _userRepository.GetAll().FirstOrDefault(x => x.Name == model.Name);
         
            if(user == null)
            {
                user = new User()
                {
                    Name = model.Name,
                    Role = Role.User,
                    Password = HashPasswordHelper.HashPassword(model.Password),
                    RegionId = model.RegionId
                };
            }
            _userRepository.Add(user);
            var result = Authenticate(user);

            return result;
            
          
        }

        private ClaimsIdentity Authenticate(User user)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, user.Name),
                new Claim(ClaimsIdentity.DefaultRoleClaimType, user.Role.ToString())
            };
            return new ClaimsIdentity(claims, "ApplicationCookie",
                ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);
        }
    }
}
