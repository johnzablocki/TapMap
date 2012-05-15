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
            foreach (var item in View("all_places").StartKey(startsWith).EndKey(startsWith + "Z"))
            {
                yield return Get(item.ItemId);
            }
        }

    }
}