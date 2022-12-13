using System.ComponentModel.DataAnnotations.Schema;

namespace NetShop.Models
{
    public class ProductProperty
    {
        public int Id { get; set; }

        public int ProductId { get; set; }

        [NotMapped]
        public Product Product { get; set; }

        public int PropertyId { get; set; }

        [NotMapped]
        public Property Property { get; set; }

        public string Value { get; set; }
    }
}
