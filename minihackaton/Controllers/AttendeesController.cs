using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace minihackaton.Controllers
{
    public class AttendeesController : Controller
    {
        //
        // GET: /Attendees/

        public ActionResult Index()
        {
            return View();
        }

        // GET: /Show/

        public ActionResult Show()
        {
            return View();
        }
    }
}
