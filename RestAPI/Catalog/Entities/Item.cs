using System;
namespace Catalog.Entities
{
    public record Item
    {
        public Guid Id {get; init;} //Init: Solo le permitimos asignar un valor durante su inicializacion

        public string Name {get; init;}

        public decimal Price {get; init;}

        public DateTimeOffset CreatedDate  {get; init;}
    }
}