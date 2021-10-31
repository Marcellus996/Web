﻿using System;
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
	}
}