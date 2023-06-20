using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ALevelSample.Data;
using ALevelSample.Models;
using ALevelSample.Repositories.Abstractions;
using ALevelSample.Services.Abstractions;
using Microsoft.Extensions.Logging;

namespace ALevelSample.Services
{
    public class BreedService : BaseDataService<ApplicationDbContext>, IBreedService
    {
        private readonly IBreedRepository _breedRepository;
        private readonly ILogger<BreedService> _loggerService;

        public BreedService(
        IDbContextWrapper<ApplicationDbContext> dbContextWrapper,
        ILogger<BaseDataService<ApplicationDbContext>> logger,
        IBreedRepository breedRepository,
        ILogger<BreedService> loggerService)
        : base(dbContextWrapper, logger)
        {
            _breedRepository = breedRepository;
            _loggerService = loggerService;
        }

        public async Task<int> AddBreed(string breedName, int categoryId)
        {
            return await ExecuteSafeAsync(async () =>
            {
                var id = await _breedRepository.AddBreedAsync(breedName, categoryId);
                _loggerService.LogInformation($"Created breed with Id = {id}");
                return id;
            });
        }

        public async Task<Breed> GetBreed(int id)
        {
            var breed = await _breedRepository.GetBreedAsync(id);

            if (breed == null)
            {
                _loggerService.LogWarning($"Not founded breed with Id = {id}");
                return null!;
            }

            return new Breed()
            {
                Id = breed.Id,
                BreedName = breed.BreedName,
            };
        }
    }
}
