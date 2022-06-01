using WebApiTest.Dtos;
using WebApiTest.Entities;

namespace WebApiTest
{
    public static class Extensions
    {
        public static UserDto AsDto(this User user)
        {
            return new UserDto
            {
                Id = user.Id,
                Name = user.Name,
                CreatedDate = user.CreatedDate
            };
        }

        public static TicketDto AsDto(this Ticket ticket)
        {
            return new TicketDto
            {
                Id = ticket.Id,
                Title = ticket.Title,
                Message = ticket.Message,
                User = ticket.User,
                CreatedDate = ticket.CreatedDate
            };
        }
    }
}
