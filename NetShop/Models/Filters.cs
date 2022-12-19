using System.Collections.Generic;

namespace NetShop.Models
{
    public class Filters
    {
        public string PropertyName { get; set; }

        //public int PropertyId { get; set; }

        public List<FilterModel> FilterModels { get; set; }
    }
}
