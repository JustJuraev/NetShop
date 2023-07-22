using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NetShop.Models
{
    public class Order
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Адрес не может быть пустым")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Введите ваш номер")]
        public string Number { get; set; }

        [Required(ErrorMessage = "Выберите тип доставки")]
        public bool Delivery { get; set; }

        public DateTime Date { get; set; }

        //public List<string> Basket { get; set; }


        [Required(ErrorMessage = "Номер карты не может быть пустым")]
        public string CartNum { get; set; }


        [NotMapped]
        public List<BasketProduct> BasketProducts { get; set; } = new List<BasketProduct>();

        public int TotalSum { get; set; }

        public short Status { get; set; }

        public string City { get; set; }

        [NotMapped]
        public const short Delivered = 10;
        [NotMapped]
        public const short NotDelivered = 20;
        [NotMapped]
        public const short Canceled = 30;
    }
}
