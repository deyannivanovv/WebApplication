using WebApplication.Services.Models;

namespace WebApplication.Models
{
    public class HomeViewModel
    {
        public List<CarBrandViewModel> CarBrands { get; set; } = new();
        public List<CarOverViewModel> Cars { get; set; } = new();
        public List<CarPartsOverViewModel> Parts { get; set; } = new();
    }
}
