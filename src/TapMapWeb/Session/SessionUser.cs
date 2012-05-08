using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Security.Principal;

namespace TapMapWeb.Session
{
	[Serializable]
	public class SessionUser : IPrincipal   
	{
		private const string SESSION_USER_KEY = "SessionUser";

        private readonly GenericIdentity _identity;
        private readonly string[] _roles;
        
        public SessionUser(string[] roles, string username)
        {
            _roles = roles;
            _identity = new GenericIdentity(username);
            Username = username;
        }

		public string Username { get; set; }

        public string Email { get; set; }

		public DateTime? LoginDate { get; set; }

        public IIdentity Identity { get; set; }

        public DateTime LastQuery { get; set; }

        public bool IsInRole(string role)
        {
            return _roles.FirstOrDefault(r => r == role) != null;
        }

		public static void SetCurrent(SessionUser sessionUser)
		{
			HttpContext.Current.Session[SESSION_USER_KEY] = sessionUser;
		}

		public static SessionUser Current
		{
			get { return HttpContext.Current.Session[SESSION_USER_KEY] as SessionUser; }
		}
	}
}