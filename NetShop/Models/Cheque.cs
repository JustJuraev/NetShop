using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System;

namespace NetShop.Models
{
    public class Cheque
    {
        public int Id { get; set; }

        public DateTime Date { get; set; }

        [NotMapped]
        public List<ChequeItem> Items { get; set; }

        public int TotalPrice { get; set; }

        public int Status { get; set; } = 200;
    }
}
