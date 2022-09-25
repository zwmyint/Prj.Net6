using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prj.Net6.Core.Entities
{

    public class Event
    {
        [Key] //mark it as Primary Key
        public string Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }
        public ICollection<EventBooking> EventBooking { get; set; }
    }

}
