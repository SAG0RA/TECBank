using System;
using System.Collections.Generic;
using Catalog.Entities;

namespace Catalog.Repositorios
{
//clase necesaria para la inyeccion de dependencia
   public interface ICuentasRepository
    {
        Cuenta GetCuenta(Guid numero); //GET/{id} request
        IEnumerable<Cuenta> GetCuentas();//GET request 
        void CreateCuenta(Cuenta cuenta); //POST request
        void UpdateCuenta(Cuenta cuenta); //PUT request
        void DeleteCuenta(Guid numero); //DELETE request
    }


}