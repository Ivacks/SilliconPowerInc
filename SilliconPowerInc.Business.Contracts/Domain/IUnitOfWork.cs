using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SilliconPowerInc.Business.Contracts.Domain
{
    public interface IUnitOfWork<Context> where Context : DbContext
    {
        Task SaveAsync(CancellationToken cancellationToken);
    }
}
