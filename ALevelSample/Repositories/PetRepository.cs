using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ALevelSample.Data;
using ALevelSample.Data.Entities;
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

        public async Task<string> AddPetAsync(string firstName)
        {
            var pet = new PetEntity()
            {
                Id = Guid.NewGuid().ToString(),
                Name = firstName
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
