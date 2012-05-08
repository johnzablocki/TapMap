using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace TapMapWeb.Models
{
    [Serializable]
	public abstract class ModelBase
	{

		[JsonProperty(PropertyName = "_id")]
		public string Id { get; set; }

		[JsonProperty("type")]
		public abstract string Type { get; }

	}
}