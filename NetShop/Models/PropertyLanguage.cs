using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace NetShop.Models
{
    public class PropertyLanguage
    {
        [Key, Column(Order = 0)]
        public int PropertyId { get; set; }

        [Key, Column(Order = 1)]
        public string Language { get; set; }

        public string Value { get; set; }
    }
}
