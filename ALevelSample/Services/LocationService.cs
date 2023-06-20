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
using Microsoft.Extensions.Logging;

namespace ALevelSample.Services
{
    public class LocationService : BaseDataService<ApplicationDbContext>, ILocationService
    {
        private readonly ILocationRepository _locationRepository;
        private readonly ILogger<LocationService> _loggerService;

        public LocationService(
        IDbContextWrapper<ApplicationDbContext> dbContextWrapper,
        ILogger<BaseDataService<ApplicationDbContext>> logger,
        ILocationRepository locationRepository,
        ILogger<LocationService> loggerService)
        : base(dbContextWrapper, logger)
        {
            _locationRepository = locationRepository;
            _loggerService = loggerService;
        }

        public async Task<int> AddLocation(string firstName)
        {
            return await ExecuteSafeAsync(async () =>
            {
                var id = await _locationRepository.AddLocationAsync(firstName);
                _loggerService.LogInformation($"Created location with Id = {id}");
                return id;
            });
        }

        public async Task<Location> GetLocation(int id)
        {
            var location = await _locationRepository.GetLocationAsync(id);

            if (location == null)
            {
                _loggerService.LogWarning($"Not founded location with Id = {id}");
                return null!;
            }

            return new Location()
            {
                Id = location.Id,
                LocationName = location.LocationName,
            };
        }

        public async Task<Location> UpdateLocation(Location oldLocation, string updateName)
        {
            var location = await _locationRepository.UpdateLocationAsync(oldLocation.Id, updateName);

            if (location == null)
            {
                _loggerService.LogWarning($"Not founded location with Id = {oldLocation.Id}");
                return null!;
            }

            _loggerService.LogWarning($"Update location name {oldLocation.LocationName} to {location.LocationName}");
            return new Location()
            {
                Id = location.Id,
                LocationName = location.LocationName
            };
        }
    }
}
