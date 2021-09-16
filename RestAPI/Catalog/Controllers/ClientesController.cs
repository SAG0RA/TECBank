using System;
using Microsoft.AspNetCore.Mvc;
using Catalog.Repositorios;
using Catalog.Entities;
using System.Collections.Generic;
using System.Linq;
using Catalog.Dtos;
namespace Catalog.Controllers
{

    //Get /clientes
    [ApiController]
    [Route("clientes")] //Ruta en donde se encontrara el JSON de los clientes
    public class ClientesController : ControllerBase
    {
        private readonly IClientesRepository repository;

        public ClientesController(IClientesRepository repository) //Le pasamos el json precargado a la aplicación 
        {
            this.repository = repository;

        }

        //GET /clientes
        [HttpGet]
        public IEnumerable<ClienteDto> GetClientes()
        {
            var clientes = repository.GetClientes().Select( clientes => clientes.AsDto()); //Toma la información del repositorio interno y lo convierte en un DTO para desplegarlo en JSON
            
            return clientes;
        }

        //GET /clientes/{id}
        [HttpGet("{id}")]
        public ActionResult<ClienteDto> GetCliente(Guid id) //Consigue un cliente en particular segun su ID
        {
            var cliente = repository.GetCliente(id);

            if (cliente is null)
            {
                return NotFound(); //Si el cliente no se encuentra retornar null
            }

            return cliente.AsDto(); //Convertir el objeto encontrado en DTO
        } 

        //POST /cliente
        [HttpPost]
        public ActionResult<ClienteDto> CreateCliente(CreateClienteDto clienteDto)
        {
            Cliente cliente = new()
            { 
                //Pasar todos los desde el DTO a un objeto del repositorio
                Id = Guid.NewGuid(),
                Nombre = clienteDto.Nombre,
                Fecha = DateTimeOffset.UtcNow, 
                p_apellido = clienteDto.p_apellido,
                s_apellido = clienteDto.s_apellido,
                correo = clienteDto.correo,
                cedula = clienteDto.cedula,
                contraseña = clienteDto.contraseña,
                telefono = clienteDto.telefono
            };

            repository.CreateCliente(cliente); //Anadimos el objeto al repositorio

            return CreatedAtAction(nameof(GetCliente), new {id = cliente.Id}, cliente.AsDto()); //Creamos un header que especifica donde encontrar info acerca del objeto creado

        }

        //PUT /clientes
        [HttpPut("{id}")]
        public ActionResult UpdateCliente(Guid id, UpdateClienteDto clienteDto) //Actualiza la informacion de un cliente segun su ID 
        {
            var existingCliente = repository.GetCliente(id);

            if (existingCliente is null)
            {
                return NotFound();
            }

            Cliente updatedCliente = existingCliente with { //Reemplaza info 
                Nombre = clienteDto.Nombre
            };

            repository.UpdateCliente(updatedCliente); //Anade el cliente actualizado al repositorio

            return NoContent();
        }

        //Delete /items/{id}
        [HttpDelete("{id}")]
        public ActionResult DeleteCliente(Guid id) //Busca el cliente por ID y lo elimina
        {
            var existingCliente = repository.GetCliente(id);

            if (existingCliente is null)
            {
                return NotFound();
            }

            repository.DeleteCliente(id);

            return NoContent();
        }
    }
}