using Catalog.Dtos;
using Catalog.Entities;

namespace Catalog
{
    public static class Extensions
    {
        //Metodos que necesitan los objetos de los repositorios para comunicarse con su version de DTOs
        public static ClienteDto AsDto(this Cliente cliente)
        {
            return new ClienteDto
            {
                Id = cliente.Id,
                Nombre = cliente.Nombre,
                Fecha = cliente.Fecha,
                p_apellido = cliente.p_apellido,
                s_apellido = cliente.s_apellido,
                correo = cliente.correo,
                contraseña = cliente.contraseña,
                telefono = cliente.telefono,
                cedula = cliente.cedula

            };           
        }

        public static CuentaDto c_AsDto(this Cuenta cuenta)
        {
            return new CuentaDto
            {
                numero_cuenta = cuenta.numero_cuenta,
                descripcion = cuenta.descripcion,
                moneda = cuenta.moneda,
                tipo_cuenta = cuenta.tipo_cuenta,
                Acliente = cuenta.Acliente
            
            };           
        }
    }
}