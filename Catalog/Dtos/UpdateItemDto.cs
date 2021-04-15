using System;
using System.ComponentModel.DataAnnotations;

namespace Catalog.Dtos  //-- Data Transfer obj (DTO's) "Contract between Client and service"
{
  public record UpdateItemDto  // record Types  ( use for immutable Objects, "With" expression support, and value-based equality supports)
    { 
            [Required]
            public string Name { get; init; }

            [Required]
            [Range(1,1000)]       
            public decimal Price { get; init; }
          
    }
}