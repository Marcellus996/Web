using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApp.Models
{
	public interface Store
	{
		List<Product> GetProducts();

		Product GetProduct(string id);

		void UpsertProduct(Product product);

		void DeleteProduct(string id);
	}
}