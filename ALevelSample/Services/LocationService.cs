﻿using System;
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
    public class LocationService : BaseDataService<ApplicationDbContext>, ILocationService
    {
        private readonly ILocationRepository _locationRepository;
        private readonly INotificationService _notificationService;
        private readonly ILogger<LocationService> _loggerService;

        public LocationService(
        IDbContextWrapper<ApplicationDbContext> dbContextWrapper,
        ILogger<BaseDataService<ApplicationDbContext>> logger,
        ILocationRepository locationRepository,
        INotificationService notificationService,
        ILogger<LocationService> loggerService)
        : base(dbContextWrapper, logger)
        {
            _locationRepository = locationRepository;
            _notificationService = notificationService;
            _loggerService = loggerService;
        }

        public async Task<int> AddLocation(string firstName)
        {
            return await ExecuteSafeAsync(async () =>
            {
                var id = await _locationRepository.AddLocationAsync(firstName);
                _loggerService.LogInformation($"Created location with Id = {id}");
                var notifyMassage = "registration was successful";
                var notifyTo = "user@gmail.com";
                _notificationService.Notify(NotifyType.Email, notifyMassage, notifyTo);
                return id;
            });
        }
    }
}