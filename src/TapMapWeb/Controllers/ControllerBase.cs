using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TapMapWeb.Filters;

namespace TapMapWeb.Controllers
{
    [SessionFilter(Order=0)]
	public class ControllerBase : Controller
	{		
		
	}
}
