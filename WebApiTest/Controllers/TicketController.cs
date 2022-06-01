using Microsoft.AspNetCore.Mvc;
using WebApiTest.Entities;
using WebApiTest.Repositories;
using System.Collections.Generic;
using System.Linq;
using WebApiTest.Dtos;
using System;

namespace WebApiTest.Controllers
{
    [Controller]
    [Route("Tickets")]
    public class TicketController : ControllerBase
    {
        private readonly ITicketRepository ticketRepository;
        private readonly IUserRepository userRepository;

        //dependancy injection
        public TicketController( IUserRepository users, ITicketRepository tickets)
        {
            this.ticketRepository = tickets;
            this.userRepository = users;
        }

        //GET /Tickets
        [HttpGet]
        public IEnumerable<TicketDto> getTickets()
        {
            var tickets = ticketRepository.GetTickets().Select(ticket => ticket.AsDto());
            return tickets;
        }

        //GET /Tickets/{id}
        [HttpGet("{id}")]
        public ActionResult<TicketDto> getTicket(Guid id)
        {
            var ticket = ticketRepository.GetTicket(id);

            if (ticket == null)
            {
                return NotFound();
            }

            return Ok(ticket.AsDto());
        }

        //POST /Tickets
        [HttpPost]
        public ActionResult<TicketDto> createTicket(CreateTicket ticketDto)
        {
            Ticket ticket = new()
            {
                Id = Guid.NewGuid(),
                Title = ticketDto.Title,
                Message = ticketDto.Message,
                User = ticketDto.User,
                Reaction = ticketDto.Reaction,
                CreatedDate = DateTime.Now
            };
            ticketRepository.CreateTicket(ticket);
            return CreatedAtAction(nameof(getTicket), new { id = ticket.Id }, ticket.AsDto());
        }

        //PUT /Tickets/{id}
        [HttpPut("{id}")]
        public ActionResult updateTicket(Guid id, UpdateTicket ticketDto)
        {
            var existingTicket = ticketRepository.GetTicket(id);
            if (existingTicket == null)
            {
                return NotFound();
            }

            Ticket ticket = existingTicket with
            {
                Message = ticketDto.Message,
                Title = ticketDto.Title,
                User = ticketDto.User,
                Reaction = ticketDto.Reaction,
            };
            ticketRepository.UpdateTicket(ticket);

            return NoContent();
        }

        //DELTE /Ticket/{id}
        [HttpDelete("{id}")]
        public ActionResult deleteTicket(Guid id)
        {
            var ticket = ticketRepository.GetTicket(id);
            if(ticket == null)
            {
                return NotFound();
            }
            ticketRepository.DeleteTicket(id);
            return NoContent();
        }
}
}
