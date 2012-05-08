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
            return View("all_beers").StartKey(startsWith).Where(c => c.Name.StartsWith(startsWith));
        }
    }
}