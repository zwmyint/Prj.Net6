using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prj.Net6.Core.Entities
{
    public class Project
    {
        public Guid Id { get; set; }
        public string PName { get; set; }
        public string PDescription { get; set; }

    }
}
