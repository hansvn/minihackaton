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

        public int insertUser(User p_us)
        {
            dc.Users.InsertOnSubmit(p_us);
            dc.SubmitChanges();

            User result = (from u in dc.Users
                          where u.Twitterpic == p_us.Twitterpic
                          select u).Single();
            return result.Id;
        }

        public Ticket checkTicket(Ticket p_ti)
        {
            var result = (from t in dc.Tickets
                          where t.Code == p_ti.Code
                          select t).Single();
            return (Ticket)result;
        }

        public bool changeTicketStatus(Ticket p_ti)
        {
            var ticket = (from t in dc.Tickets
                         where t.Code == p_ti.Code
                         select t).Single();

            // Execute the query, and change the column values 
            ticket.FK_Status = 2;

            // Submit the changes to the database. 
            try
            {
                dc.SubmitChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }

            return true;
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