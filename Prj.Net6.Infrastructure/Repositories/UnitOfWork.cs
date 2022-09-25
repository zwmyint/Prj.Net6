using Microsoft.Extensions.Logging;
using Prj.Net6.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prj.Net6.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly PrjNet6DbContext _context;
        private readonly ILogger _logger;
        
        public IProductRepository Products { get; private set; }
        public IProjectRepository Projects { get; private set; }

        public UnitOfWork(
            PrjNet6DbContext context,
            ILoggerFactory logger)
        {
            _context = context;
            _logger = logger.CreateLogger("logs");

            //Products = new ProductRepository(_context, _logger);
            Projects = new ProjectRepository(_context, _logger);

        }

        public async Task<int> CompletedAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
