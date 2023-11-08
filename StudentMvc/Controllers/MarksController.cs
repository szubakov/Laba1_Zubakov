using Microsoft.AspNetCore.Mvc;
using APICore.Models;
using APIMVC.Models;
using APIMVC.Services;
using System.Collections.Generic;
using System.Reflection;

namespace APIMVC.Controllers
{
    public class MarksController : Controller
    {

        private readonly HttpClientService _httpClientService;
        public MarksController(HttpClientService httpClientService)
        {
            _httpClientService = httpClientService;
        }
        public async Task<IActionResult> Index(MarksFilterDto filter)
        {

            var marks = await _httpClientService.Post<MarksFilterDto, List<Marks>> ("/Mark/GetAll", filter);


            var viewmodel = new MarkViewModel
            {
                Filter = filter,
                Marks = marks
            };
            return View(viewmodel);
        }

        public async Task<IActionResult> Delete(int Id)
        {
            await _httpClientService.Delete($"/Mark?Id={Id}");

            return RedirectToAction(nameof(Index));

            //return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(string name)
        {
            var group = new Marks { Name = name };
            await _httpClientService.Put($"/Mark", group);

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, string name)
        {

            var group = new Marks { Id = id, Name = name };

            await _httpClientService.Post("/Mark", group);

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var model = await _httpClientService.Get<Marks>($"/Mark/GetOne?id={id}");

            return View(model);
        }
    }
}
