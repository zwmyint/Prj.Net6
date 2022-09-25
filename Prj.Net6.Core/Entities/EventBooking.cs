using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prj.Net6.Core.Entities
{

    public class EventBooking
    {
        [Key]
        public string Id { get; set; }
        public string Email { get; set; }

        [NotMapped]
        public string EventName { get; set; }
        public string EventId { get; set; }
        public Event Event { get; set; }
    }

}
