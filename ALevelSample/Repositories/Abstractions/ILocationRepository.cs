using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ALevelSample.Data.Entities;

namespace ALevelSample.Repositories.Abstractions
{
    public interface ILocationRepository
    {
        Task<int> AddLocationAsync(string locationName);
        Task<LocationEntity?> GetLocationAsync(int id);
        Task<LocationEntity?> UpdateLocationAsync(int id, string updateLocation);
    }
}
