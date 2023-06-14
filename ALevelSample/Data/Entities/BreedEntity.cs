using System.Collections.Generic;

namespace ALevelSample.Data.Entities;

public class BreedEntity
{
    public int Id { get; set; }

    public string? BreedName { get; set; }

    public int CategoryId { get; set; }
    public CategoryEntity? Category { get; set; }
    public List<PetEntity> Pet { get; set; } = new List<PetEntity>();
}