using System.ComponentModel.DataAnnotations;

namespace Catalog.Dtos
{
    public record UpdateClienteDto
        {
            [Required]
            public string Nombre {get; init;}
        }
}