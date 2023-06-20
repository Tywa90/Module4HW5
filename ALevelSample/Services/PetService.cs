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
    public class PetService : BaseDataService<ApplicationDbContext>, IPetService
    {
        private readonly IPetRepository _petRepository;
        private readonly ILogger<PetService> _loggerService;

        public PetService(
        IDbContextWrapper<ApplicationDbContext> dbContextWrapper,
        ILogger<BaseDataService<ApplicationDbContext>> logger,
        IPetRepository petRepository,
        ILogger<PetService> loggerService)
        : base(dbContextWrapper, logger)
        {
            _petRepository = petRepository;
            _loggerService = loggerService;
        }

        public async Task<Pet> GetPet(string id)
        {
            var pet = await _petRepository.GetPetAsync(id);

            if (pet == null)
            {
                _loggerService.LogWarning($"Not founded pet with Id = {id}");
                return null!;
            }

            return new Pet()
            {
                Id = pet.Id,
                Name = pet.Name
            };
        }
    }
}
