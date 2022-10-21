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
    public class EmailRepository : GenericRepository<Email>, IEmailRepository
    {
        public EmailRepository(PrjNet6DbContext context, ILogger logger) : base(context, logger)
        {
        }
    }
}
