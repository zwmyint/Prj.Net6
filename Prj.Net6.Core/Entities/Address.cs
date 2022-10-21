using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prj.Net6.Core.Entities
{
    public class Address
    {
        public int AddressId { get; set; }
        public string StreetAdress { get; set; }

        public string City { get; set; }
        public string State { get; set; }

        public string ZipCode { get; set; }

    }
}
