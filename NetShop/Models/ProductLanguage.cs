using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NetShop.Models
{
    public class ProductLanguage
    {

        [Key, Column(Order = 0)]
        public int ProductId { get; set; }

        [Key, Column(Order = 1)]
        public string Language { get; set; }

        public string ShortDesc { get; set; }
       
        public string LongDesc { get; set; }

     
        public Product Product { get; set; }
    }
}
