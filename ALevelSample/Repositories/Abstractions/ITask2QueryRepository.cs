using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ALevelSample.Data.Entities;

namespace ALevelSample.Repositories.Abstractions
{
    public interface ITask2QueryRepository
    {
        Task<List<Task2QueryEntity>> RunTask2Async(string locationName);
    }
}
