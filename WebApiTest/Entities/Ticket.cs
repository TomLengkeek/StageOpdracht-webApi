using System;

namespace WebApiTest.Entities
{
    public enum Status {
        Default = 0,
        New = 1,
        Assigned = 2,
        Done = 3
    }

    public record Ticket
    {
        public Guid Id { get; init; }
        public string Title { get; init; }
        public string Message { get; init; }
        public DateTime CreatedDate { get; init; }
        public Status status { get; set; }

        public User User { get; set; }
        public string Reaction { get; set; }
    }
}
