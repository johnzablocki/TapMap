using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TapMapWeb.Controllers
{
	public class HomeController : ControllerBase
	{
		public ActionResult Index()
		{
			return View();
		}
	}
}