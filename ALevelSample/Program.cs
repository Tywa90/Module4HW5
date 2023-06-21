using ALevelSample;
using ALevelSample.Data;
using ALevelSample.Repositories;
using ALevelSample.Repositories.Abstractions;
using ALevelSample.Services;
using ALevelSample.Services.Abstractions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

void ConfigureServices(ServiceCollection serviceCollection, IConfiguration configuration)
{
    var connectionString = configuration.GetConnectionString("DefaultConnection");
    serviceCollection.AddDbContextFactory<ApplicationDbContext>(opts
        => opts.UseSqlServer(connectionString));
    serviceCollection.AddScoped<IDbContextWrapper<ApplicationDbContext>, DbContextWrapper<ApplicationDbContext>>();

    serviceCollection
        .AddLogging(configure => configure.AddConsole())
        .AddTransient<IPetService, PetService>()
        .AddTransient<IPetRepository, PetRepository>()
        .AddTransient<ILocationService, LocationService>()
        .AddTransient<ILocationRepository, LocationRepository>()
        .AddTransient<ICategoryService, CategoryService>()
        .AddTransient<ICategoryRepository, CategoryRepository>()
        .AddTransient<IBreedService, BreedService>()
        .AddTransient<IBreedRepository, BreedRepository>()
        .AddTransient<ITask2QueryService, Task2QueryService>()
        .AddTransient<ITask2QueryRepository, Task2QueryRepository>()
        .AddTransient<App>();
}

IConfiguration configuration = new ConfigurationBuilder()
    .AddJsonFile("config.json")
    .Build();

var serviceCollection = new ServiceCollection();
ConfigureServices(serviceCollection, configuration);
var provider = serviceCollection.BuildServiceProvider();

var migrationSection = configuration.GetSection("Migration");
var isNeedMigration = migrationSection.GetSection("IsNeedMigration");

// It could be possible variant for production code
// BUT need to be careful and don't run extra migration
if (bool.Parse(isNeedMigration.Value))
{
    var dbContext = provider.GetService<ApplicationDbContext>();
    await dbContext!.Database.MigrateAsync();
}

var app = provider.GetService<App>();
await app!.Start();