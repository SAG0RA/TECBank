using System;
namespace Catalog.Entities
{
    public record Cuenta  //Clase interna de las Cuentas  dentro del api
    { 
        public Guid numero_cuenta {get; init;} //Init: Solo le permitimos asignar un valor durante su inicializacion

        public string descripcion {get; init;}

        public string moneda {get; init;}

        public string tipo_cuenta {get; init;}

        public string Acliente {get; init;}

    }
}