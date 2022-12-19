using System;

namespace NetShop.Models
{
    public class Order
    {
        public int Id { get; set; }

        public string Address { get; set; }

        public string Number { get; set; }

        public bool Delivery { get; set; }

        public DateTime Date { get; set; }
    }
}
