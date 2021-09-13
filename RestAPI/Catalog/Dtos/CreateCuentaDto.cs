using System.ComponentModel.DataAnnotations;

namespace Catalog.Dtos
{
    public record CreateCuentaDto
        {
        [Required]
        public string descripcion {get; init;}
        [Required]
        public string moneda {get; init;}
        [Required]
        public string tipo_cuenta {get; init;}
        [Required]
        public string Acliente {get; init;}
        }
}