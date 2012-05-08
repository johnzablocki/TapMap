using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TapMapWeb.Models
{
    public class TapRepository : RepositoryBase<Tap>
    {       
        public IEnumerable<Tap> GetTaps()
        {
            return View("all_taps").Limit(10).ToList();
        }
    }
}