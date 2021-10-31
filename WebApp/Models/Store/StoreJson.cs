using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace WebApp.Models
{
	public class StoreJson : Store
	{
		private PathProvider Provider;

		public StoreJson(PathProvider Provider)
		{
			this.Provider = Provider;
		}

		public void DeleteProduct(string id)
		{
			var products = GetProducts();
			var newProducts = new List<Product>();

			for (var i = 0; i < products.Count; i++)
			{
				if (products[i].Id.Equals(id))
				{
					continue;
				}
				newProducts.Add(products[i]);
			}

			string json = JsonConvert.SerializeObject(newProducts);
			string path = this.Provider.GetStorePath();
			using (StreamWriter w = new StreamWriter(path))
			{
				w.Write(json);
			}
		}

		public Product GetProduct(string id)
		{
			var products = GetProducts();
			for (var i = 0; i < products.Count; i++)
			{
				if (products[i].Id.Equals(id))
				{
					return products[i];
				}
			}
			throw new KeyNotFoundException();
		}

		public List<Product> GetProducts()
		{
			string path = this.Provider.GetStorePath();
			using (StreamReader r = new StreamReader(path))
			{
				string json = r.ReadToEnd();
				return JsonConvert.DeserializeObject<List<Product>>(json);
			}

		}

		public void UpsertProduct(Product product)
		{
			var products = GetProducts();
			var newProducts = new List<Product>();

			for (var i = 0; i < products.Count; i++)
			{
				if (products[i].Id.Equals(product.Id))
				{
					continue;
				}
				newProducts.Add(products[i]);
			}
			newProducts.Add(product);

			string json = JsonConvert.SerializeObject(newProducts);
			string path = this.Provider.GetStorePath();
			using (StreamWriter w = new StreamWriter(path))
			{
				w.Write(json);
			}
		}
	}
}