using System.ComponentModel.DataAnnotations;

namespace Catalog.Dtos
{
    public record CreateCuentaDto //Funcion que crea un DTO de la clase cuenta, por medio de esta funcion se pasan los atributos que tendra la cuenta y se envian a CreateCuenta()
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