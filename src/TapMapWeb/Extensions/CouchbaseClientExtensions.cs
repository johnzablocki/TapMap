using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Couchbase;
using Enyim.Caching.Memcached;
using Newtonsoft.Json;
using TapMapWeb.Resolvers;

namespace TapMapWeb.Extensions
{
	public static class CouchbaseClientExtensions
	{
		public static bool StoreJson(this CouchbaseClient client, StoreMode storeMode, string key, object value)
		{
			var json = JsonConvert.SerializeObject(value,
						Formatting.None,
						new JsonSerializerSettings { ContractResolver = new DocumentIdContractResolver() });
			return client.Store(storeMode, key, json);
		}

        public static CasResult<bool> CasJson(this CouchbaseClient client, StoreMode storeMode, string key, object value)
        {
            var json = JsonConvert.SerializeObject(value,
                        Formatting.None,
                        new JsonSerializerSettings { ContractResolver = new DocumentIdContractResolver() });
            return client.Cas(storeMode, key, json);
        }

		public static T GetJson<T>(this CouchbaseClient client, string key) where T : class
		{			 
			var json = client.Get<string>(key);
			return json == null ? null :  JsonConvert.DeserializeObject<T>(json);
		}
	}
}