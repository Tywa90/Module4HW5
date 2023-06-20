using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ALevelSample.Models;

namespace ALevelSample.Services.Abstractions
{
    public interface IBreedService
    {
        Task<int> AddBreed(string firstName, int categoryId);
        Task<Breed> GetBreed(int id);
    }
}
