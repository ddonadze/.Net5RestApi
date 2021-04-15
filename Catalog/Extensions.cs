using Catalog.Dtos;
using Catalog.Entities;

namespace Catalog
{

    //--Extension Methods using ( DTO data transfer to hide contract exposure)
    public static class Extensions
    {
        public static ItemDto AsDto(this Item item) 
        {
           return new ItemDto
            {
                Id = item.Id,
                Name = item.Name,
                Price = item.Price,
                CreatedDate = item.CreatedDate
            };
        }
    }
}