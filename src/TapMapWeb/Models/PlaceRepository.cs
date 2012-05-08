using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TapMapWeb.Models
{
    public class PlaceRepository : RepositoryBase<Place>
    {

        public IEnumerable<Place> GetPlaces(string startsWith)
        {
            return View("all_places").StartKey(startsWith).Where(c => c.Name.StartsWith(startsWith));
        }

    }
}