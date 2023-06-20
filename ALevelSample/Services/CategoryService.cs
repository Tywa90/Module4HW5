using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ALevelSample.Data;
using ALevelSample.Data.Entities;
using ALevelSample.Models;
using ALevelSample.Repositories;
using ALevelSample.Repositories.Abstractions;
using ALevelSample.Services.Abstractions;
using Microsoft.Extensions.Logging;

namespace ALevelSample.Services
{
    public class CategoryService : BaseDataService<ApplicationDbContext>, ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly ILogger<CategoryService> _loggerService;

        public CategoryService(
        IDbContextWrapper<ApplicationDbContext> dbContextWrapper,
        ILogger<BaseDataService<ApplicationDbContext>> logger,
        ICategoryRepository categoryRepository,
        ILogger<CategoryService> loggerService)
        : base(dbContextWrapper, logger)
        {
            _categoryRepository = categoryRepository;
            _loggerService = loggerService;
        }

        public async Task<int> AddCategory(string categoryName)
        {
            return await ExecuteSafeAsync(async () =>
            {
                var id = await _categoryRepository.AddCategoryAsync(categoryName);
                _loggerService.LogInformation($"Created category with Id = {id}");
                return id;
            });
        }

        public async Task<Category> GetCategory(int id)
        {
            var category = await _categoryRepository.GetCategoryAsync(id);

            if (category == null)
            {
                _loggerService.LogWarning($"Not founded category with Id = {id}");
                return null!;
            }

            return new Category()
            {
                Id = category.Id,
                CategoryName = category.CategoryName,
            };
        }

        public async Task<bool> DeleteCategory(Category category)
        {
            var result = await _categoryRepository.DeleteCategoryAsync(category.Id);

            if (result == false)
            {
                _loggerService.LogWarning($"Not founded category with Id = {category.Id}");
                return false;
            }
            else
            {
                _loggerService.LogWarning($"Category with {category.Id} was deleted!");
                return true;
            }
        }
    }
}
