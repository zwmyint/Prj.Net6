using Microsoft.AspNetCore.Mvc;
using Prj.Net6.Service.Services;
using Prj.Net6.Service.ViewModel;

namespace Prj.Net6.WebApp_MVC.Controllers
{
    public class EventController : Controller
    {
        private readonly EventService _eventService;

        public EventController(EventService eventService)
        {
            _eventService = eventService;
        }


        // GET: EventController
        public async Task<ActionResult> Index()
        {
            var events = await _eventService.GetAllAsync();
            return View(events);
        }

        // GET: EventController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EventController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CreateAsync([Bind("Name,Location,Date")] EventViewModel eventViewModel)
        {
            try
            {
                //var add = await _eventService.Add(eventViewModel);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: EventController/Edit/5
        public async Task<ActionResult> Edit(Guid id)
        {
            var _event = await _eventService.GetById(id);
            return View(_event);
        }

        // POST: EventController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(string id, [Bind("Name,Location,Date")] EventViewModel eventViewModel)
        {
            try
            {
                //bool upate = await _eventService.Update(eventViewModel);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: EventController/Delete/5
        public async Task<ActionResult> Delete(Guid id)
        {
            var _event = await _eventService.GetById(id);
            return View(_event);
        }

        // POST: EventController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(string id, IFormCollection collection)
        {
            try
            {
                //bool delete = await _eventService.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }


        //
    }
}
