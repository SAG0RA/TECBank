using System;
using System.Collections.Generic;
using Catalog.Entities;

namespace Catalog.Repositorios
{
//clase necesaria para la inyeccion de dependencia
   public interface IClientesRepository
    {
        Cliente GetCliente(Guid id); //GET/{id} request
        IEnumerable<Cliente> GetClientes();//GET request 
        void CreateCliente(Cliente cliente); //POST request
        void UpdateCliente(Cliente cliente); //PUT request
        void DeleteCliente(Guid id); //DELETE request
    }


}