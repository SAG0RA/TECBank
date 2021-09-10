using System.ComponentModel.DataAnnotations;

namespace Catalog.Dtos
{
    public record CreateItemDto
        {
            [Required]
            public string Nombre {get; init;}
            [Required]
            public string correo {get; init;}
            [Required]
            public string p_apellido {get; init;}
            [Required]
            public int cedula {get; init;}
            [Required]
            public string s_apellido {get; init;}
            [Required]
            public string contraseña {get; init;}
            [Required]
            public int telefono {get; init;}
        }
}