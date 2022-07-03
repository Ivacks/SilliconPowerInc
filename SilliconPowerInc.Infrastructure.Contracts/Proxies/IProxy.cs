using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SilliconPowerInc.Infrastructure.Contracts.Proxies
{
    public interface IProxy<T>
    {
        Task<IEnumerable<T>> GetAllAsync();
    }
}
