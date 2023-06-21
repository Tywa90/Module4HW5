using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ALevelSample.Data.Entities;
using ALevelSample.Data;
using ALevelSample.Repositories.Abstractions;
using ALevelSample.Services.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace ALevelSample.Repositories
{
    public class Task2QueryRepository : ITask2QueryRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public Task2QueryRepository(
        IDbContextWrapper<ApplicationDbContext> dbContextWrapper)
        {
            _dbContext = dbContextWrapper.DbContext;
        }

        public async Task<List<Task2QueryEntity>> RunTask2Async(string locationName)
        {
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
               .Where(pet => pet.Age > 3 && EF.Functions.Like(pet.LocationName!, $"%{locationName}%"))
               .GroupBy(pet => new
               {
                   pet.CategoryName,
                   pet.BreedName
               })
               .Select(g => new Task2QueryEntity
               {
                   BreedName = g.Key.BreedName,
                   CountNames = g.Count(),
               })
               .ToListAsync();

            return query;
        }
    }
}
