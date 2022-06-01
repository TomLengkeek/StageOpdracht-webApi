using System;

namespace WebApiTest.Entities
{
    public record User
    {
        public Guid Id { get; init; }
        public string Name { get; init; }
        public DateTime CreatedDate { get; init; }
    }
}
