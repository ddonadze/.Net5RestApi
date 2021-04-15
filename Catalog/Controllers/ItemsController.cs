using Catalog.Entities;
using System.Collections.Generic;
using Catalog.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using Catalog.Dtos;

namespace Catalog.Controllers
{
    [ApiController]
    [Route("items")]
    public class ItemsController: ControllerBase 
    {
        private readonly IItemsRepository repository;

        public ItemsController(IItemsRepository repository){
            this.repository = repository;
        }

        //--GET /Items
        [HttpGet]
        public IEnumerable<ItemDto> GetItems()
        {
            var items = repository.GetItems().Select(item => item.AsDto());

            return items;
        }

        //--GET /Items/id
        [HttpGet("{id}")]
        public ActionResult<ItemDto> GetItem(Guid id) //--ActionResult<> allows more then one type return
        {
            var item = repository.GetItem(id);

            if(item is null){
                return NotFound();
            }
            return item.AsDto();
        }

        //--POST /Items
        [HttpPost]
        public ActionResult<ItemDto> CreateItem(CreateItemDto itemDto)
        {
            Item item = new(){
                Id = Guid.NewGuid(),
                Name = itemDto.Name,
                Price = itemDto.Price,
                CreatedDate = DateTimeOffset.UtcNow
            };

                repository.CreateItem(item);

            return CreatedAtAction(nameof(GetItem), new {id = item.Id}, item.AsDto());
        }

        //--PUT /Items/id
        [HttpPut("{id}")]
        public ActionResult UpdateItem(Guid id, UpdateItemDto itemDto)
        {
            var existingItem = repository.GetItem(id);

            if(existingItem is null){
                return  NotFound();
            }

            //  using "with" we allowing existing praperties to copy new modified properties with new values,
            //  we can modifie imutable properties on inicialisation.
            Item UpdatedItem = existingItem with {
                Name = itemDto.Name, 
                Price = itemDto.Price
            };

            repository.UpdateItem(UpdatedItem);

            return NoContent();
        }

        //-- Delete /items/id
        [HttpDelete("{id}")]
        public ActionResult DeleteItem(Guid id)
        {

            var existingItem = repository.GetItem(id);

            if(existingItem is null){
                return  NotFound();
            }

            repository.DeleteItem(id);
            return NoContent();
        }

    }
}