using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace minihackaton.Controllers
{
    public class TicketsController : Controller
    {
        //
        // GET: /Tickets/

        public ActionResult Index()
        {
            return View();
        }

        // GET: /Create/
        public ActionResult Create()
        {
            return View();
        }

        // GET: /Check/
        public ActionResult Check()
        {
            return View();
        }

    }
}
