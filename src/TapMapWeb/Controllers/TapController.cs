using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TapMapWeb.Models;
using TapMapWeb.Session;

namespace TapMapWeb.Controllers
{
    public class TapController : Controller
    {
        public BeerRepository BeerRepository { get; set; }

        public PlaceRepository PlaceRepository { get; set; }

        public TapRepository TapRepository { get; set; }

        public TapController()
        {
            BeerRepository = new BeerRepository();
            PlaceRepository = new PlaceRepository();
            TapRepository = new TapRepository();
        }

        //
        // GET: /Tap/
        [HttpPost]
        public ActionResult Create(string placeId, string beerId, string comment)
        {
            if (placeId == "" || beerId == "" || comment == "")
            {
                return Content("FAIL");
            }

            var place = PlaceRepository.Get(placeId);
            var beer = BeerRepository.Get(beerId);

            var tap = new Tap
            {
                    Beer = beer,
                Place = place,
                Username = SessionUser.Current.Username,
                Timestamp = DateTime.Now,
                Comment = comment
            };

            TapRepository.Create(tap);
            return Content("OK");
        }

        public ActionResult List()
        {
            
            var json = Json(TapRepository.GetTaps().Select(t => new { comment = t.Comment, 
                                                                  place = t.Place.Name, 
                                                                  beer = t.Beer.Name,
                                                                  time = t.Timestamp,
                                                                  user = t.Username
                                                                })
                                                    //.Where(t => t.time > SessionUser.Current.LastQuery)
                                                    .ToList(), JsonRequestBehavior.AllowGet);
            SessionUser.Current.LastQuery = DateTime.Now;
            return json;
        }
    }
}
    