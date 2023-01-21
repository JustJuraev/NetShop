using NetShop.Models;

namespace NetShop.Repository.Interface
{
    public interface IUserRepository : IBaseRepository<User>
    {
        void Add(User user);

        User ReturnByName(string name);
    }
}
