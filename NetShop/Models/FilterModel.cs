namespace NetShop.Models
{
    public class FilterModel
    {
        public string Name { get; set; }

        public string Value { get; set; }

        public int PropertyId { get; set; }

        public bool IsSelected { get; set; } = false;
    }
}
