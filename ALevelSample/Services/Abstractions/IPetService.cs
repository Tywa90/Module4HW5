using System.Threading.Tasks;
using ALevelSample.Data.Entities;
using ALevelSample.Models;

namespace ALevelSample.Services.Abstractions
{
    public interface IPetService
    {
        Task<Pet> GetPet(string id);
    }
}
