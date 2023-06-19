using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ALevelSample.Data.Entities;

namespace ALevelSample.Repositories.Abstractions
{
    public interface IPetRepository
    {
        Task<string> AddPetAsync(string firstName);
        Task<PetEntity?> GetPetAsync(string id);
    }
}
