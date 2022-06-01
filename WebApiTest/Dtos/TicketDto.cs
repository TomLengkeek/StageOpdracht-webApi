using System;
using WebApiTest.Entities;

namespace WebApiTest.Dtos
{
    public record TicketDto
    {
        public Guid Id { get; init; }
        public string Title { get; init; }
        public string Message { get; init; }
        public DateTime CreatedDate { get; init; }
        public User User { get; init; }
        public string Reaction { get; init; }
        public Status status { get; init; }

    }
}
