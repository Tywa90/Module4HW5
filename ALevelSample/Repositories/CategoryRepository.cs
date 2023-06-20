using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ALevelSample.Data.Entities;
using ALevelSample.Data;
using ALevelSample.Services.Abstractions;
using ALevelSample.Repositories.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace ALevelSample.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public CategoryRepository(
        IDbContextWrapper<ApplicationDbContext> dbContextWrapper)
        {
            _dbContext = dbContextWrapper.DbContext;
        }

        public async Task<int> AddCategoryAsync(string categoryName)
        {
            var category = new CategoryEntity()
            {
                Id = Guid.NewGuid().GetHashCode(),
                CategoryName = categoryName
            };

            await _dbContext.Category.AddAsync(category);
            await _dbContext.SaveChangesAsync();

            return category.Id;
        }

        public async Task<CategoryEntity?> GetCategoryAsync(int id)
        {
            return await _dbContext.Category.FirstOrDefaultAsync(f => f.Id == id);
        }

        public async Task<bool> DeleteCategoryAsync(int id)
        {
            var category = await _dbContext.Category.FirstOrDefaultAsync(f => f.Id == id);

            if (category == null)
            {
                return false;
            }
            else
            {
                _dbContext.Category.Remove(category);
                _dbContext.SaveChanges();
                return true;
            }
        }
    }
}