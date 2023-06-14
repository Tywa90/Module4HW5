using System.Collections.Generic;
using ALevelSample.Data.Entities;

namespace ALevelSample.Models;

public class Breed
{
    public int Id { get; set; }

    public string? BreedName { get; set; }

    public int CategoryId { get; set; }
    public Category? Category { get; set; }
}