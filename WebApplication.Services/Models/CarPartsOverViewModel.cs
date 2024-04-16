using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication.Services.Models
{
    public class CarPartsOverViewModel
    {
        public int PartID { get; set; }
        public string PartName { get; set; }
        public decimal PartPrice { get; set; }
        public string GearboxType { get; set; }
        public int NumofGears { get; set; }
        public string PartDescription { get; set; }
        public byte[] PartPicture { get; set; }
        public string PartCondition { get; set; }
    }
}
