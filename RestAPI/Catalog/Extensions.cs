using Catalog.Dtos;
using Catalog.Entities;

namespace Catalog
{
    public static class Extensions
    {
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
    }
}