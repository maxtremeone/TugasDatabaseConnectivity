using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DatabaseConnectivity.Models;

public class History
{
    public DateTime StartDate { get; set; }
    public int EmployeeId { get; set; }
    public DateTime EndDate { get; set; }
    public int DepartmentId { get; set; }
    public string JobId { get; set; }

    public List<History> GetAll()
    {
        var connection = Connection.Get();
        var histories = new List<History>();

        using SqlCommand sqlCommand = new SqlCommand();
        sqlCommand.Connection = connection;
        sqlCommand.CommandText = "SELECT * FROM histories";

        try
        {
            connection.Open();
            using SqlDataReader reader = sqlCommand.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    History history = new History();
                    history.StartDate = reader.GetDateTime(0);
                    history.EmployeeId = reader.GetInt32(1);
                    history.EndDate = reader.GetDateTime(2);
                    history.DepartmentId = reader.GetInt32(3);
                    history.JobId = reader.GetString(4);

                    histories.Add(history);
                }
            }
            else
            {
                reader.Close();
                connection.Close();
            }

            return histories;
        }
        catch
        {
            return new List<History>();
        }
    }

    public int Insert(History history)
    {
        var connection = Connection.Get();

        using SqlCommand sqlCommand = new SqlCommand();
        sqlCommand.Connection = connection;
        sqlCommand.CommandText = "INSERT INTO histories VALUES (@start_date, @employee_id, @end_date, @department_id, @job_id)";

        connection.Open();
        using SqlTransaction transaction = connection.BeginTransaction();
        sqlCommand.Transaction = transaction;

        try
        {
            SqlParameter pStartDate = new SqlParameter();
            pStartDate.ParameterName = "@start_date";
            pStartDate.SqlDbType = SqlDbType.DateTime;
            pStartDate.Value = history.StartDate;
            sqlCommand.Parameters.Add(pStartDate);

            SqlParameter pEmployeeId = new SqlParameter();
            pEmployeeId.ParameterName = "@employee_id";
            pEmployeeId.SqlDbType = SqlDbType.Int;
            pEmployeeId.Value = history.EmployeeId;
            sqlCommand.Parameters.Add(pEmployeeId);

            SqlParameter pEndDate = new SqlParameter();
            pEndDate.ParameterName = "@end_date";
            pEndDate.SqlDbType = SqlDbType.DateTime;
            pEndDate.Value = history.EndDate;
            sqlCommand.Parameters.Add(pEndDate);

            SqlParameter pDepartmentId = new SqlParameter();
            pDepartmentId.ParameterName = "@department_id";
            pDepartmentId.SqlDbType = SqlDbType.Int;
            pDepartmentId.Value = history.DepartmentId;
            sqlCommand.Parameters.Add(pDepartmentId);

            SqlParameter pJobId = new SqlParameter();
            pJobId.ParameterName = "@job_id";
            pJobId.SqlDbType = SqlDbType.VarChar;
            pJobId.Value = history.JobId;
            sqlCommand.Parameters.Add(pJobId);

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

    public int Update(History history)
    {
        var connection = Connection.Get();

        using SqlCommand sqlCommand = new SqlCommand();
        sqlCommand.Connection = connection;
        sqlCommand.CommandText = "UPDATE histories SET start_date = @start_date, employee_id = @employee_id, " +
                                 "end_date = @end_date, department_id = @department_id, job_id = @job_id " +
                                 "WHERE start_date = @start_date AND employee_id = @employee_id";

        connection.Open();
        using SqlTransaction transaction = connection.BeginTransaction();
        sqlCommand.Transaction = transaction;

        try
        {
            SqlParameter pStartDate = new SqlParameter();
            pStartDate.ParameterName = "@start_date";
            pStartDate.SqlDbType = SqlDbType.DateTime;
            pStartDate.Value = history.StartDate;
            sqlCommand.Parameters.Add(pStartDate);

            SqlParameter pEmployeeId = new SqlParameter();
            pEmployeeId.ParameterName = "@employee_id";
            pEmployeeId.SqlDbType = SqlDbType.Int;
            pEmployeeId.Value = history.EmployeeId;
            sqlCommand.Parameters.Add(pEmployeeId);

            SqlParameter pEndDate = new SqlParameter();
            pEndDate.ParameterName = "@end_date";
            pEndDate.SqlDbType = SqlDbType.DateTime;
            pEndDate.Value = history.EndDate;
            sqlCommand.Parameters.Add(pEndDate);

            SqlParameter pDepartmentId = new SqlParameter();
            pDepartmentId.ParameterName = "@department_id";
            pDepartmentId.SqlDbType = SqlDbType.Int;
            pDepartmentId.Value = history.DepartmentId;
            sqlCommand.Parameters.Add(pDepartmentId);

            SqlParameter pJobId = new SqlParameter();
            pJobId.ParameterName = "@job_id";
            pJobId.SqlDbType = SqlDbType.VarChar;
            pJobId.Value = history.JobId;
            sqlCommand.Parameters.Add(pJobId);

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

    public int Delete(int employeeId)
    {
        var connection = Connection.Get();

        using SqlCommand sqlCommand = new SqlCommand();
        sqlCommand.Connection = connection;
        sqlCommand.CommandText = "DELETE FROM histories WHERE employee_id = @employee_id";

        connection.Open();
        using SqlTransaction transaction = connection.BeginTransaction();
        sqlCommand.Transaction = transaction;

        try
        {
            SqlParameter pEmployeeId = new SqlParameter();
            pEmployeeId.ParameterName = "@employee_id";
            pEmployeeId.SqlDbType = SqlDbType.Int;
            pEmployeeId.Value = employeeId;
            sqlCommand.Parameters.Add(pEmployeeId);

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

    public History GetByEmployeeId(int employeeId)
    {
        var history = new History();

        var connection = Connection.Get();

        SqlCommand sqlCommand = new SqlCommand();
        sqlCommand.Connection = connection;
        sqlCommand.CommandText = "SELECT * FROM histories WHERE employee_id = @employee_id";

        SqlParameter pEmployeeId = new SqlParameter();
        pEmployeeId.ParameterName = "@employee_id";
        pEmployeeId.SqlDbType = SqlDbType.Int;
        pEmployeeId.Value = employeeId;
        sqlCommand.Parameters.Add(pEmployeeId);

        try
        {
            connection.Open();
            SqlDataReader reader = sqlCommand.ExecuteReader();
            if (reader.HasRows)
            {
                reader.Read();

                history.StartDate = reader.GetDateTime(0);
                history.EmployeeId = reader.GetInt32(1);
                history.EndDate = reader.GetDateTime(2);
                history.DepartmentId = reader.GetInt32(3);
                history.JobId = reader.GetString(4);
            }

            reader.Close();
            connection.Close();

            return history;
        }
        catch
        {
            return new History();
        }
    }
}
