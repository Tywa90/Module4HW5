using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ALevelSample.Models;

namespace ALevelSample.Services.Abstractions
{
    public interface INotificationService
    {
        void Notify(NotifyType type, string massage, string to);
    }
}
