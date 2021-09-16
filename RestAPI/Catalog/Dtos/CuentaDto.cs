using System;
namespace Catalog.Entities
{
    public record CuentaDto //Info del DTO, para ser enviado a otras apps que se conecten al api
    {
        public Guid numero_cuenta {get; init;} //Init: Solo le permitimos asignar un valor durante su inicializacion

        public string descripcion {get; init;}

        public string moneda {get; init;}

        public string tipo_cuenta {get; init;}

        public string Acliente {get; init;}

    }
}