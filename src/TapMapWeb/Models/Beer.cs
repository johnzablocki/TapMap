using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace TapMapWeb.Models
{
    public class Beer : ModelBase
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("abv")]
        public double ABV { get; set; }

        public override string Type
        {
            get { return "beer"; }
        }
    }
}