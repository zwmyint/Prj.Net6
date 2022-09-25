using Microsoft.AspNetCore.Mvc;
using Prj.Net6.Service.Services;
using Prj.Net6.Service.ViewModel;

namespace Prj.Net6.WebApp_MVC.Controllers
{
    public class EventBookingController : Controller
    {
        private readonly EventService _eventService;
        private readonly EventBookingService _eventBookingService;


        public IActionResult Index()
        {
            return View();
        }

        public EventBookingController(EventService eventService, EventBookingService eventBookingService)
        {
            _eventService = eventService;
            _eventBookingService = eventBookingService;
        }
        
//        // GET: EventBookingController
//        public async Task<ActionResult> Index()
//                {
//                    var bookings = await _eventBookingService.GetAllAsync();
//                    return View(bookings);
//                }
//        ​
//        // GET: EventBookingController/Create
//        public async Task<ActionResult> Create()
//                {
//                    var eventsViewModel = await _eventService.GetAllAsync();
//                    var eventBookingViewModel = new EventBookingViewModel();
//                    eventBookingViewModel.Events = eventsViewModel;
//        ​
//	        return View(eventBookingViewModel);
//        ​
//        }
//​
//        // POST: EventBookingController/Create
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public async Task<ActionResult> Create([Bind("EventId,Email")] EventBookingViewModel eventBookingViewModel)
//        {
//            try
//            {
//                var add = await _eventBookingService.AddEventBooking(eventBookingViewModel);
//                return RedirectToAction(nameof(Index));
//            }
//            catch
//            {
//                return View();
//            }
//        }

    }
}
