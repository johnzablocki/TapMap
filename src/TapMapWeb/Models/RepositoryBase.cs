using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Couchbase;
using Enyim.Caching.Memcached;
using InflectorNet = Inflector.Net.Inflector;
using TapMapWeb.Extensions;

namespace TapMapWeb.Models
{
	public abstract class RepositoryBase<T> where T : ModelBase
	{
		protected static readonly CouchbaseClient _Client = null;

		static RepositoryBase()
		{
			_Client = new CouchbaseClient();
		}

		public virtual ulong Create(T model)
		{
			return store(StoreMode.Add, model);
		}

		public virtual ulong Update(T model)
		{
			return store(StoreMode.Replace, model);
		}

		public virtual ulong Save(T model)
		{
			return store(StoreMode.Set, model);
		}

		public virtual T Get(string id)
		{
			return _Client.GetJson<T>(id);
		}

		public virtual void Remove(string id)
		{
			_Client.Remove(id);
		}

		protected IView<T> View(string viewName)
		{            
			return _Client.GetView<T>(InflectorNet.Pluralize(typeof(T).Name.ToLower()), viewName);            
		}

        protected IView<IViewRow> Project(string viewName)
        {
            return _Client.GetView(InflectorNet.Pluralize(typeof(T).Name.ToLower()), viewName);
        }

        protected virtual string BuildKey(T model)
        {
            return string.Concat(model.Type, "_", model.Id.Replace(" ", "_"));
        }

		private ulong store(StoreMode mode, T model)
		{
			var result = _Client.CasJson(mode, BuildKey(model), model);
			return result.Result ? result.Cas : 0;
		}

		
	}
}