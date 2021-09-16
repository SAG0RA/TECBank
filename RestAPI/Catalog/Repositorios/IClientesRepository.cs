using System;
using System.Collections.Generic;
using Catalog.Entities;

namespace Catalog.Repositorios
{
//Declaracion de metodos que maneja el repositorio de Clientes para comunicarse con otras aplicaciones
   public interface IClientesRepository
    {
        Cliente GetCliente(Guid id); //GET/{id} request
        IEnumerable<Cliente> GetClientes();//GET request 
        void CreateCliente(Cliente cliente); //POST request
        void UpdateCliente(Cliente cliente); //PUT request
        void DeleteCliente(Guid id); //DELETE request
    }


}