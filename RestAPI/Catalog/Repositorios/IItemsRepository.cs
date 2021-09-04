using System;
using System.Collections.Generic;
using Catalog.Entities;

namespace Catalog.Repositorios
{
//clase necesaria para la inyeccion de dependencia
   public interface IItemsRepository
    {
        Item GetItem(Guid id); //GET/{id} request
        IEnumerable<Item> GetItems();//GET request 
        void CreateItem(Item item); //POST request
        void UpdateItem(Item item); //PUT request
        void DeleteItem(Guid id); //DELETE request
    }


}