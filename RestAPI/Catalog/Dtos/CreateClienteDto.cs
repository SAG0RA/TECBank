using System.ComponentModel.DataAnnotations;

namespace Catalog.Dtos
{
    public record CreateClienteDto //Funcion que crea un DTO de la clase cliente, por medio de esta funcion se pasan los atributos que tendra el cliente y se envian a CreateCliente()
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