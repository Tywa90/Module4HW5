namespace ALevelSample.Models;

public class Pet
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public int CategoryId { get; set; }
    public Category? Category { get; set; }
    public int BreedID { get; set; }
    public Breed? Breed { get; set; }
    public float Age { get; set; }
    public int LocationId { get; set; }
    public Location? Location { get; set; }
    public string? ImageUrl { get; set; }
    public string? Description { get; set; }
}