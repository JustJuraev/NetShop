using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace NetShop.Models
{
    public class CategoryLanguage
    {
        [Key, Column(Order = 0)]
        public int CategoryId { get; set; }

        [Key, Column(Order = 1)]
        public string Language { get; set; }

        public string Name { get; set; }
    }
}
