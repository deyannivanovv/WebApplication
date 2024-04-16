using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebApplication.Models;
using WebApplication.Services;
using WebApplication.Services.Contracts;
using WebApplication.Services.Models;

namespace WebApplication.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICarBrandServices _carBrandServices;
        private readonly ICarService _carService;
        private readonly IPartService _partService;

        public HomeController(ICarBrandServices carBrandServices, ICarService carService, IPartService partService)
        {
            _carBrandServices = carBrandServices;
            _carService = carService;
            _partService = partService;
        }
        public async Task<IActionResult> Index(string cartype = null)
        {
            var model = new HomeViewModel();
            model.CarBrands=await _carBrandServices.GetAllCarsBrandAsync();
            model.Cars=await _carService.GetAllCarsOverViewAsync();
            model.Parts=await _partService.GetAllCarsPartsOverViewAsync();
            return View(model);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
