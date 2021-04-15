using System;

namespace Catalog.Entities
{
    public record Item  // record Types  ( use for immutable Objects, "With" expression support, and value-based equality supports)
    {
            public Guid Id { get; init; }  // after the Creation you can No longer modifie (init) Properties
            public string Name { get; init; }
            public decimal Price { get; init; }
            public DateTimeOffset CreatedDate { get; init; }
    }
}