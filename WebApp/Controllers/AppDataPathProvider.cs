using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApp.Controllers
{
	public class AppDataPathProvider : Models.PathProvider
	{
		private HttpContextBase HttpContext;

		public AppDataPathProvider(HttpContextBase httpContext)
		{
			HttpContext = httpContext;
		}

		public string GetStorePath()
		{
			return this.HttpContext.Server.MapPath("~/App_Data/Products.json");
		}
	}
}