using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ALevelSample.Data.Entities;

namespace ALevelSample.Repositories.Abstractions
{
    public interface IBreedRepository
    {
        Task<int> AddBreedAsync(string breedName, int categoryId);
        Task<BreedEntity?> GetBreedAsync(int id);
    }
}
