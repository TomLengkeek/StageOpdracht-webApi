using System;
using System.Collections.Generic;
using WebApiTest.Entities;

namespace WebApiTest.Repositories
{
    public interface ITicketRepository
    {
        Ticket GetTicket(Guid id);
        IEnumerable<Ticket> GetTickets();
        void CreateTicket(Ticket ticket);
        void UpdateTicket(Ticket ticket);
        void DeleteTicket(Guid id);
    }
}
