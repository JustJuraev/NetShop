using NetShop.Models.Enum;

namespace NetShop.Models
{
    public class User
    {
        public int Id { get; set; }

        public string Password { get; set; }

        public string Name { get; set; }

        public Role Role { get; set; }
    }
}
