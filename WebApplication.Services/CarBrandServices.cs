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
    public class CarBrandServices : ICarBrandServices
    {
        private const string ConnectionString = "Data Source=DESKTOP-GFP7061\\SQLEXPRESS; " +
            "Initial Catalog= ibor; Integrated Security=SSPI; MultipleActiveResultSets=true; " +
            "Connection Timeout=10;TrustServerCertificate=True";
        public async Task<List<CarBrandViewModel>> GetAllCarsBrandAsync()
        {
            string SQL = "Select ID, Name, Picture FROM marki";
            SqlConnection conn =  new SqlConnection(ConnectionString);
            SqlCommand command = new SqlCommand(SQL, conn);
            conn.Open();
            SqlDataReader reader = await command.ExecuteReaderAsync();
            var result = new List<CarBrandViewModel>();
            try
            {
                while(reader.Read())
                {
                    var carBrandViewModel = new CarBrandViewModel
                    {
                        ID = reader.GetInt32(0),
                        Name = reader.GetString(1),
                        Picture = (byte[])reader.GetValue(2)
                    };
                    result.Add(carBrandViewModel);
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
