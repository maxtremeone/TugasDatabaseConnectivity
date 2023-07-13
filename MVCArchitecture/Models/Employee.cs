using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DatabaseConnectivity.Models;

public class Employee
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public DateTime HireDate { get; set; }
    public int Salary { get; set; }
    public decimal CommissionPct { get; set; }
    public int ManagerId { get; set; }
    public int JobId { get; set; }
    public int DepartmentId { get; set; }

    public List<Employee> GetAll()
    {
        var connection = Connection.Get();
        var employees = new List<Employee>();

        using SqlCommand sqlCommand = new SqlCommand();
        sqlCommand.Connection = connection;
        sqlCommand.CommandText = "SELECT * FROM employees";

        try
        {
            connection.Open();
            using SqlDataReader reader = sqlCommand.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Employee employee = new Employee();
                    employee.Id = reader.GetInt32(0);
                    employee.FirstName = reader.GetString(1);
                    employee.LastName = reader.GetString(2);
                    employee.Email = reader.GetString(3);
                    employee.PhoneNumber = reader.GetString(4);
                    employee.HireDate = reader.GetDateTime(5);
                    employee.Salary = reader.GetInt32(6);
                    employee.CommissionPct = reader.GetDecimal(7);
                    employee.ManagerId = reader.GetInt32(8);
                    employee.JobId = reader.GetInt32(9);
                    employee.DepartmentId = reader.GetInt32(10);

                    employees.Add(employee);
                }
            }
            else
            {
                reader.Close();
                connection.Close();
            }

            return employees;
        }
        catch
        {
            return new List<Employee>();
        }
    }

    public int Insert(Employee employee)
    {
        var connection = Connection.Get();

        using SqlCommand sqlCommand = new SqlCommand();
        sqlCommand.Connection = connection;
        sqlCommand.CommandText = "INSERT INTO employees VALUES (@id, @first_name, @last_name, @email, " +
                                 "@phone_number, @hire_date, @salary, @commission_pct, @manager_id, @job_id, @department_id)";

        connection.Open();
        using SqlTransaction transaction = connection.BeginTransaction();
        sqlCommand.Transaction = transaction;

        try
        {
            SqlParameter pId = new SqlParameter();
            pId.ParameterName = "@id";
            pId.SqlDbType = SqlDbType.Int;
            pId.Value = employee.Id;
            sqlCommand.Parameters.Add(pId);

            SqlParameter pFirstName = new SqlParameter();
            pFirstName.ParameterName = "@first_name";
            pFirstName.SqlDbType = SqlDbType.VarChar;
            pFirstName.Value = employee.FirstName;
            sqlCommand.Parameters.Add(pFirstName);

            SqlParameter pLastName = new SqlParameter();
            pLastName.ParameterName = "@last_name";
            pLastName.SqlDbType = SqlDbType.VarChar;
            pLastName.Value = employee.LastName;
            sqlCommand.Parameters.Add(pLastName);

            SqlParameter pEmail = new SqlParameter();
            pEmail.ParameterName = "@email";
            pEmail.SqlDbType = SqlDbType.VarChar;
            pEmail.Value = employee.Email;
            sqlCommand.Parameters.Add(pEmail);

            SqlParameter pPhoneNumber = new SqlParameter();
            pPhoneNumber.ParameterName = "@phone_number";
            pPhoneNumber.SqlDbType = SqlDbType.VarChar;
            pPhoneNumber.Value = employee.PhoneNumber;
            sqlCommand.Parameters.Add(pPhoneNumber);

            SqlParameter pHireDate = new SqlParameter();
            pHireDate.ParameterName = "@hire_date";
            pHireDate.SqlDbType = SqlDbType.DateTime;
            pHireDate.Value = employee.HireDate;
            sqlCommand.Parameters.Add(pHireDate);

            SqlParameter pSalary = new SqlParameter();
            pSalary.ParameterName = "@salary";
            pSalary.SqlDbType = SqlDbType.Int;
            pSalary.Value = employee.Salary;
            sqlCommand.Parameters.Add(pSalary);

            SqlParameter pCommissionPct = new SqlParameter();
            pCommissionPct.ParameterName = "@commission_pct";
            pCommissionPct.SqlDbType = SqlDbType.Decimal;
            pCommissionPct.Value = employee.CommissionPct;
            sqlCommand.Parameters.Add(pCommissionPct);

            SqlParameter pManagerId = new SqlParameter();
            pManagerId.ParameterName = "@manager_id";
            pManagerId.SqlDbType = SqlDbType.Int;
            pManagerId.Value = employee.ManagerId;
            sqlCommand.Parameters.Add(pManagerId);

            SqlParameter pJobId = new SqlParameter();
            pJobId.ParameterName = "@job_id";
            pJobId.SqlDbType = SqlDbType.Int;
            pJobId.Value = employee.JobId;
            sqlCommand.Parameters.Add(pJobId);

            SqlParameter pDepartmentId = new SqlParameter();
            pDepartmentId.ParameterName = "@department_id";
            pDepartmentId.SqlDbType = SqlDbType.Int;
            pDepartmentId.Value = employee.DepartmentId;
            sqlCommand.Parameters.Add(pDepartmentId);

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

    public int Update(Employee employee)
    {
        var connection = Connection.Get();

        using SqlCommand sqlCommand = new SqlCommand();
        sqlCommand.Connection = connection;
        sqlCommand.CommandText = "UPDATE employees SET first_name = @first_name, last_name = @last_name, " +
                                 "email = @email, phone_number = @phone_number, " +
                                 "hire_date = @hire_date, salary = @salary, commission_pct = @commission_pct, " +
                                 "manager_id = @manager_id, job_id = @job_id, department_id = @department_id " +
                                 "WHERE id = @id";

        connection.Open();
        using SqlTransaction transaction = connection.BeginTransaction();
        sqlCommand.Transaction = transaction;

        try
        {
            SqlParameter pId = new SqlParameter();
            pId.ParameterName = "@id";
            pId.SqlDbType = SqlDbType.Int;
            pId.Value = employee.Id;
            sqlCommand.Parameters.Add(pId);

            SqlParameter pFirstName = new SqlParameter();
            pFirstName.ParameterName = "@first_name";
            pFirstName.SqlDbType = SqlDbType.VarChar;
            pFirstName.Value = employee.FirstName;
            sqlCommand.Parameters.Add(pFirstName);

            SqlParameter pLastName = new SqlParameter();
            pLastName.ParameterName = "@last_name";
            pLastName.SqlDbType = SqlDbType.VarChar;
            pLastName.Value = employee.LastName;
            sqlCommand.Parameters.Add(pLastName);

            SqlParameter pEmail = new SqlParameter();
            pEmail.ParameterName = "@email";
            pEmail.SqlDbType = SqlDbType.VarChar;
            pEmail.Value = employee.Email;
            sqlCommand.Parameters.Add(pEmail);

            SqlParameter pPhoneNumber = new SqlParameter();
            pPhoneNumber.ParameterName = "@phone_number";
            pPhoneNumber.SqlDbType = SqlDbType.VarChar;
            pPhoneNumber.Value = employee.PhoneNumber;
            sqlCommand.Parameters.Add(pPhoneNumber);

            SqlParameter pHireDate = new SqlParameter();
            pHireDate.ParameterName = "@hire_date";
            pHireDate.SqlDbType = SqlDbType.DateTime;
            pHireDate.Value = employee.HireDate;
            sqlCommand.Parameters.Add(pHireDate);

            SqlParameter pSalary = new SqlParameter();
            pSalary.ParameterName = "@salary";
            pSalary.SqlDbType = SqlDbType.Int;
            pSalary.Value = employee.Salary;
            sqlCommand.Parameters.Add(pSalary);

            SqlParameter pCommissionPct = new SqlParameter();
            pCommissionPct.ParameterName = "@commission_pct";
            pCommissionPct.SqlDbType = SqlDbType.Decimal;
            pCommissionPct.Value = employee.CommissionPct;
            sqlCommand.Parameters.Add(pCommissionPct);

            SqlParameter pManagerId = new SqlParameter();
            pManagerId.ParameterName = "@manager_id";
            pManagerId.SqlDbType = SqlDbType.Int;
            pManagerId.Value = employee.ManagerId;
            sqlCommand.Parameters.Add(pManagerId);

            SqlParameter pJobId = new SqlParameter();
            pJobId.ParameterName = "@job_id";
            pJobId.SqlDbType = SqlDbType.Int;
            pJobId.Value = employee.JobId;
            sqlCommand.Parameters.Add(pJobId);

            SqlParameter pDepartmentId = new SqlParameter();
            pDepartmentId.ParameterName = "@department_id";
            pDepartmentId.SqlDbType = SqlDbType.Int;
            pDepartmentId.Value = employee.DepartmentId;
            sqlCommand.Parameters.Add(pDepartmentId);

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
        sqlCommand.CommandText = "DELETE FROM employees WHERE id = @id";

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

    public Employee GetById(int id)
    {
        var employee = new Employee();

        var connection = Connection.Get();

        SqlCommand sqlCommand = new SqlCommand();
        sqlCommand.Connection = connection;
        sqlCommand.CommandText = "SELECT * FROM employees WHERE Id = @id";

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

                employee.Id = reader.GetInt32(0);
                employee.FirstName = reader.GetString(1);
                employee.LastName = reader.GetString(2);
                employee.Email = reader.GetString(3);
                employee.PhoneNumber = reader.GetString(4);
                employee.HireDate = reader.GetDateTime(5);
                employee.Salary = reader.GetInt32(6);
                employee.CommissionPct = reader.GetDecimal(7);
                employee.ManagerId = reader.GetInt32(8);
                employee.JobId = reader.GetInt32(9);
                employee.DepartmentId = reader.GetInt32(10);
            }

            reader.Close();
            connection.Close();

            return employee;
        }
        catch
        {
            return new Employee();
        }
    }
}
