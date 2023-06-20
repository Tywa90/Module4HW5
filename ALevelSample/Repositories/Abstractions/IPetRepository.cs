using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ALevelSample.Data.Entities;
using ALevelSample.Models;

namespace ALevelSample.Repositories.Abstractions
{
    public interface IPetRepository
    {
        Task<string> AddPetAsync(string petName, int age, string url, string description);
        Task<PetEntity?> GetPetAsync(string id);
    }
}
