using System;
using System.Linq;
using System.Threading.Tasks;
using ALevelSample.Data;
using ALevelSample.Data.Entities;
using ALevelSample.Models;
using ALevelSample.Services.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace ALevelSample;

public class App
{
    private readonly ILocationService _locationService;
    private readonly ICategoryService _categoryService;
    private readonly IBreedService _breedService;
    private readonly IPetService _petService;

    public App(
        ILocationService locationService,
        ICategoryService categoryService,
        IBreedService breedService,
        IPetService petService)
    {
        _locationService = locationService;
        _categoryService = categoryService;
        _breedService = breedService;
        _petService = petService;
    }

    public async Task Start()
    {
        var locationName = "Ukraine";
        var locationId = await _locationService.AddLocation(locationName);

        var location = await _locationService.GetLocation(locationId);
        var updateLocation = await _locationService.UpdateLocation(location, "Spain");

        var categoryId1 = await _categoryService.AddCategory("Dog");
        var categoryId2 = await _categoryService.AddCategory("Cat");

        var breedId1 = await _breedService.AddBreed("Mops", categoryId1);
        var breedId2 = await _breedService.AddBreed("Scotish", categoryId2);

        var breed = await _breedService.GetBreed(breedId1);

        var petId = await _petService.AddPet("Reks",  8, "www.pet.com", "Some description");

        var getCategory = await _categoryService.GetCategory(categoryId1);
        var deleteCategory = await _categoryService.DeleteCategory(getCategory);

        // var query = await _dbContext.Pets
        //    .Join(_dbContext.Category, p => p.CategoryId, c => c.Id, (p, c) => new
        //    {
        //        CategoryName = c.CategoryName,
        //        Age = p.Age,
        //        BreedID = p.BreedID,
        //        LocationId = p.LocationId,
        //    })
        //    .Join(_dbContext.Breeds, d => d.BreedID, b => b.Id, (d, b) => new
        //    {
        //        CategoryName = d.CategoryName,
        //        Age = d.Age,
        //        BreedName = b.BreedName,
        //        LocationId = d.LocationId,
        //    })
        //    .Join(_dbContext.Location, e => e.LocationId, l => l.Id, (e, l) => new
        //    {
        //        CategoryName = e.CategoryName,
        //        Age = e.Age,
        //        BreedName = e.BreedName,
        //        LocationName = l.LocationName,
        //    })
        //    .Where(pet => pet.Age > 3 && EF.Functions.Like(pet.LocationName!, "%Ukraine%"))
        //    .GroupBy(pet => new
        //    {
        //        pet.CategoryName, pet.BreedName
        //    })
        //    .Select(g => new
        //    {
        //        BreedNameCount = g.Key.BreedName,
        //        Count = g.Count(),
        //    })
        //    .ToListAsync();
    }
}