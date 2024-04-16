using Microsoft.AspNetCore.Mvc;
using WebApplication.Services.Contracts;

namespace WebApplication.Controllers
{
    public class SinglePartController : Controller
    {
        private readonly IPartService _partService;

        public SinglePartController(IPartService partService)
        {
            _partService = partService;
        }

        public async Task<IActionResult> SinglePart(int partid)
        {
            var model = await _partService.GetAsync(partid);
            return View(model);
        }
    }
}
