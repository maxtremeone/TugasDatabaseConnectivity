using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;

namespace DatabaseConnectivity.Models;
public class Department 
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int LocationId { get; set; }
    public int ManagerId { get; set; }

    public List<Department> GetAll()
    {
        var connection = Connection.Get();

        var departments = new List<Department>();

        using SqlCommand sqlCommand = new SqlCommand();
        sqlCommand.Connection = connection;
        sqlCommand.CommandText = "SELECT * FROM departments";

        try
        {
            connection.Open();
            using SqlDataReader reader = sqlCommand.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Department department = new Department();
                    department.Id = reader.GetInt32(0);
                    department.Name = reader.GetString(1);
                    department.LocationId = reader.GetInt32(2);
                    department.ManagerId = reader.GetInt32(3);

                    departments.Add(department);
                }
            }
            else
            {
                reader.Close();
                connection.Close();
            }

            return departments;
        }
        catch
        {
            return new List<Department>();
        }
    }

    public int Insert(Department department)
    {
        var connection = Connection.Get();

        using SqlCommand sqlCommand = new SqlCommand();
        sqlCommand.Connection = connection;
        sqlCommand.CommandText = "INSERT INTO departments VALUES (@id, @name, @location_id, @manager_id)";

        connection.Open();
        using SqlTransaction transaction = connection.BeginTransaction();
        sqlCommand.Transaction = transaction;

        try
        {
            SqlParameter pId = new SqlParameter();
            pId.ParameterName = "@id";
            pId.SqlDbType = SqlDbType.Int;
            pId.Value = department.Id;
            sqlCommand.Parameters.Add(pId);

            SqlParameter pName = new SqlParameter();
            pName.ParameterName = "@name";
            pName.SqlDbType = SqlDbType.VarChar;
            pName.Value = department.Name;
            sqlCommand.Parameters.Add(pName);

            SqlParameter pLocationId = new SqlParameter();
            pLocationId.ParameterName = "@location_id";
            pLocationId.SqlDbType = SqlDbType.Int;
            pLocationId.Value = department.LocationId;
            sqlCommand.Parameters.Add(pLocationId);

            SqlParameter pManagerId = new SqlParameter();
            pManagerId.ParameterName = "@manager_id";
            pManagerId.SqlDbType = SqlDbType.Int;
            pManagerId.Value = department.ManagerId;
            sqlCommand.Parameters.Add(pManagerId);

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

    public int Update(Department department)
    {
        var connection = Connection.Get();

        using SqlCommand sqlCommand = new SqlCommand();
        sqlCommand.Connection = connection;
        sqlCommand.CommandText = "UPDATE departments SET name = @name, location_id = @location_id, manager_id = @manager_id WHERE id = @id";

        connection.Open();
        using SqlTransaction transaction = connection.BeginTransaction();
        sqlCommand.Transaction = transaction;

        try
        {
            SqlParameter pId = new SqlParameter();
            pId.ParameterName = "@id";
            pId.SqlDbType = SqlDbType.Int;
            pId.Value = department.Id;
            sqlCommand.Parameters.Add(pId);

            SqlParameter pName = new SqlParameter();
            pName.ParameterName = "@name";
            pName.SqlDbType = SqlDbType.VarChar;
            pName.Value = department.Name;
            sqlCommand.Parameters.Add(pName);

            SqlParameter pLocationId = new SqlParameter();
            pLocationId.ParameterName = "@location_id";
            pLocationId.SqlDbType = SqlDbType.Int;
            pLocationId.Value = department.LocationId;
            sqlCommand.Parameters.Add(pLocationId);

            SqlParameter pManagerId = new SqlParameter();
            pManagerId.ParameterName = "@manager_id";
            pManagerId.SqlDbType = SqlDbType.Int;
            pManagerId.Value = department.ManagerId;
            sqlCommand.Parameters.Add(pManagerId);

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
        sqlCommand.CommandText = "DELETE FROM departments WHERE id = @id";

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

    public Department GetById(int id)
    {
        var department = new Department();

        var connection = Connection.Get();

        SqlCommand sqlCommand = new SqlCommand();
        sqlCommand.Connection = connection;
        sqlCommand.CommandText = "SELECT * FROM departments WHERE Id = @id";

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

                department.Id = reader.GetInt32(0);
                department.Name = reader.GetString(1);
                department.LocationId = reader.GetInt32(2);
                department.ManagerId = reader.GetInt32(3);
            }

            reader.Close();
            connection.Close();

            return department;
        }
        catch
        {
            return new Department();
        }
    }
}