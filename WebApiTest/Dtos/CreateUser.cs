using System.ComponentModel.DataAnnotations;

namespace WebApiTest.Dtos
{
    public record CreateUser
    {
        [Required]
        [MaxLength(100)]
        public string Name { get; init; }
    }
}
