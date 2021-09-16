using System;

namespace Catalog.Dtos
{
    public record ClienteDto //Info del DTO, para ser enviado a otras apps que se conecten al api
    {
        public Guid Id {get; init;} //Init: Solo le permitimos asignar un valor durante su inicializacion
        public DateTimeOffset Fecha  {get; init;}

        public string correo {get; init;}

        public string p_apellido {get; init;}

        public int cedula {get; init;}

        public string s_apellido {get; init;}

        public string Nombre {get; init;}

        public string contraseña {get; init;}

         public int telefono {get; init;}
    }
}