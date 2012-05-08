using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TapMapWeb.Models;

namespace TapMapWeb.Controllers
{
    public class AutoCompleteController : ControllerBase
    {
        public PlaceRepository PlaceRepository { get; set; }
        public BeerRepository BeerRepository { get; set; }

        public AutoCompleteController()
        {
            PlaceRepository = new PlaceRepository();
            BeerRepository = new BeerRepository();
        }

        public ActionResult Places(string term)
        {
            return Json(PlaceRepository.GetPlaces(term).Select(p => new { label = p.Name, id = p.Id }), 
                JsonRequestBehavior.AllowGet);
        }

        public ActionResult Beers(string term)
        {
            return Json(BeerRepository.GetBeers(term).Select(b => new { label = b.Name, id = b.Id}),
                JsonRequestBehavior.AllowGet);
        }
    }
}