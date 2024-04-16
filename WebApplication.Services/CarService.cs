using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;
using WebApplication.Services.Contracts;
using WebApplication.Services.Models;

namespace WebApplication.Services
{
    public class CarService : ICarService

    {
        private const string ConnectionString = "Data Source=DESKTOP-GFP7061\\SQLEXPRESS; Initial Catalog= ibor; " +
            "Integrated Security=SSPI; MultipleActiveResultSets=true; Connection Timeout=10;TrustServerCertificate=True";

        public async Task<List<CarOverViewModel>> GetAllCarsOverViewAsync()
        {
            string SQL = @"Select o.ID, m.Name, o.Model, o.Price,  op.Picture, o.cartype                          
                         FROM obqvi o 
                         LEFT JOIN obqvi_pictures op ON op.ObqvaID=o.ID and op.isdefault=1
                         LEFT JOIN marki m ON m.ID = o.marki_ID";
            SqlConnection conn = new SqlConnection(ConnectionString);
            SqlCommand command = new SqlCommand(SQL, conn);
            conn.Open();
            SqlDataReader reader = await command.ExecuteReaderAsync();
            var result = new List<CarOverViewModel>();
            try
            {
                while (reader.Read())
                {
                    var carOverViewModel = new CarOverViewModel
                    {
                        ID = reader.GetInt32(0),
                        Name = reader.GetString(1),
                        Model = reader.GetString(2),
                        Price = reader.GetDecimal(3),
                        Picture = (byte[])reader.GetValue(4),
                        cartype = reader.GetString(5),                        
                    };
                    result.Add(carOverViewModel);
                }
            }
            finally
            {
                reader.Close();
                conn.Close();
            }
            return result.DistinctBy(r => r.ID).ToList();
        }
        public async Task<CarOverViewModel> GetAsync(int carid)
        {
            string SQL = @$"Select o.ID, m.Name, o.Model, o.Price, o.cartype, o.Year, o.Fuel, o.Specs,
                         o.Description, o.Horsepower, o.Cub_capacity, o.Car_mileage, o.Color, o.Gearbox FROM obqvi o
                         LEFT JOIN obqvi_pictures op ON op.ObqvaID=o.ID
                         LEFT JOIN marki m ON m.ID = o.marki_ID
                         WHERE op.ObqvaID = {carid}";

            SqlConnection conn = new SqlConnection(ConnectionString);
            SqlCommand command = new SqlCommand(SQL, conn);
            conn.Open();
            SqlDataReader reader = await command.ExecuteReaderAsync();
            var result = new CarOverViewModel();
            try
            {
                while (reader.Read())
                {
                    result = new CarOverViewModel
                    {
                        ID = reader.GetInt32(0),
                        Name = reader.GetString(1),
                        Model = reader.GetString(2),
                        Price = reader.GetDecimal(3),
                        cartype = reader.GetString(4),
                        Year = reader.GetDateTime(5),
                        Fuel = reader.GetString(6),
                        Specs = reader.GetString(7),
                        Description = reader.GetString(8),
                        Horsepower = reader.GetInt32(9),
                        Cub_capacity = reader.GetInt32(10),
                        Car_mileage = reader.GetInt32(11),
                        Color = reader.GetString(12),
                        Gearbox = reader.GetString(13)
                    };
                }
            }
            finally
            {
                reader.Close();
                conn.Close();
            }
            GetPictures(result);
            return result;
        }
            public void GetPictures(CarOverViewModel model)
            {
                // Connection and SQL strings
                string SQL = $@"SELECT op.Picture
                FROM obqvi_pictures op
                JOIN obqvi o ON o.ID = op.ObqvaID                
                WHERE o.ID = {model.ID}";

                // create a connection object
                SqlConnection conn = new SqlConnection(ConnectionString);

                // create command object
                SqlCommand cmd = new SqlCommand(SQL, conn);

                // open connection
                conn.Open();

                // call command's ExcuteReader
                SqlDataReader reader = cmd.ExecuteReader();
                var result = new List<byte[]>();
                try
                {
                    while (reader.Read())
                    {
                        var picture = (byte[])reader.GetValue(0);
                        result.Add(picture);
                    }
                }
                finally
                {
                    // close reader and connection
                    reader.Close();
                    conn.Close();
                }
                model.Pictures = result;
            }
        }

    }
    


