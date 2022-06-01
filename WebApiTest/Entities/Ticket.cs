using System;

namespace WebApiTest.Entities
{
    public record Ticket
    {
        public Guid Id { get; init; }
        public string Title { get; init; }
        public string Message { get; init; }
        public DateTime CreatedDate { get; init; }
        public User User { get; set; }
        public string Reaction { get; set; }
    }
}
