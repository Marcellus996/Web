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

		public List<Product> GetProducts()
		{
			string path = this.Provider.GetStorePath();
			using (StreamReader r = new StreamReader(path))
			{
				string json = r.ReadToEnd();
				return JsonConvert.DeserializeObject<List<Product>>(json);
			}

		}
	}
}