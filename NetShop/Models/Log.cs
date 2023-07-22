using System;

namespace NetShop.Models
{
    public class Log
    { 
        public int Id { get; set; }

        public DateTime Time { get; set; }

        public int BarCode { get; set; }

        public string Type { get; set; }

        public int Count { get; set; }

        public long TotalPrice { get; set; }

        public int ChequeId { get; set; }
        
    }
}
