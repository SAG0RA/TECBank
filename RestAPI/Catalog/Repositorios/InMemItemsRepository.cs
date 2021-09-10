using System;
using System.Linq;
using System.Collections.Generic;
using Catalog.Entities;

namespace Catalog.Repositorios
{
    public class InMemItemsRepository : IItemsRepository
    {
        private readonly List<Item> items = new()
        {
            new Item { Id = Guid.NewGuid(), Nombre = "Steven", Fecha = System.DateTimeOffset.Now, correo = "stevencm199@gmail.com", cedula = 207950858, p_apellido = "Castro", s_apellido = "Medina", contraseña = "123456", telefono = 84261892}

        };
        
        public IEnumerable<Item> GetItems() //Obtiene objetos del repositorio
        {
            return items;
        }
        public Item GetItem(Guid id) //Obtiene objetos del repositorio por id 
        {
            return items.Where(item => item.Id == id).SingleOrDefault();
        }

        public void CreateItem(Item item)  //Anade objetos al repositorio
        {
            items.Add(item);
        }

        public void UpdateItem(Item item) //Actualiza objetos al repositorio
        {
            var index = items.FindIndex(existingItem => existingItem.Id == item.Id); 
            items[index] = item;
        }

        public void DeleteItem(Guid id) //Borrar objetos del repositorio
        {
            var index = items.FindIndex(existingItem => existingItem.Id == id);
            items.RemoveAt(index);
            
        }
    }


}