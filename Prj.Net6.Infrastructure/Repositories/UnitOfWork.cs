using Microsoft.EntityFrameworkCore.Storage;
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
        private IDbContextTransaction _transaction;
        private readonly ILogger _logger;
        
        public IProductRepository Products { get; private set; }
        public IProjectRepository Projects { get; private set; }

        //
        public IAddressRepository Address { get; private set; }
        public IEmailRepository Email { get; private set; }
        public IPersonRepository Persons { get; private set; }


        public UnitOfWork(PrjNet6DbContext context, ILoggerFactory logger)
        {
            _context = context;
            _logger = logger.CreateLogger("logs");

            //Products = new ProductRepository(_context, _logger);
            Projects = new ProjectRepository(_context, _logger);

            //Address = new AddressRepository(_context, _logger);
            //Email = new EmailRepository(_context, _logger);
            Persons = new PersonRepository(_context, _logger);

        }

        public async Task<int> CompletedAsync()
        {
            return await _context.SaveChangesAsync();
        }

        //
        public async Task<int> CompleteAsync(CancellationToken cancellationToken = default)
        {
            return await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task BeginTransactionAsync(CancellationToken cancellationToken = default)
        {
            _transaction = await _context.Database.BeginTransactionAsync(cancellationToken);
        }

        public async Task CommitTransactionAsync(CancellationToken cancellationToken = default)
        {
            await _transaction.CommitAsync(cancellationToken);
        }

        public void Dispose()
        {
            _transaction?.Dispose();
            _context.Dispose();
        }
    }
}
