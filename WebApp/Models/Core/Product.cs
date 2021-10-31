using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApp.Models
{
	public class Product
	{
		public Product(string id, string name, string description, string category, string producer, string supplier, int price)
		{
			Id = id;
			Name = name;
			Description = description;
			Category = category;
			Producer = producer;
			Supplier = supplier;
			Price = price;
		}

		public string Id { get; set; }

		public string Name { get; set; }

		public string Description { get; set; }

		public string Category { get; set; }

		public string Producer { get; set; }

		public string Supplier { get; set; }

		public int Price { get; set; }
	}
}