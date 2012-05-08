using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace TapMapWeb.Models
{
    public class Tap : ModelBase
    {
        [JsonProperty("username")]
        public string Username { get; set; }

        [JsonProperty("place")]
        public Place Place { get; set; }

        [JsonProperty("beer")]
        public Beer Beer { get; set; }

        [JsonProperty("timestamp")]
        public DateTime Timestamp { get; set; }

        [JsonProperty("comment")]
        public string Comment { get; set; }

        public override string Type
        {
            get { return "tap"; }
        }
    }
}