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
			ViewBag.Products = store.GetProducts();

			return View();
		}

		public ActionResult Create()
		{
			ViewBag.Message = "Create Product";

			return View();
		}

		public ActionResult Update(string id)
		{
			ViewBag.Message = "Update Product";

			var dataProvider = new AppDataPathProvider(HttpContext);
			var store = new Models.StoreJson(dataProvider);
			var product = store.GetProduct(id);

			ViewBag.Product = product;

			return View();
		}

		[HttpPost]
		public ActionResult Upsert(Models.Product product)
		{
			var dataProvider = new AppDataPathProvider(HttpContext);
			var store = new Models.StoreJson(dataProvider);
			store.UpsertProduct(product);
			return RedirectToAction("Index");
		}

		[HttpPost]
		public ActionResult Delete(string id)
		{
			var dataProvider = new AppDataPathProvider(HttpContext);
			var store = new Models.StoreJson(dataProvider);
			store.DeleteProduct(id);
			return RedirectToAction("Index");
		}
	}
}