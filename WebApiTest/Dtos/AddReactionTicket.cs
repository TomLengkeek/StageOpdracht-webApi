using System.ComponentModel.DataAnnotations;
using WebApiTest.Entities;

namespace WebApiTest.Dtos
{
    public class AddReactionTicket
    {
        [Required]
        [MaxLength(200)]
        public string Reaction { get; init; }
        [Required]
        public Status status { get; init; }
    }
}
