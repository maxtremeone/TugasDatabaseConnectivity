using System.Data;
using System.Data.SqlClient;
using System.Transactions;

namespace DatabaseConnectivity.Models;

public class Country
{
    public string Id { get; set; }
    public string Name { get; set; }
    public int RegionId { get; set; }

    public List<Country> GetAll()
    {
        var connection = Connection.Get();

        var countries = new List<Country>();

        using SqlCommand sqlCommand = new SqlCommand();
        sqlCommand.Connection = connection;
        sqlCommand.CommandText = "SELECT * FROM countries";

        try
        {
            connection.Open();
            using SqlDataReader reader = sqlCommand.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Country country = new Country();
                    country.Id = reader.GetString(0);
                    country.Name = reader.GetString(1);
                    country.RegionId = reader.GetInt32(2);

                    countries.Add(country);
                }
            }
            else
            {
                reader.Close();
                connection.Close();
            }

            return countries;
        }
        catch
        {
            return new List<Country>();
        }
    }

    public int Insert(Country country)
    {
        var connection = Connection.Get();

        using SqlCommand sqlCommand = new SqlCommand();
        sqlCommand.Connection = connection;
        sqlCommand.CommandText = "INSERT INTO countries VALUES (@id, @name, @region_id)";

        connection.Open();
        using SqlTransaction transaction = connection.BeginTransaction();
        sqlCommand.Transaction = transaction;

        try
        {
            SqlParameter parameterId = new SqlParameter();
            parameterId.ParameterName = "@id";
            parameterId.SqlDbType = SqlDbType.VarChar;
            parameterId.Value = country.Id;
            sqlCommand.Parameters.Add(parameterId);

            SqlParameter parameterName = new SqlParameter();
            parameterName.ParameterName = "@name";
            parameterName.SqlDbType = SqlDbType.VarChar;
            parameterName.Value = country.Name;
            sqlCommand.Parameters.Add(parameterName);

            SqlParameter parameterRegionId = new SqlParameter();
            parameterRegionId.ParameterName = "@region_id";
            parameterRegionId.SqlDbType = SqlDbType.Int;
            parameterRegionId.Value = country.RegionId;
            sqlCommand.Parameters.Add(parameterRegionId);

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


    public int Update(Country country)
    {
        var connection = Connection.Get();

        using SqlCommand sqlCommand = new SqlCommand();
        sqlCommand.Connection = connection;
        sqlCommand.CommandText = "UPDATE countries SET name = @name, region_id = @region_id WHERE id = @id";

        connection.Open();
        using SqlTransaction transaction = connection.BeginTransaction();
        sqlCommand.Transaction = transaction;

        try
        {
            SqlParameter pId = new SqlParameter();
            pId.ParameterName = "@id";
            pId.SqlDbType = SqlDbType.VarChar;
            pId.Value = country.Id;
            sqlCommand.Parameters.Add(pId);

            SqlParameter pName = new SqlParameter();
            pName.ParameterName = "@name";
            pName.SqlDbType = SqlDbType.VarChar;
            pName.Value = country.Name;
            sqlCommand.Parameters.Add(pName);

            SqlParameter pRegionId = new SqlParameter();
            pRegionId.ParameterName = "@region_id";
            pRegionId.SqlDbType = SqlDbType.Int;
            pRegionId.Value = country.RegionId;
            sqlCommand.Parameters.Add(pRegionId);

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


    public int Delete(string id)
    {
        var connection = Connection.Get();

        using SqlCommand sqlCommand = new SqlCommand();
        sqlCommand.Connection = connection;
        sqlCommand.CommandText = "DELETE FROM countries WHERE id = @id";

        connection.Open();
        using SqlTransaction transaction = connection.BeginTransaction();
        sqlCommand.Transaction = transaction;

        try
        {
            SqlParameter pId = new SqlParameter();
            pId.ParameterName = "@id";
            pId.SqlDbType = SqlDbType.VarChar;
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



    public Country GetById(string id)
    {
        var country = new Country();

        var connection = Connection.Get();

        SqlCommand sqlCommand = new SqlCommand();
        sqlCommand.Connection = connection;
        sqlCommand.CommandText = "SELECT * FROM countries WHERE Id = @id";

        SqlParameter parameter = new SqlParameter();
        parameter.ParameterName = "@id";
        parameter.SqlDbType = SqlDbType.VarChar;
        parameter.Value = id;
        sqlCommand.Parameters.Add(parameter);

        try
        {
            connection.Open();
            SqlDataReader reader = sqlCommand.ExecuteReader();
            if (reader.HasRows)
            {
                reader.Read();

                country.Id = reader.GetString(0);
                country.Name = reader.GetString(1);
                country.RegionId = reader.GetInt32(2);
            }

            reader.Close();
            connection.Close();

            return country;
        }
        catch
        {
            return new Country();
        }
    }

}
