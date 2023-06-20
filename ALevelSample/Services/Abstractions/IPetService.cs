using System.Threading.Tasks;
using ALevelSample.Data.Entities;
using ALevelSample.Models;

namespace ALevelSample.Services.Abstractions
{
    public interface IPetService
    {
        Task<string> AddPet(string petName, int age, string url, string description);
        Task<Pet> GetPet(string id);
    }
}
