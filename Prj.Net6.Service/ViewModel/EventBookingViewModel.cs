using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prj.Net6.Service.ViewModel
{
    public class EventBookingViewModel
    {
        public string Id { get; set; }
        public string Email { get; set; }
        public string EventName { get; set; }
        [Required]
        public string EventId { get; set; }
        public IEnumerable<EventViewModel> Events { get; set; } // use for dropdown list
    }

}
