using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TapMapWeb.Session;
using TapMapWeb.Constants;
using System.Web.Mvc;
using System.Threading;

namespace TapMapWeb.Filters
{
    public class SessionFilter : FilterAttribute, IAuthorizationFilter
    {

        public void OnAuthorization(AuthorizationContext filterContext)
        {

            if (SessionUser.Current == null)
            {
                SessionUser.SetCurrent(new SessionUser(new string[] { RoleConstants.ANONYMOUS_USERS }, ""));
            }

            HttpContext.Current.User = SessionUser.Current;
            Thread.CurrentPrincipal = SessionUser.Current;
        }
    }
}