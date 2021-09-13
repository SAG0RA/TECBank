using System;
using System.Linq;
using System.Collections.Generic;
using Catalog.Entities;

namespace Catalog.Repositorios
{
    public class InMemClientesRepository : IClientesRepository
    {
        private readonly List<Cliente> lista_clientes = new()
        {
            new Cliente { Id = Guid.NewGuid(), Nombre = "Steven", Fecha = System.DateTimeOffset.Now, correo = "stevencm199@gmail.com", cedula = 207950858, p_apellido = "Castro", s_apellido = "Medina", contraseña = "123456", telefono = 84261892}

        };
        
        public IEnumerable<Cliente> GetClientes() //Obtiene objetos del repositorio
        {
            return lista_clientes;
        }
        public Cliente GetCliente(Guid id) //Obtiene objetos del repositorio por id 
        {
            return lista_clientes.Where(cliente => cliente.Id == id).SingleOrDefault();
        }

        public void CreateCliente(Cliente cliente)  //Anade objetos al repositorio
        {
            lista_clientes.Add(cliente);
        }

        public void UpdateCliente(Cliente cliente) //Actualiza objetos al repositorio
        {
            var index = lista_clientes.FindIndex(existingCliente => existingCliente.Id == cliente.Id); 
            lista_clientes[index] = cliente;
        }

        public void DeleteCliente(Guid id) //Borrar objetos del repositorio
        {
            var index = lista_clientes.FindIndex(existingCliente => existingCliente.Id == id);
            lista_clientes.RemoveAt(index);
            
        }
    }


}