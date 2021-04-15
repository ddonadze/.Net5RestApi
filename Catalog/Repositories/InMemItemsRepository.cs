using System;
using System.Collections.Generic;
using System.Linq;
using Catalog.Entities;

namespace Catalog.Repositories 
{
    public class InMemItemsRepository : IItemsRepository
    {
        private readonly List<Item> items = new()
        {
            new Item { Id = Guid.NewGuid(), Name = "MineCraft", Price = 20, CreatedDate = DateTimeOffset.UtcNow },
            new Item { Id = Guid.NewGuid(), Name = "CallOfDuty", Price = 30, CreatedDate = DateTimeOffset.UtcNow },
            new Item { Id = Guid.NewGuid(), Name = "RoBlox", Price = 10, CreatedDate = DateTimeOffset.UtcNow },
        };

        //--Get List of Items
        public IEnumerable<Item> GetItems()
        {
            return items;
        }
        //--Get Item 
        public Item GetItem(Guid id)
        {
            return items.Where(i => i.Id == id).SingleOrDefault();
        }
        //--Post Items
        public void CreateItem(Item item)
        {
            items.Add(item);
        }
        //--Put Item
        public void UpdateItem(Item item)
        {
            //--sinece item is in the MemoryList we need to find "Index" and update it. 
            var index = items.FindIndex(existingItem => existingItem.Id == item.Id);
            items[index] = item;
        }
        //-- Delete Item
        public void DeleteItem(Guid id)
        {
            var index = items.FindIndex(existingItem => existingItem.Id == id);
            items.RemoveAt(index);
        }
    }

}