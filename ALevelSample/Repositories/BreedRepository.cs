using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ALevelSample.Repositories.Abstractions;
using ALevelSample.Data.Entities;
using ALevelSample.Data;
using ALevelSample.Services.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace ALevelSample.Repositories
{
    public class BreedRepository : IBreedRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public BreedRepository(
        IDbContextWrapper<ApplicationDbContext> dbContextWrapper)
        {
            _dbContext = dbContextWrapper.DbContext;
        }

        public async Task<int> AddBreedAsync(string breedName, int categoryId)
        {
            var breed = new BreedEntity()
            {
                Id = Guid.NewGuid().GetHashCode(),
                BreedName = breedName,
                CategoryId = categoryId
            };

            await _dbContext.Breeds.AddAsync(breed);
            await _dbContext.SaveChangesAsync();

            return breed.Id;
        }

        public async Task<BreedEntity?> GetBreedAsync(int id)
        {
            return await _dbContext.Breeds.FirstOrDefaultAsync(f => f.Id == id);
        }
    }
}
