using System.ComponentModel.DataAnnotations;

namespace WebApiTest.Dtos
{
    public record UpdateItemDto
    {
        //zorgt ervoor dat de property niet nullable is
        [Required]
        public string Name { get; init; }
        [Required]
        [Range(0, 10000)]
        public int Price { get; init; }
    }
}
