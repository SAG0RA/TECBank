using System;
using System.Collections.Generic;
using Catalog.Entities;

namespace Catalog.Repositorios
{
//Declararion de metodos que maneja el repositorio de Cuentas para comunicarse con otras aplicaciones
   public interface ICuentasRepository
    {
        Cuenta GetCuenta(Guid numero); //GET/{id} request
        IEnumerable<Cuenta> GetCuentas();//GET request 
        void CreateCuenta(Cuenta cuenta); //POST request
        void UpdateCuenta(Cuenta cuenta); //PUT request
        void DeleteCuenta(Guid numero); //DELETE request
    }


}