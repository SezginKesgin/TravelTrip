using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TravelTripProject.Models.Class;

namespace TravelTripProject.Controllers
{
    public class ContactController : Controller
    {
        Context c = new Context();
        // GET: Contact
        public ActionResult Index()
        {
            var degerler = c.AdresBlogs.ToList();
            return View(degerler);
        }
    }
}