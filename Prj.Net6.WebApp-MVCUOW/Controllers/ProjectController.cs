﻿using Microsoft.AspNetCore.Mvc;
using Prj.Net6.Service.DTO;
using Prj.Net6.Service.Services;

namespace Prj.Net6.WebApp_MVCUOW.Controllers
{
    public class ProjectController : Controller
    {
        private readonly ProjectService _service;

        public ProjectController(ProjectService service)
        {
            _service = service;
        }

        // GET: ProjectController
        public async Task<ActionResult> Index()
        {
            var projects = await _service.GetProjectAsync();
            return View(projects);
        }

        // GET: ProjectController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProjectController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CreateAsync(ProjectDTO project)
        {
            try
            {
                await _service.InsertAsync(project);
                await _service.CompletedAsync();

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
