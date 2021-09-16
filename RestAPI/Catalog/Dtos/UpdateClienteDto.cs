using System.ComponentModel.DataAnnotations;

namespace Catalog.Dtos
{
    public record UpdateClienteDto //Actualiza la informacion del DTO
        {
            [Required]
            public string Nombre {get; init;}
        }
}