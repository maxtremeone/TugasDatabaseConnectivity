using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;

namespace DatabaseConnectivity.Models;
public class Location
{
    public int Id { get; set; }
    public string StreetAddress { get; set; }
    public string PostalCode { get; set; }
    public string City { get; set; }
    public string StateProvince { get; set; }
    public string CountryId { get; set; }

    public List<Location> GetAll()
    {
        var connection = Connection.Get();

        var locations = new List<Location>();

        using SqlCommand sqlCommand = new SqlCommand();
        sqlCommand.Connection = connection;
        sqlCommand.CommandText = "SELECT * FROM locations";

        try
        {
            connection.Open();
            using SqlDataReader reader = sqlCommand.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Location location = new Location();
                    location.Id = reader.GetInt32(0);
                    location.StreetAddress = reader.GetString(1);
                    location.PostalCode = reader.GetString(2);
                    location.City = reader.GetString(3);
                    location.StateProvince = reader.GetString(4);
                    location.CountryId = reader.GetString(5);

                    locations.Add(location);
                }
            }
            else
            {
                reader.Close();
                connection.Close();
            }

            return locations;
        }
        catch
        {
            return new List<Location>();
        }
    }


    public int Insert(Location location)
    {
        var connection = Connection.Get();

        using SqlCommand sqlCommand = new SqlCommand();
        sqlCommand.Connection = connection;
        sqlCommand.CommandText = "INSERT INTO locations VALUES (@id, @street_address, @postal_code, @city, @state_province, @country_id)";

        connection.Open();
        using SqlTransaction transaction = connection.BeginTransaction();
        sqlCommand.Transaction = transaction;

        try
        {
            SqlParameter pId = new SqlParameter();
            pId.ParameterName = "@id";
            pId.SqlDbType = SqlDbType.Int;
            pId.Value = location.Id;
            sqlCommand.Parameters.Add(pId);

            SqlParameter pStreetAddress = new SqlParameter();
            pStreetAddress.ParameterName = "@street_address";
            pStreetAddress.SqlDbType = SqlDbType.VarChar;
            pStreetAddress.Value = location.StreetAddress;
            sqlCommand.Parameters.Add(pStreetAddress);

            SqlParameter pPostalCode = new SqlParameter();
            pPostalCode.ParameterName = "@postal_code";
            pPostalCode.SqlDbType = SqlDbType.VarChar;
            pPostalCode.Value = location.PostalCode;
            sqlCommand.Parameters.Add(pPostalCode);

            SqlParameter pCity = new SqlParameter();
            pCity.ParameterName = "@city";
            pCity.SqlDbType = SqlDbType.VarChar;
            pCity.Value = location.City;
            sqlCommand.Parameters.Add(pCity);

            SqlParameter pStateProvince = new SqlParameter();
            pStateProvince.ParameterName = "@state_province";
            pStateProvince.SqlDbType = SqlDbType.VarChar;
            pStateProvince.Value = location.StateProvince;
            sqlCommand.Parameters.Add(pStateProvince);

            SqlParameter pCountryId = new SqlParameter();
            pCountryId.ParameterName = "@country_id";
            pCountryId.SqlDbType = SqlDbType.VarChar;
            pCountryId.Value = location.CountryId;
            sqlCommand.Parameters.Add(pCountryId);

            int result = sqlCommand.ExecuteNonQuery();

            transaction.Commit();
            connection.Close();

            return result; 
        }
        catch
        {
            transaction.Rollback();
            return -1; 
        }
    }


    public int Update(Location location)
    {
        var connection = Connection.Get();

        using SqlCommand sqlCommand = new SqlCommand();
        sqlCommand.Connection = connection;
        sqlCommand.CommandText = "UPDATE locations SET street_address = @street_address, postal_code = @postal_code, city = @city, state_province = @state_province, country_id = @country_id WHERE id = @id";

        connection.Open();
        using SqlTransaction transaction = connection.BeginTransaction();
        sqlCommand.Transaction = transaction;

        try
        {
            SqlParameter pId = new SqlParameter();
            pId.ParameterName = "@id";
            pId.SqlDbType = SqlDbType.Int;
            pId.Value = location.Id;
            sqlCommand.Parameters.Add(pId);

            SqlParameter pStreetAddress = new SqlParameter();
            pStreetAddress.ParameterName = "@street_address";
            pStreetAddress.SqlDbType = SqlDbType.VarChar;
            pStreetAddress.Value = location.StreetAddress;
            sqlCommand.Parameters.Add(pStreetAddress);

            SqlParameter pPostalCode = new SqlParameter();
            pPostalCode.ParameterName = "@postal_code";
            pPostalCode.SqlDbType = SqlDbType.VarChar;
            pPostalCode.Value = location.PostalCode;
            sqlCommand.Parameters.Add(pPostalCode);

            SqlParameter pCity = new SqlParameter();
            pCity.ParameterName = "@city";
            pCity.SqlDbType = SqlDbType.VarChar;
            pCity.Value = location.City;
            sqlCommand.Parameters.Add(pCity);

            SqlParameter pStateProvince = new SqlParameter();
            pStateProvince.ParameterName = "@state_province";
            pStateProvince.SqlDbType = SqlDbType.VarChar;
            pStateProvince.Value = location.StateProvince;
            sqlCommand.Parameters.Add(pStateProvince);

            SqlParameter pCountryId = new SqlParameter();
            pCountryId.ParameterName = "@country_id";
            pCountryId.SqlDbType = SqlDbType.VarChar;
            pCountryId.Value = location.CountryId;
            sqlCommand.Parameters.Add(pCountryId);

            int result = sqlCommand.ExecuteNonQuery();

            transaction.Commit();
            connection.Close();

            return result;
        }
        catch
        {
            transaction.Rollback();
            return -1;
        }
    }



    public int Delete(int id)
    {
        var connection = Connection.Get();

        using SqlCommand sqlCommand = new SqlCommand();
        sqlCommand.Connection = connection;
        sqlCommand.CommandText = "DELETE FROM locations WHERE id = @id";

        connection.Open();
        using SqlTransaction transaction = connection.BeginTransaction();
        sqlCommand.Transaction = transaction;

        try
        {
            SqlParameter pId = new SqlParameter();
            pId.ParameterName = "@id";
            pId.SqlDbType = SqlDbType.Int;
            pId.Value = id;
            sqlCommand.Parameters.Add(pId);

            int result = sqlCommand.ExecuteNonQuery();

            transaction.Commit();
            connection.Close();

            return result;
        }
        catch
        {
            transaction.Rollback();
            return -1;
        }
    }

    public Location GetById(int id)
    {
        var location = new Location();

        var connection = Connection.Get();

        SqlCommand sqlCommand = new SqlCommand();
        sqlCommand.Connection = connection;
        sqlCommand.CommandText = "SELECT * FROM locations WHERE Id = @id";

        SqlParameter pId = new SqlParameter();
        pId.ParameterName = "@id";
        pId.SqlDbType = SqlDbType.Int;
        pId.Value = id;
        sqlCommand.Parameters.Add(pId);

        try
        {
            connection.Open();
            SqlDataReader reader = sqlCommand.ExecuteReader();
            if (reader.HasRows)
            {
                reader.Read();

                location.Id = reader.GetInt32(0);
                location.StreetAddress = reader.GetString(1);
                location.PostalCode = reader.GetString(2);
                location.City = reader.GetString(3);
                location.StateProvince = reader.GetString(4);
                location.CountryId = reader.GetString(5);
            }

            reader.Close();
            connection.Close();

            return location;
        }
        catch
        {
            return new Location();
        }
    }
}