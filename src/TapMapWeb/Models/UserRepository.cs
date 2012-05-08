using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Enyim.Caching.Memcached;
using TapMapWeb.Extensions;
using System.Text;
using System.Security.Cryptography;
using TapMapWeb.Helpers;
using Couchbase;

namespace TapMapWeb.Models
{
	public class UserRepository : RepositoryBase<User>
	{
		public override ulong Create(User model)
		{			
            model.Password = HashHelper.ToHashedString(model.Password);
            model.Id = BuildKey(model);
            var result = _Client.CasJson(StoreMode.Add, BuildKey(model), model);
            return result.Result ? result.Cas : 0;
		}

        public User GetByEmail(string email)
        {
            return View("by_email").Limit(1).Key(email).Stale(StaleMode.False).FirstOrDefault();
        }

        private Couchbase.StaleMode StaleModeFirstOrDefault()
        {
            throw new NotImplementedException();
        }

        public User GetByUsername(string username)
        {
            return View("by_username").Limit(1).Key(username).Stale(StaleMode.False).FirstOrDefault();
        }

        public User Get(string username, string password)
        {
            return Get(buildKey(username, HashHelper.ToHashedString(password)));
        }

		protected override string BuildKey(User user)
		{
            return buildKey(user.Username, user.Password);
		}

        private string buildKey(string username, string password)
        {
            return string.Concat("user_", username, "_", password);
        }
	}
}