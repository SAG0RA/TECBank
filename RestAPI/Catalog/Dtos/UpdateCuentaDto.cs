using System.ComponentModel.DataAnnotations;

namespace Catalog.Dtos
{
    public record UpdateCuentaDto
        {
        [Required]
        public string descripcion {get; init;}
        
        [Required]
        public string tipo_cuenta {get; init;}
        }
}