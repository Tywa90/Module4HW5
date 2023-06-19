using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ALevelSample.Services.Abstractions
{
    public interface ILocationService
    {
        Task<int> AddLocation(string location);
    }
}
