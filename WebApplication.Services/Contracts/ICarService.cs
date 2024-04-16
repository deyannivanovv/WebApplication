using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication.Services.Models;

namespace WebApplication.Services.Contracts
{
    public interface ICarService
    {
        Task<List<CarOverViewModel>> GetAllCarsOverViewAsync();
        Task<CarOverViewModel> GetAsync(int id);
    }
}
