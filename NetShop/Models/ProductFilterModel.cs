using System.Collections.Generic;

namespace NetShop.Models
{
    public class ProductFilterModel
    {
        public List<Product> Products { get; set; }

        public List<Filters> Filters { get; set; }
    }
}
