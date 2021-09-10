using System;
using Microsoft.AspNetCore.Mvc;
using Catalog.Repositorios;
using Catalog.Entities;
using System.Collections.Generic;
using System.Linq;
using Catalog.Dtos;
namespace Catalog.Controllers
{

    //Get /items
    [ApiController]
    [Route("items")]
    public class ItemsController : ControllerBase
    {
        private readonly IItemsRepository repository;

        public ItemsController(IItemsRepository repository)
        {
            this.repository = repository;

        }

        //GET /items 
        [HttpGet]
        public IEnumerable<ItemDto> GetItem()
        {
            var items = repository.GetItems().Select( item => item.AsDto());
            
            return items;
        }

        //GET /items/{id}
        [HttpGet("{id}")]
        public ActionResult<ItemDto> GetItem(Guid id)
        {
            var item = repository.GetItem(id);

            if (item is null)
            {
                return NotFound();
            }

            return item.AsDto();
        }

        //POST /items
        [HttpPost]
        public ActionResult<ItemDto> CreateItem(CreateItemDto itemDto)
        {
            Item item = new()
            {
                Id = Guid.NewGuid(),
                Nombre = itemDto.Nombre,
                Fecha = DateTimeOffset.UtcNow, 
                p_apellido = itemDto.p_apellido,
                s_apellido = itemDto.s_apellido,
                correo = itemDto.correo,
                cedula = itemDto.cedula,
                contraseña = itemDto.contraseña,
                telefono = itemDto.telefono
            };

            repository.CreateItem(item); //Anadimos el objeto al repositorio

            return CreatedAtAction(nameof(GetItem), new {id = item.Id}, item.AsDto()); //Creamos un header que especifica donde encontrar info acerca del objeto creado

        }

        //PUT /items
        [HttpPut("{id}")]
        public ActionResult UpdateItem(Guid id, UpdateItemDto itemDto)
        {
            var existingItem = repository.GetItem(id);

            if (existingItem is null)
            {
                return NotFound();
            }

            Item updatedItem = existingItem with {
                Nombre = itemDto.Nombre
            };

            repository.UpdateItem(updatedItem);

            return NoContent();
        }

        //Delete /items/{id}
        [HttpDelete("{id}")]
        public ActionResult DeleteItem(Guid id)
        {
            var existingItem = repository.GetItem(id);

            if (existingItem is null)
            {
                return NotFound();
            }

            repository.DeleteItem(id);

            return NoContent();
        }
    }
}