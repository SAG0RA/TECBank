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
            new Item { Id = Guid.NewGuid(), Name = "Potion", Price = 9, CreatedDate = System.DateTimeOffset.Now },
            new Item { Id = Guid.NewGuid(), Name = "Iron Sword", Price = 20, CreatedDate = System.DateTimeOffset.Now },
            new Item { Id = Guid.NewGuid(), Name = "Bronze Shield", Price = 18, CreatedDate = System.DateTimeOffset.Now }

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