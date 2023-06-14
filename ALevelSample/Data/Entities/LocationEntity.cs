using System.Collections.Generic;

namespace ALevelSample.Data.Entities;

public class LocationEntity
{
    public int Id { get; set; }

    public string? LocationName { get; set; }

    public List<PetEntity> Pet { get; set; } = new List<PetEntity>();
}