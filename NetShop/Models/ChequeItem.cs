namespace NetShop.Models
{
    public class ChequeItem
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int Count { get; set; }

        public int Price { get; set; }

        public Cheque Cheque { get; set; }

        public int ChequeId { get; set; }

        public int ProductId { get; set; }
    }
}
