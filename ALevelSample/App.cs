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
    private readonly ITask2QueryService _task2QueryService;

    public App(
        ILocationService locationService,
        ICategoryService categoryService,
        IBreedService breedService,
        IPetService petService,
        ITask2QueryService task2QueryService)
    {
        _locationService = locationService;
        _categoryService = categoryService;
        _breedService = breedService;
        _petService = petService;
        _task2QueryService = task2QueryService;
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

        var petId = await _petService.AddPet("Reks", 8, "www.pet.com", "Some description");

        var getCategory = await _categoryService.GetCategory(categoryId1);
        var deleteCategory = await _categoryService.DeleteCategory(getCategory);

        var newQuery = await _task2QueryService.RunTask2(locationName);
    }
}