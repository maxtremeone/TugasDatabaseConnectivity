using System.Data;
using System.Data.SqlClient;

namespace DatabaseConnectivity.Models;

public class Region
{
    internal string RegionId;

    public int Id { get; set; }
    public string? Name { get; set; }

    public List<Region> GetAll()
    {
        var connection = Connection.Get();

        var regions = new List<Region>();

        using SqlCommand sqlCommand = new SqlCommand();
        sqlCommand.Connection = connection;
        sqlCommand.CommandText = "SELECT * FROM regions";

        try
        {
            connection.Open();
            using SqlDataReader reader = sqlCommand.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Region region = new Region();
                    region.Id = reader.GetInt32(0);
                    region.Name = reader.GetString(1);

                    regions.Add(region);
                }
            }
            else
            {
                reader.Close();
                connection.Close();
            }

            return regions;
        }
        catch
        {
            return new List<Region>();
        }
    }

    /*
     * <summary>digunakan untuk melakukan penambahan record ke database</summary>
     * <param region>value input yang diperlukan tabel region</param>
     */
    public int Insert(Region region)
    {
        var connection = Connection.Get();

        using SqlCommand sqlCommand = new SqlCommand();
        sqlCommand.Connection = connection;
        sqlCommand.CommandText = "INSERT INTO regions VALUES (@name)";

        connection.Open();
        using SqlTransaction transaction = connection.BeginTransaction();
        sqlCommand.Transaction = transaction;

        try
        {
            SqlParameter pName = new SqlParameter();
            pName.ParameterName = "@name";
            pName.SqlDbType = System.Data.SqlDbType.VarChar;
            pName.Value = region.Name;
            sqlCommand.Parameters.Add(pName);

            int result = sqlCommand.ExecuteNonQuery();

            transaction.Commit();
            connection.Close();

            return result; // 0 gagal, >= 1 berhasil
        }
        catch
        {
            transaction.Rollback();
            return -1; // Kesalahan terjadi pada database
        }
    }

    public int Update(Region region)
    {
        var connection = Connection.Get();

        SqlCommand sqlCommand = new SqlCommand();
        sqlCommand.Connection = connection;
        sqlCommand.CommandText = "UPDATE regions SET name = @name WHERE id = @id";

        connection.Open();
        SqlTransaction transaction = connection.BeginTransaction();
        sqlCommand.Transaction = transaction;
        try
        {
            SqlParameter pName = new SqlParameter();
            pName.ParameterName = "@name";
            pName.SqlDbType = System.Data.SqlDbType.VarChar;
            pName.Value = region.Name;
            sqlCommand.Parameters.Add(pName);

            SqlParameter pRegionId = new SqlParameter();
            pRegionId.ParameterName = "@region_id";
            pRegionId.SqlDbType = System.Data.SqlDbType.Int;
            pRegionId.Value = region.Id;
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

    public int Delete(int id)
    {
        var connection = Connection.Get();

        SqlCommand sqlCommand = new SqlCommand();
        sqlCommand.Connection = connection;
        sqlCommand.CommandText = "DELETE FROM regions WHERE id = @id";

        connection.Open();
        SqlTransaction transaction = connection.BeginTransaction();
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

    public Region GetById(int id)
    {
        var region = new Region();

        var connection = Connection.Get();

        SqlCommand sqlCommand = new SqlCommand();
        sqlCommand.Connection = connection;
        sqlCommand.CommandText = "SELECT * FROM regions WHERE Id = @id";
        //sqlCommand.Parameters.AddWithValue("@region_id", id);

        SqlParameter parameter = new SqlParameter();
        parameter.ParameterName = "@id";
        parameter.SqlDbType = SqlDbType.Int;
        parameter.Value = region.Id;
        sqlCommand.Parameters.Add(parameter);

        try
        {
            connection.Open();
            SqlDataReader reader = sqlCommand.ExecuteReader();
            if (reader.HasRows)
            {
                reader.Read();

                region.Id = reader.GetInt32(0);
                region.Name = reader.GetString(1);
            }

            reader.Close();
            connection.Close();

            return new Region();
        }
        catch
        {
            return new Region();
        }
    }

    internal Region GetById(string id)
    {
        throw new NotImplementedException();
    }
}