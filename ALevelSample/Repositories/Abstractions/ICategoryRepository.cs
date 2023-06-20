using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ALevelSample.Data.Entities;

namespace ALevelSample.Repositories.Abstractions
{
    public interface ICategoryRepository
    {
        Task<int> AddCategoryAsync(string categoryName);
        Task<CategoryEntity?> GetCategoryAsync(int id);
        Task<bool> DeleteCategoryAsync(int id);
    }
}
