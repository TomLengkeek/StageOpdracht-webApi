using System.ComponentModel.DataAnnotations;
using WebApiTest.Entities;

namespace WebApiTest.Dtos
{
    public class AddUserTicket
    {
        [Required]
        public User User { get; init; }

        [Required]
        public Status status { get; init; }
    }
}
