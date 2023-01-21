using NetShop.Service.Services;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace NetShop.Models
{
	public class Product
	{
		public int Id { get; set; }

		public string Name { get; set; }

		public string Image { get; set; }

		public int Price { get; set; }

		public string ShortDesc { get; set; }

		public string LongDesc { get; set; }

        public int CategoryId { get; set; }

        public Category Category { get; set; }

		public int Count { get; set; }

		public List<ProductProperty> Properties { get; set; }

		
		public List<ProductAddress> Address { get; set; }
	}
}
