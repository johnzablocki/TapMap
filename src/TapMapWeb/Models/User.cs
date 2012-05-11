using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace TapMapWeb.Models
{
	[Serializable]
	public class User : ModelBase
	{
		[Required]
        [JsonProperty("username")]
        public string Username { get; set; }

		[Required]
        [JsonProperty("email")]
		public string Email { get; set; }

		[Required]
        [JsonProperty("password")]
		public string Password { get; set; }

		public override string Type
		{
			get { return "user"; }
		}
	}
}