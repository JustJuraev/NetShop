using System.Collections.Generic;

namespace NetShop.Models
{
    public class ProductAddress
    {
        public int Id { get; set; }

        public int ProductId { get; set; }

        public int RegionId { get; set; }
    }
}
