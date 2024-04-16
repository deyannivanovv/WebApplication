using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication.Services.Models
{
    public class CarOverViewModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Model { get; set; }
        public decimal Price { get; set; }
        public byte[] Picture { get; set; }
        public string cartype { get; set; }
        public DateTime Year { get; set; }
        public string Fuel { get; set; }
        public string Specs { get; set; }
        public string Description { get; set; }
        public int Horsepower { get; set; }
        public int Cub_capacity { get; set; }
        public int Car_mileage { get; set; }
        public string Color { get; set; }
        public string Gearbox { get; set; }
        public List<Byte[]> Pictures { get; set; }
    }
}
