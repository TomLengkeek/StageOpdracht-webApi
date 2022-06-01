using System;

namespace WebApiTest.Dtos
{
    public record UserDto
    {

        public Guid Id { get; init; }
        public string Name { get; init; }
        public DateTime CreatedDate { get; init; }
    }
}
