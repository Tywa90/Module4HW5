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

        public async Task<LocationEntity?> GetLocationAsync(int id)
        {
            return await _dbContext.Location.FirstOrDefaultAsync(f => f.Id == id);
        }

        public async Task<LocationEntity?> UpdateLocationAsync(int id, string updateLocation)
        {
            var location = await _dbContext.Location.FirstOrDefaultAsync(f => f.Id == id);

            if (location != null)
            {
                location.LocationName = updateLocation;
                _dbContext.Location.Update(location);
                _dbContext.SaveChanges();
            }

            return location;
        }
    }
}
