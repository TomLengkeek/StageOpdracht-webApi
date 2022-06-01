using System;
using System.Collections.Generic;
using System.Linq;
using WebApiTest.Entities;

namespace WebApiTest.Repositories
{
    public class TicketRepository : ITicketRepository
    {
        private readonly List<Ticket> Tickets = new()
        {
            new Ticket { Id = Guid.NewGuid(), Title = "Error", Message = "i have an error", CreatedDate = DateTime.Now, User = null , Reaction = null},
            new Ticket { Id = Guid.NewGuid(), Title = "Message", Message = "i have an message", CreatedDate = DateTime.Now, User = null , Reaction = null},
            new Ticket { Id = Guid.NewGuid(), Title = "Help", Message = "i need some help ", CreatedDate = DateTime.Now, User = null , Reaction = null}
        };

        public void CreateTicket(Ticket ticket)
        {
            Tickets.Add(ticket);
        }

        public void AddUser(User user, Ticket ticket)
        {
            Tickets[Tickets.IndexOf(ticket)].User = user;
        }

        public void DeleteTicket(Guid id)
        {
           Tickets.Remove(GetTicket(id));
        }

        public Ticket GetTicket(Guid id)
        {
            return Tickets.Where(ticket => ticket.Id == id).SingleOrDefault();
        }

        public IEnumerable<Ticket> GetTickets()
        {
            return Tickets;
        }

        public void UpdateTicket(Ticket ticket)
        {
            var index = Tickets.FindIndex(existingticket => existingticket.Id == ticket.Id);
            Tickets[index] = ticket;

        }
    }
}
