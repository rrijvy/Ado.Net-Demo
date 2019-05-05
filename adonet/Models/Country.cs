using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace adonet.Models
{
    public class Country
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<Country> GetAll()
        {
            List<Country> countries = new List<Country>();

            try
            {
                SqlConnection sql = new SqlConnection(_connectionString);
                SqlCommand cmd = new SqlCommand("sp_getAllCountries", sql);
                sql.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Country country = new Country
                    {
                        Id = Int32.Parse(reader.GetValue(0).ToString()),
                        Name = reader.GetValue(1).ToString()
                    };
                    countries.Add(country);
                }                
            }
            catch(Exception)
            {
                throw new NotImplementedException();
            }
            
            return countries;
        }

        private string _connectionString = ConfigurationManager.ConnectionStrings["db"].ConnectionString;
    }
}