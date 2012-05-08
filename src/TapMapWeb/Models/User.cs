using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace TapMapWeb.Models
{
	[Serializable]
	public class User : ModelBase
	{
		[Required]
		public string Username { get; set; }

		[Required]
		public string Email { get; set; }

		[Required]
		public string Password { get; set; }

		public override string Type
		{
			get { return "user"; }
		}
	}
}