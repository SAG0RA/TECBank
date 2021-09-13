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
    [Route("clientes")]
    public class ClientesController : ControllerBase
    {
        private readonly IClientesRepository repository;

        public ClientesController(IClientesRepository repository)
        {
            this.repository = repository;

        }

        //GET /clientes
        [HttpGet]
        public IEnumerable<ClienteDto> GetClientes()
        {
            var clientes = repository.GetClientes().Select( clientes => clientes.AsDto());
            
            return clientes;
        }

        //GET /clientes/{id}
        [HttpGet("{id}")]
        public ActionResult<ClienteDto> GetCliente(Guid id)
        {
            var cliente = repository.GetCliente(id);

            if (cliente is null)
            {
                return NotFound();
            }

            return cliente.AsDto();
        }

        //POST /cliente
        [HttpPost]
        public ActionResult<ClienteDto> CreateCliente(CreateClienteDto clienteDto)
        {
            Cliente cliente = new()
            {
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
        public ActionResult UpdateCliente(Guid id, UpdateClienteDto clienteDto)
        {
            var existingCliente = repository.GetCliente(id);

            if (existingCliente is null)
            {
                return NotFound();
            }

            Cliente updatedCliente = existingCliente with {
                Nombre = clienteDto.Nombre
            };

            repository.UpdateCliente(updatedCliente);

            return NoContent();
        }

        //Delete /items/{id}
        [HttpDelete("{id}")]
        public ActionResult DeleteCliente(Guid id)
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