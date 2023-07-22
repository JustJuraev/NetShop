namespace NetShop.Models
{
    public class OrderBasket
    {
        public int Id { get; set; }

        public string ProductName { get; set; }

        public int ProductCount { get; set; }

        public int ProductId { get; set; }

        public int Price { get; set; }

        public int OrderId { get; set; }
    }
}
