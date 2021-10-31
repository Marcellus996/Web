using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApp.Controllers
{
	public class HomeController : Controller
	{

		public ActionResult Index()
		{
			ViewBag.Message = "Products";

			var dataProvider = new AppDataPathProvider(HttpContext);
			var store = new Models.StoreJson(dataProvider);

			store.UpsertProduct(new Models.Product("1", "Pear", "Pear fruit", "fruit", "FruitProducer d. o. o.", "FruitSupplier d. o. o.", 230));
			store.UpsertProduct(new Models.Product("1", "Kiwi", "Kiwi fruit", "fruit", "FruitProducer d. o. o.", "FruitSupplier d. o. o.", 730));
			store.DeleteProduct("1");

			ViewBag.Products = store.GetProducts();

			return View();
		}
	}
}