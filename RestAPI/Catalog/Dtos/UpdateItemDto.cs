using System.ComponentModel.DataAnnotations;

namespace Catalog.Dtos
{
    public record UpdateItemDto
        {
            [Required]
            public string Nombre {get; init;}
        }
}