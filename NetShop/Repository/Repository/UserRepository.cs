using NetShop.Models;
using NetShop.Repository.Interface;
using System.Collections.Generic;
using System.Linq;

namespace NetShop.Repository.Repository
{
    public class UserRepository : IUserRepository
    {
        public ApplicationContext _context;

        public UserRepository(ApplicationContext context)
        {
            _context = context;
        }

        public void Add(User user)
        {
            if (!_context.Users.Contains(user))
            {
                _context.Users.Add(user);
                _context.SaveChanges();
            }
        }

        public List<User> GetAll()
        {
            return _context.Users.ToList();
        }
    }
}
