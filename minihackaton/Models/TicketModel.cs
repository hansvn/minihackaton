using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace minihackaton.Models
{
    public class TicketModel
    {
        private TicketServiceModelDataContextDataContext dc = new TicketServiceModelDataContextDataContext();

        public List<Ticket> selectAllTickets()
        {
            var result = (from t in dc.Tickets
                          select t).ToList<Ticket>();
            return result;
        }

        public List<User> selectAllUsers()
        {
            var result = (from u in dc.Users
                          select u).ToList<User>();
            return result;
        }

        // INSERT
        public void insertTicket(Ticket p_ti)
        {
            dc.Tickets.InsertOnSubmit(p_ti);
            dc.SubmitChanges();
        }

        public void insertUser(User p_us)
        {
            dc.Users.InsertOnSubmit(p_us);
            dc.SubmitChanges();
        }

        public Ticket checkTicket(Ticket p_ti)
        {
            var result = (from t in dc.Tickets
                          where t.Code == p_ti.Code
                          select t).Single();
            return (Ticket)result;
        }

        // GET THE USER ID (niet nodig hier)
        /*public int getUserId(User p_us)
        {
            var result = (from e in dc.Users
                          where e.Lastname == p_us.Lastname
                          select e.Id).Single();
            return Convert.ToInt16(result);
        }*/
    }
}