using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication.Services.Contracts;
using WebApplication.Services.Models;

namespace WebApplication.Services
{
    
    public class CarPartService : IPartService
    {

        private const string ConnectionString = "Data Source=DESKTOP-GFP7061\\SQLEXPRESS; Initial Catalog= ibor; Integrated Security=SSPI; MultipleActiveResultSets=true; Connection Timeout=10;TrustServerCertificate=True";
        public async Task<List<CarPartsOverViewModel>> GetAllCarsPartsOverViewAsync()
        {
            string SQL = "Select PartID, PartName, PartPrice, GearboxType, NumofGears, PartDescription, PartPicture, PartCondition FROM carparts";
            SqlConnection conn = new SqlConnection(ConnectionString);
            SqlCommand command = new SqlCommand(SQL, conn);
            conn.Open();
            SqlDataReader reader = await command.ExecuteReaderAsync();
            var result = new List<CarPartsOverViewModel>();
            try
            {
                while (reader.Read())
                {
                    var carPartViewModel = new CarPartsOverViewModel
                    {
                        PartID = reader.GetInt32(0),
                        PartName = reader.GetString(1),
                        PartPrice = reader.GetDecimal(2),
                        GearboxType = reader.GetString(3),
                        NumofGears = reader.GetInt32(4),
                        PartDescription = reader.GetString(5),
                        PartPicture = (byte[])reader.GetValue(6),
                        PartCondition = reader.GetString(7)
                    };
                    result.Add(carPartViewModel);
                }
            }
            finally
            {
                reader.Close();
                conn.Close();
            }
            return result;
        }

        public async Task<CarPartsOverViewModel> GetAsync(int partid)
        {
            string SQL = $"Select PartID, PartName, PartPrice, GearboxType, NumofGears, PartDescription, PartPicture, PartCondition FROM carparts WHERE PartID={partid}";
            SqlConnection conn = new SqlConnection(ConnectionString);
            SqlCommand command = new SqlCommand(SQL, conn);
            conn.Open();
            SqlDataReader reader = await command.ExecuteReaderAsync();
            var result = new CarPartsOverViewModel();
            try
            {
                while (reader.Read())
                {
                    result = new CarPartsOverViewModel
                    {
                        PartID = reader.GetInt32(0),
                        PartName = reader.GetString(1),
                        PartPrice = reader.GetDecimal(2),
                        GearboxType = reader.GetString(3),
                        NumofGears = reader.GetInt32(4),
                        PartDescription = reader.GetString(5),
                        PartPicture = (byte[])reader.GetValue(6),
                        PartCondition = reader.GetString(7)
                    };
                }
            }
            finally
            {
                reader.Close();
                conn.Close();
            }
            return result;
        }
    }
}
    

