using System;
using System.Linq;
using System.Threading.Tasks;
using ALevelSample.Data;
using ALevelSample.Models;
using Microsoft.EntityFrameworkCore;

namespace ALevelSample;

public class App
{
    private readonly ApplicationDbContext _dbContext;

    public App(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task Start()
    {
        /*var data = await _dbContext.Pets.ToListAsync();*/
        var query = await _dbContext.Pets
            .Join(_dbContext.Category, p => p.CategoryId, c => c.Id, (p, c) => new
            {
                CategoryName = c.CategoryName,
                Age = p.Age,
                BreedID = p.BreedID,
                LocationId = p.LocationId,
            })
            .Join(_dbContext.Breeds, d => d.BreedID, b => b.Id, (d, b) => new
            {
                CategoryName = d.CategoryName,
                Age = d.Age,
                BreedName = b.BreedName,
                LocationId = d.LocationId,
            })
            .Join(_dbContext.Location, e => e.LocationId, l => l.Id, (e, l) => new
            {
                CategoryName = e.CategoryName,
                Age = e.Age,
                BreedName = e.BreedName,
                LocationName = l.LocationName,
            })
            .Where(pet => pet.Age > 3 && EF.Functions.Like(pet.LocationName!, "%Ukraine%"))
            .GroupBy(pet => new
            {
                pet.CategoryName, pet.BreedName
            })
            .Select(g => new
            {
                BreedNameCount = g.Key.BreedName,
                Count = g.Count(),
            })
            .ToListAsync();

        foreach (var item in query)
        {
            await Console.Out.WriteLineAsync($"{item}");
        }
    }
}