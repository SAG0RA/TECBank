using Catalog.Dtos;
using Catalog.Entities;

namespace Catalog
{
    public static class Extensions
    {
        public static ItemDto AsDto(this Item item)
        {
            return new ItemDto
            {
                Id = item.Id,
                Nombre = item.Nombre,
                Fecha = item.Fecha,
                p_apellido = item.p_apellido,
                s_apellido = item.s_apellido,
                correo = item.correo,
                contraseña = item.contraseña,
                telefono = item.telefono,
                cedula = item.cedula

            };           
        }
    }
}