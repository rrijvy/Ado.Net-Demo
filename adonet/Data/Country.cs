using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace adonet.Data
{
    public class Countries
    {
        

        public Country GetCountry(int id)
        {
            Country country = new Country();

            using(SqlConnection connection = DB.GetSqlConnection())
            {
                using(SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = @"sp_GetCountry";
                    command.CommandType = CommandType.StoredProcedure;

                    SqlParameter parameter = new SqlParameter("Id", SqlDbType.Int);
                    parameter.Value = id;

                    command.Parameters.Add(parameter);

                    SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);

                    if (reader.Read())
                    {
                        country.Load(reader);
                    }
                }
            }

            return country;
        }

        public List<Country> GetCountries()
        {
            List<Country> CountryList = new List<Country>();

            using (SqlConnection connection = DB.GetSqlConnection())
            {
                using(SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = @"sp_getAllCountries";
                    command.CommandType = CommandType.StoredProcedure;

                    SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);

                    while (reader.Read())
                    {
                        Country country = new Country();
                        country.Load(reader);

                        CountryList.Add(country);
                    }
                }
            }

            return CountryList;
        }
    }

    public class Country
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public void Load(SqlDataReader reader)
        {
            Id = Int32.Parse(reader["Id"].ToString());
            Name = reader["Name"].ToString();
        }
    }
}