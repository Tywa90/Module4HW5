using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ALevelSample.Models;

namespace ALevelSample.Services.Abstractions
{
    public interface ICategoryService
    {
        Task<int> AddCategory(string category);
        Task<Category> GetCategory(int id);
        Task<bool> DeleteCategory(Category category);
    }
}
