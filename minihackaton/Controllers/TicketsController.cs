using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using minihackaton.Models;

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

        [HttpPost]
        public ActionResult Create(FormCollection f)
        {
            string fname = f["firstname"];
            string lname = f["lastname"];
            string twitname = f["twittername"];

            TicketModel ticketModel = new TicketModel();
            User u = new User();
            u.Firstname = fname;
            u.Lastname = lname;
            u.Twitterpic = twitname;
            int userID = ticketModel.insertUser(u);

            //generate random int
            Random random = new Random();
            var i =  random.Next(1000, 10000);
            string code = twitname.Substring(0, 2) + i.ToString();

            Ticket t = new Ticket();
            t.FK_Status = 1;
            t.FK_User = userID;
            t.Code = code;
            ticketModel.insertTicket(t);

            ViewBag.status = "posted";
            ViewBag.ticket = code;
            return View();
            //skills per user model aanroepen

            //wegschrijven in skills per user
        }

        // GET: /Check/
        public ActionResult Check()
        {
            return View();
        }

    }
}
