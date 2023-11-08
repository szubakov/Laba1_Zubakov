using Microsoft.AspNetCore.Mvc;
using APICore.Models;
using APIMVC.Models;
using System.Text.RegularExpressions;
using APIMVC.Services;

//using APIMVC.Models;

namespace APIMVC.Controllers
{
    public class AvtoController : Controller
    {
        private readonly HttpClientService _httpClientService;
        public AvtoController(HttpClientService httpClientService)
        {
            _httpClientService = httpClientService;
        }



        public async Task<IActionResult> Index(ModelsFilterDto filter)
        {

            var models = await _httpClientService.Post<ModelsFilterDto, ModelsGetAllDto>("/Model/GetAll", filter);
            
            var viewmodel = new ModelsViewModel
            {
                Models = models.Models,
                Marks = models.Marks,
                Filter = filter
            };
            return View(viewmodel);
        }

        public async Task<IActionResult> Delete(int id)
        {
            await _httpClientService.Delete($"/Model?id={id}");

            

            return RedirectToAction(nameof(Index));

            //return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(ModelsAddDto models)
        {
            await _httpClientService.Put($"/Model", models);


            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            var model = await GetMod();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(ModelsEditDto model)
        {
            await _httpClientService.Post("/Model", model);

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            using HttpClient client = new HttpClient();

            var model = new ModelsEditViewModel
            {
                Models = await _httpClientService.Get<ModelsGetDto>($"/Model/GetOne?id={id}"),

                Mark = await GetMod()
            };

            return View(model);
        }

        private async Task<List<Marks>> GetMod()
        {
            var model = await _httpClientService.Post<ModelsFilterDto, List<Marks>>("/Mark/GetAll", new ModelsFilterDto());

            return model;
        }

    }
}
