using Microsoft.EntityFrameworkCore;
using SilliconPowerInc.Business.Contracts.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SilliconPowerInc.Business.Impl.Domain
{
    public class UnitOfWork<Context> : IUnitOfWork<Context> where Context : DbContext
    {
        private readonly Context _context;

        public UnitOfWork(Context context)
        {
            _context = context;
        }

        public async Task SaveAsync(CancellationToken cancellationToken)
        {
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
