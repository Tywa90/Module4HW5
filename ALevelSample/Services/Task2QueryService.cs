using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ALevelSample.Services.Abstractions;
using ALevelSample.Data;
using Microsoft.Extensions.Logging;
using ALevelSample.Repositories.Abstractions;
using ALevelSample.Models;
using ALevelSample.Repositories;

namespace ALevelSample.Services
{
    public class Task2QueryService : BaseDataService<ApplicationDbContext>, ITask2QueryService
    {
        private readonly ITask2QueryRepository _task2QueryRepository;
        private readonly ILogger<Task2QueryService> _loggerService;

        public Task2QueryService(
        IDbContextWrapper<ApplicationDbContext> dbContextWrapper,
        ILogger<BaseDataService<ApplicationDbContext>> logger,
        ITask2QueryRepository task2QueryRepository,
        ILogger<Task2QueryService> loggerService)
        : base(dbContextWrapper, logger)
        {
            _task2QueryRepository = task2QueryRepository;
            _loggerService = loggerService;
        }

        public async Task<IReadOnlyList<Task2Query>> RunTask2(string locationName)
        {
            var result = await _task2QueryRepository.RunTask2Async(locationName);

            if (result == null)
            {
                _loggerService.LogWarning($"error with Task2");
                return null!;
            }

            foreach (var item in result)
            {
                Console.WriteLine($"{item.BreedName} - {item.CountNames}");
            }

            return result.Select(r => new Task2Query()
            {
                BreedName = r.BreedName,
                CountNames = r.CountNames,
            }).ToList();
        }
    }
}
