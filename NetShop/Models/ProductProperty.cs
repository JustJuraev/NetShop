using System.ComponentModel.DataAnnotations.Schema;

namespace NetShop.Models
{
    public class ProductProperty
    {
        public int Id { get; set; }

        public int ProductId { get; set; }

     
        public Product Product { get; set; }

        public int PropertyId { get; set; }

       
        public Property Property { get; set; }

        public string Value { get; set; }

        [NotMapped]
        public PropertyLanguage PropertyLanguage { get; set; }

        [NotMapped]
      public string PPValue { get; set; }
    }
}
