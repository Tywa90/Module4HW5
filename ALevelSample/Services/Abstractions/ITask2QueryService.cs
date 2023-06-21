using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using System.Threading.Tasks;
using ALevelSample.Models;

namespace ALevelSample.Services.Abstractions
{
    public interface ITask2QueryService
    {
        Task<IReadOnlyList<Task2Query>> RunTask2(string locationName);
    }
}
