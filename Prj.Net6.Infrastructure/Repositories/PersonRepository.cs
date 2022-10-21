using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Prj.Net6.Core.Entities;
using Prj.Net6.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prj.Net6.Infrastructure.Repositories
{
    public class PersonRepository : GenericRepository<Person>, IPersonRepository
    {
        protected readonly PrjNet6DbContext _context2;
        protected readonly ILogger _logger2;

        public PersonRepository(PrjNet6DbContext context, ILogger logger) : base(context, logger)
        {
            _context2 = context;
            _logger2 = logger;
        }

        public async Task<IEnumerable<Person>> GetAdultPersonsAsync()
        {
            return await _context2.Person.Where(pers => pers.Age >= 18).ToListAsync();
        }
    }
}
