using System.Collections.Generic;

namespace ALevelSample.Data.Entities;

public class CategoryEntity
{
    public int Id { get; set; }

    public string? CategoryName { get; set; }

    public List<PetEntity> Pet { get; set; } = new List<PetEntity>();
    public List<BreedEntity> Breed { get; set; } = new List<BreedEntity>();
}