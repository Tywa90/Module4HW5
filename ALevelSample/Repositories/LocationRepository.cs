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
    public class LocationRepository : ILocationRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public LocationRepository(
        IDbContextWrapper<ApplicationDbContext> dbContextWrapper)
        {
            _dbContext = dbContextWrapper.DbContext;
        }

        public async Task<int> AddLocationAsync(string locationName)
        {
            var location = new LocationEntity()
            {
                Id = Guid.NewGuid().GetHashCode(),
                LocationName = locationName
            };

            await _dbContext.Location.AddAsync(location);
            await _dbContext.SaveChangesAsync();

            return location.Id;
        }
    }
}
