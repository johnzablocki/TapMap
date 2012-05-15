using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TapMapWeb.Models
{
    public class BeerRepository : RepositoryBase<Beer>
    {
        public IEnumerable<Beer> GetBeers(string startsWith)
        {
            foreach (var item in View("all_beers").StartKey(startsWith).EndKey(startsWith + "Z"))
            {
                yield return Get(item.ItemId);
            }
        }
    }
}