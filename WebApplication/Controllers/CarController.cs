using Microsoft.AspNetCore.Mvc;
using WebApplication.Services.Contracts;

namespace WebApplication.Controllers
{
    public class CarController : Controller
    {
        private readonly ICarService _carService;

        public CarController(ICarService carService)
        {
            _carService = carService;
        }

        public async Task<IActionResult> Car(int id)
        {
            var model = await _carService.GetAsync(id);
            return View("SingleCar", model);
        }
    }
}
