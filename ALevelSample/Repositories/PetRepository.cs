using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ALevelSample.Data;
using ALevelSample.Data.Entities;
using ALevelSample.Models;
using ALevelSample.Repositories.Abstractions;
using ALevelSample.Services.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace ALevelSample.Repositories
{
    public class PetRepository : IPetRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public PetRepository(
        IDbContextWrapper<ApplicationDbContext> dbContextWrapper)
        {
            _dbContext = dbContextWrapper.DbContext;
        }

        public async Task<string> AddPetAsync(string petName, int age, string url, string description)
        {
            var pet = new PetEntity()
            {
                Id = Guid.NewGuid().ToString(),
                Name = petName,
                CategoryId = _dbContext.Breeds.Where(b => b.Id > 0).Select(b => b.CategoryId).FirstOrDefault(),
                BreedID = _dbContext.Breeds.Where(b => b.Id > 0).Select(b => b.Id).FirstOrDefault(),
                Age = age,
                LocationId = _dbContext.Location.Where(b => b.Id > 0).Select(b => b.Id).FirstOrDefault(),
                ImageUrl = url,
                Description = description
            };

            await _dbContext.Pets.AddAsync(pet);
            await _dbContext.SaveChangesAsync();

            return pet.Id;
        }

        public async Task<PetEntity?> GetPetAsync(string id)
        {
            return await _dbContext.Pets.FirstOrDefaultAsync(f => f.Id == id);
        }
    }
}
