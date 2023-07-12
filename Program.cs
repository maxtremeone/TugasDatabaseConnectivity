using System.Data;
using System.Data.SqlClient;
using System.Xml.Linq;

namespace DatabaseConnectivity;

public class Program
{
    private static string _connectionString =
        "Data Source=LAPTOP-940PM46G;" +
        "Database=db_tugasERD5;" +
        "Integrated Security=True;" +
        "Connect Timeout=30;";

    private static SqlConnection _connection; //pake underline di depan karena private
    public static void Main()
    {
        Menu();
    }


    // method GET ALL regions
    public static void GetRegions() //kalau static harus menggunakan static semua
    {
        _connection = new SqlConnection(_connectionString);

        SqlCommand sqlCommand = new SqlCommand();
        sqlCommand.Connection = _connection;
        sqlCommand.CommandText = "SELECT * FROM regions";

        try
        {
            _connection.Open();
            using SqlDataReader reader = sqlCommand.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Console.WriteLine("Id: " + reader.GetInt32(0));
                    Console.WriteLine("Name: " + reader.GetString(1));
                }
            }
            else
            {
                Console.WriteLine("No regions found.");
            }

            reader.Close();
            _connection.Close();
        }
        catch
        {
            Console.WriteLine("Error connecting to database.");
        }
    }


    //method INSERT REGION
    public static void InsertRegions(string name)
    {
        _connection = new SqlConnection(_connectionString);

        SqlCommand sqlCommand = new SqlCommand();
        sqlCommand.Connection = _connection;
        sqlCommand.CommandText = "INSERT INTO regions VALUES (@name)";

        _connection.Open();
        SqlTransaction transaction = _connection.BeginTransaction();
        sqlCommand.Transaction = transaction;

        try
        {
            SqlParameter pName = new SqlParameter();
            pName.ParameterName = "@name";
            pName.SqlDbType = SqlDbType.VarChar;
            pName.Value = name;
            sqlCommand.Parameters.Add(pName);

            int result = sqlCommand.ExecuteNonQuery(); //ini int karena variabel result mengembalikan angka
            if (result > 0)
            {
                Console.WriteLine("Insert success.");
            }
            else
            {
                Console.WriteLine("Insert failed.");
            }

            transaction.Commit();
            _connection.Close();
        }
        catch
        {
            transaction.Rollback();
            Console.WriteLine("Error connecting to database.");
        }
    }


    //UPDATE REGION hampir sama seperti insert
    public static void UpdateRegions(int id, string name)
    {
        _connection = new SqlConnection(_connectionString);

        SqlCommand sqlCommand = new SqlCommand();
        sqlCommand.Connection = _connection;
        sqlCommand.CommandText = "UPDATE regions SET name = @name WHERE id = @id";
        //sqlCommand.CommandText = "DBCC CHECKIDENT(regions, RESEED, 29)";

        _connection.Open();
        SqlTransaction transaction = _connection.BeginTransaction();
        sqlCommand.Transaction = transaction;

        try
        {
            SqlParameter pId = new SqlParameter();
            pId.ParameterName = "@id";
            pId.SqlDbType = SqlDbType.Int;
            pId.Value = id;
            sqlCommand.Parameters.Add(pId);

            SqlParameter pName = new SqlParameter();
            pName.ParameterName = "@name";
            pName.SqlDbType = SqlDbType.VarChar;
            pName.Value = name;
            sqlCommand.Parameters.Add(pName);

            int result = sqlCommand.ExecuteNonQuery(); //ini int karena variabel result mengembalikan angka
            if (result > 0)
            {
                Console.WriteLine("Update success.");
            }
            else
            {
                Console.WriteLine("Update failed.");
            }

            transaction.Commit();
            _connection.Close();
        }
        catch
        {
            transaction.Rollback();
            Console.WriteLine("Error connecting to database.");
        }
    }


    //DELETE REGION hampir sama seperti insert
    public static void DeleteRegions(int id)
    {
        _connection = new SqlConnection(_connectionString);

        SqlCommand sqlCommand = new SqlCommand();
        sqlCommand.Connection = _connection;
        sqlCommand.CommandText = "DELETE FROM regions WHERE id = @id";

        _connection.Open();
        SqlTransaction transaction = _connection.BeginTransaction();
        sqlCommand.Transaction = transaction;

        try
        {
            SqlParameter pId = new SqlParameter();
            pId.ParameterName = "@id";
            pId.SqlDbType = SqlDbType.Int;
            pId.Value = id;
            sqlCommand.Parameters.Add(pId);

            int result = sqlCommand.ExecuteNonQuery(); //ini int karena variabel result mengembalikan angka
            if (result > 0)
            {
                Console.WriteLine("Delete success.");
            }
            else
            {
                Console.WriteLine("Delete failed.");
            }

            transaction.Commit();
            _connection.Close();
        }
        catch
        {
            transaction.Rollback();
            Console.WriteLine("Error connecting to database.");
        }
    }


    //GET BY ID REGION referensi get all region, tambahannya where paramaternya id
    public static void GetRegionsById(int regionId)
    {
        _connection = new SqlConnection(_connectionString);

        SqlCommand sqlCommand = new SqlCommand();
        sqlCommand.Connection = _connection;
        sqlCommand.CommandText = "SELECT * FROM regions WHERE Id = @id";

        SqlParameter parameter = new SqlParameter();
        parameter.ParameterName = "@id";
        parameter.SqlDbType = SqlDbType.Int;
        parameter.Value = regionId;
        sqlCommand.Parameters.Add(parameter);

        try
        {
            _connection.Open();
            using SqlDataReader reader = sqlCommand.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Console.WriteLine("Id: " + reader.GetInt32(0));
                    Console.WriteLine("Name: " + reader.GetString(1));
                }
            }
            else
            {
                Console.WriteLine("No region found for the given ID.");
            }

            reader.Close();
            _connection.Close();
        }
        catch
        {
            Console.WriteLine("Error connecting to database.");
        }
    }


    //--------------------------------------------READ GET JOBS
    public static void GetJobs() //kalau static harus menggunakan static semua
    {
        _connection = new SqlConnection(_connectionString);

        SqlCommand sqlCommand = new SqlCommand();
        sqlCommand.Connection = _connection;
        sqlCommand.CommandText = "SELECT * FROM jobs";

        try
        {
            _connection.Open();
            using SqlDataReader reader = sqlCommand.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Console.WriteLine("Id: " + reader.GetString(0));
                    Console.WriteLine("Title: " + reader.GetString(1));
                    Console.WriteLine("Min_Salary: " + reader.GetInt32(2));
                    Console.WriteLine("Max_Salary: " + reader.GetInt32(3));
                }
            }
            else
            {
                Console.WriteLine("No jobs found.");
            }

            reader.Close();
            _connection.Close();
        }
        catch
        {
            Console.WriteLine("Error connecting to database.");
        }
    }


    //--------------------------------------------INSERT JOBS
    public static void InsertJobs(string id, string title, int min_salary, int max_salary)
    {
        _connection = new SqlConnection(_connectionString);

        SqlCommand sqlCommand = new SqlCommand();
        sqlCommand.Connection = _connection;
        sqlCommand.CommandText = "INSERT INTO jobs (Id, Title, Min_Salary, Max_Salary) VALUES (@id, @title, @min_salary, @max_salary)";

        _connection.Open();
        SqlTransaction transaction = _connection.BeginTransaction();
        sqlCommand.Transaction = transaction;

        try
        {
            SqlParameter pId = new SqlParameter();
            pId.ParameterName = "@id";
            pId.SqlDbType = SqlDbType.VarChar;
            pId.Value = id;
            sqlCommand.Parameters.Add(pId);

            SqlParameter pTitle = new SqlParameter();
            pTitle.ParameterName = "@title";
            pTitle.SqlDbType = SqlDbType.VarChar;
            pTitle.Value = title;
            sqlCommand.Parameters.Add(pTitle);

            SqlParameter pMinSalary = new SqlParameter();
            pMinSalary.ParameterName = "@min_salary";
            pMinSalary.SqlDbType = SqlDbType.Int;
            pMinSalary.Value = min_salary;
            sqlCommand.Parameters.Add(pMinSalary);

            SqlParameter pMaxSalary = new SqlParameter();
            pMaxSalary.ParameterName = "@max_salary";
            pMaxSalary.SqlDbType = SqlDbType.Int;
            pMaxSalary.Value = max_salary;
            sqlCommand.Parameters.Add(pMaxSalary);

            int result = sqlCommand.ExecuteNonQuery(); //ini int karena variabel result mengembalikan angka
            if (result > 0)
            {
                Console.WriteLine("Insert success.");
            }
            else
            {
                Console.WriteLine("Insert failed.");
            }

            transaction.Commit();
            _connection.Close();
        }
        catch
        {
            transaction.Rollback();
            Console.WriteLine("Error connecting to database.");
        }
    }

    //UPDATE JOBS
    public static void UpdateJobs(string id, string title, int min_salary, int max_salary)
    {
        _connection = new SqlConnection(_connectionString);

        SqlCommand sqlCommand = new SqlCommand();
        sqlCommand.Connection = _connection;
        sqlCommand.CommandText = "UPDATE jobs SET Title = @title, Min_Salary = @min_salary, Max_Salary = @max_salary WHERE Id = @id";

        _connection.Open();
        SqlTransaction transaction = _connection.BeginTransaction();
        sqlCommand.Transaction = transaction;

        try
        {
            SqlParameter pId = new SqlParameter();
            pId.ParameterName = "@id";
            pId.SqlDbType = SqlDbType.VarChar;
            pId.Value = id;
            sqlCommand.Parameters.Add(pId);

            SqlParameter pTitle = new SqlParameter();
            pTitle.ParameterName = "@title";
            pTitle.SqlDbType = SqlDbType.VarChar;
            pTitle.Value = title;
            sqlCommand.Parameters.Add(pTitle);

            SqlParameter pMinSalary = new SqlParameter();
            pMinSalary.ParameterName = "@min_salary";
            pMinSalary.SqlDbType = SqlDbType.Int;
            pMinSalary.Value = min_salary;
            sqlCommand.Parameters.Add(pMinSalary);

            SqlParameter pMaxSalary = new SqlParameter();
            pMaxSalary.ParameterName = "@max_salary";
            pMaxSalary.SqlDbType = SqlDbType.Int;
            pMaxSalary.Value = max_salary;
            sqlCommand.Parameters.Add(pMaxSalary);

            int result = sqlCommand.ExecuteNonQuery(); //ini int karena variabel result mengembalikan angka
            if (result > 0)
            {
                Console.WriteLine("Update success.");
            }
            else
            {
                Console.WriteLine("Update failed.");
            }

            transaction.Commit();
            _connection.Close();
        }
        catch
        {
            transaction.Rollback();
            Console.WriteLine("Error connecting to database.");
        }
    }


    //DELETE JOBS
    public static void DeleteJobs(string id)
    {
        _connection = new SqlConnection(_connectionString);

        SqlCommand sqlCommand = new SqlCommand();
        sqlCommand.Connection = _connection;
        sqlCommand.CommandText = "DELETE FROM jobs WHERE id = @id";

        _connection.Open();
        SqlTransaction transaction = _connection.BeginTransaction();
        sqlCommand.Transaction = transaction;

        try
        {
            SqlParameter pId = new SqlParameter();
            pId.ParameterName = "@id";
            pId.SqlDbType = SqlDbType.VarChar;
            pId.Value = id;
            sqlCommand.Parameters.Add(pId);

            int result = sqlCommand.ExecuteNonQuery(); //ini int karena variabel result mengembalikan angka
            if (result > 0)
            {
                Console.WriteLine("Delete success.");
            }
            else
            {
                Console.WriteLine("Delete failed.");
            }

            transaction.Commit();
            _connection.Close();
        }
        catch
        {
            transaction.Rollback();
            Console.WriteLine("Error connecting to database.");
        }
    }


    //GET JOBS BY ID
    public static void GetJobsById(string jobId)
    {
        _connection = new SqlConnection(_connectionString);

        SqlCommand sqlCommand = new SqlCommand();
        sqlCommand.Connection = _connection;
        sqlCommand.CommandText = "SELECT * FROM jobs WHERE Id = @id";

        SqlParameter parameter = new SqlParameter();
        parameter.ParameterName = "@id";
        parameter.SqlDbType = SqlDbType.VarChar;
        parameter.Value = jobId;
        sqlCommand.Parameters.Add(parameter);

        try
        {
            _connection.Open();
            using SqlDataReader reader = sqlCommand.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Console.WriteLine("Id: " + reader.GetString(0));
                    Console.WriteLine("Title: " + reader.GetString(1));
                    Console.WriteLine("Min_Salary: " + reader.GetInt32(2));
                    Console.WriteLine("Max_Salary: " + reader.GetInt32(3));
                }
            }
            else
            {
                Console.WriteLine("No region found for the given ID.");
            }

            reader.Close();
            _connection.Close();
        }
        catch
        {
            Console.WriteLine("Error connecting to database.");
        }
    }


    //--------------------------------------------READ GET COUNTRIES
    public static void GetCountries()
    {
        _connection = new SqlConnection(_connectionString);

        SqlCommand sqlCommand = new SqlCommand();
        sqlCommand.Connection = _connection;
        sqlCommand.CommandText = "SELECT id, name, region_id FROM countries";

        try
        {
            _connection.Open();
            using SqlDataReader reader = sqlCommand.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Console.WriteLine("Id: " + reader.GetString(0));
                    Console.WriteLine("Name: " + reader.GetString(1));
                    Console.WriteLine("Region ID: " + reader.GetInt32(2));
                }
            }
            else
            {
                Console.WriteLine("No countries found.");
            }

            reader.Close();
            _connection.Close();
        }
        catch
        {
            Console.WriteLine("Error connecting to the database.");
        }
    }

    //method INSERT COUNTRIES
    public static void InsertCountries(string id, string name, int region_id)
    {
        _connection = new SqlConnection(_connectionString);

        SqlCommand sqlCommand = new SqlCommand();
        sqlCommand.Connection = _connection;
        sqlCommand.CommandText = "INSERT INTO countries (id, name, region_id) VALUES (@id, @name, @region_id)";

        _connection.Open();
        SqlTransaction transaction = _connection.BeginTransaction();
        sqlCommand.Transaction = transaction;

        try
        {
            SqlParameter pId = new SqlParameter();
            pId.ParameterName = "@id";
            pId.SqlDbType = SqlDbType.VarChar;
            pId.Value = id;
            sqlCommand.Parameters.Add(pId);

            SqlParameter pName = new SqlParameter();
            pName.ParameterName = "@name";
            pName.SqlDbType = SqlDbType.VarChar;
            pName.Value = name;
            sqlCommand.Parameters.Add(pName);

            SqlParameter pRegionId = new SqlParameter();
            pRegionId.ParameterName = "@region_id";
            pRegionId.SqlDbType = SqlDbType.Int;
            pRegionId.Value = region_id;
            sqlCommand.Parameters.Add(pRegionId);

            int result = sqlCommand.ExecuteNonQuery(); //ini int karena variabel result mengembalikan angka
            if (result > 0)
            {
                Console.WriteLine("Insert success.");
            }
            else
            {
                Console.WriteLine("Insert failed.");
            }

            transaction.Commit();
            _connection.Close();
        }
        catch
        {
            transaction.Rollback();
            Console.WriteLine("Error connecting to database.");
        }
    }


    //----------------------------------------------UPDATE COUNTRIES
    public static void UpdateCountries(string id, string name, int region_id)
    {
        _connection = new SqlConnection(_connectionString);

        SqlCommand sqlCommand = new SqlCommand();
        sqlCommand.Connection = _connection;
        sqlCommand.CommandText = "UPDATE countries SET name = @name, region_id = @region_id WHERE id = @id";

        _connection.Open();
        SqlTransaction transaction = _connection.BeginTransaction();
        sqlCommand.Transaction = transaction;

        try
        {
            SqlParameter pId = new SqlParameter();
            pId.ParameterName = "@id";
            pId.SqlDbType = SqlDbType.VarChar;
            pId.Value = id;
            sqlCommand.Parameters.Add(pId);

            SqlParameter pName = new SqlParameter();
            pName.ParameterName = "@name";
            pName.SqlDbType = SqlDbType.VarChar;
            pName.Value = name;
            sqlCommand.Parameters.Add(pName);

            SqlParameter pRegionId = new SqlParameter();
            pRegionId.ParameterName = "@region_id";
            pRegionId.SqlDbType = SqlDbType.Int;
            pRegionId.Value = region_id;
            sqlCommand.Parameters.Add(pRegionId);

            int result = sqlCommand.ExecuteNonQuery(); //ini int karena variabel result mengembalikan angka
            if (result > 0)
            {
                Console.WriteLine("Update success.");
            }
            else
            {
                Console.WriteLine("Update failed.");
            }

            transaction.Commit();
            _connection.Close();
        }
        catch
        {
            transaction.Rollback();
            Console.WriteLine("Error connecting to database.");
        }
    }


    //--------------------DELETE COUNTRIES 
    public static void DeleteCountries(string id)
    {
        _connection = new SqlConnection(_connectionString);

        SqlCommand sqlCommand = new SqlCommand();
        sqlCommand.Connection = _connection;
        sqlCommand.CommandText = "DELETE FROM countries WHERE id = @id";

        _connection.Open();
        SqlTransaction transaction = _connection.BeginTransaction();
        sqlCommand.Transaction = transaction;

        try
        {
            SqlParameter pId = new SqlParameter();
            pId.ParameterName = "@id";
            pId.SqlDbType = SqlDbType.VarChar;
            pId.Value = id;
            sqlCommand.Parameters.Add(pId);

            int result = sqlCommand.ExecuteNonQuery();
            if (result > 0)
            {
                Console.WriteLine("Delete success.");
            }
            else
            {
                Console.WriteLine("Delete failed.");
            }

            transaction.Commit();
            _connection.Close();
        }

        catch
        {
            Console.WriteLine("Error connecting to database.");
        }

    }

    //GET BY ID COUNTRIES
    public static void GetCountriesById(string id)
    {
        _connection = new SqlConnection(_connectionString);

        SqlCommand sqlCommand = new SqlCommand();
        sqlCommand.Connection = _connection;
        sqlCommand.CommandText = "SELECT * FROM countries WHERE Id = @id";

        SqlParameter parameter = new SqlParameter();
        parameter.ParameterName = "@id";
        parameter.SqlDbType = SqlDbType.VarChar;
        parameter.Value = id;
        sqlCommand.Parameters.Add(parameter);

        try
        {
            _connection.Open();
            using SqlDataReader reader = sqlCommand.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Console.WriteLine("Id: " + reader.GetString(0));
                    Console.WriteLine("Name: " + reader.GetString(1));
                    Console.WriteLine("RegionId: " + reader.GetInt32(2));
                }
            }
            else
            {
                Console.WriteLine("No region found for the given ID.");
            }

            reader.Close();
            _connection.Close();
        }
        catch
        {
            Console.WriteLine("Error connecting to database.");
        }
    }


    //GET LOCATION
    public static void GetLocations()
    {
        _connection = new SqlConnection(_connectionString);

        SqlCommand sqlCommand = new SqlCommand();
        sqlCommand.Connection = _connection;
        sqlCommand.CommandText = "SELECT * FROM locations";

        try
        {
            _connection.Open();
            using SqlDataReader reader = sqlCommand.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Console.WriteLine("Id: " + reader.GetInt32(0));
                    Console.WriteLine("Street_Address: " + reader.GetString(1));
                    Console.WriteLine("Postal_Code: " + reader.GetString(2));
                    Console.WriteLine("City: " + reader.GetString(3));
                    Console.WriteLine("State_Province: " + reader.GetString(4));
                    Console.WriteLine("Country_Id: " + reader.GetString(5));
                }
            }
            else
            {
                Console.WriteLine("No locations found.");
            }

            reader.Close();
            _connection.Close();
        }
        catch
        {
            Console.WriteLine("Error connecting to database.");
        }
    }


    //INSERT LOCATION
    public static void InsertLocations(int id, string street_address, string postal_code, string city, string state_province, string country_id) //KALAU MAU INSERT COUNTRY ID NYA HARUS ADA DI SEBELUMNYA
    {
        _connection = new SqlConnection(_connectionString);

        SqlCommand sqlCommand = new SqlCommand();
        sqlCommand.Connection = _connection;
        sqlCommand.CommandText = "INSERT INTO locations (id, street_address, postal_code, city, state_province, country_id) VALUES (@id, @street_address, @postal_code, @city, @state_province, @country_id)";

        _connection.Open();
        SqlTransaction transaction = _connection.BeginTransaction();
        sqlCommand.Transaction = transaction;

        try
        {
            SqlParameter pId = new SqlParameter();
            pId.ParameterName = "@id";
            pId.SqlDbType = SqlDbType.Int;
            pId.Value = id;
            sqlCommand.Parameters.Add(pId);

            SqlParameter pStreetAddress = new SqlParameter();
            pStreetAddress.ParameterName = "@street_address";
            pStreetAddress.SqlDbType = SqlDbType.VarChar;
            pStreetAddress.Value = street_address;
            sqlCommand.Parameters.Add(pStreetAddress);

            SqlParameter pPostalCode = new SqlParameter();
            pPostalCode.ParameterName = "@postal_code";
            pPostalCode.SqlDbType = SqlDbType.VarChar;
            pPostalCode.Value = postal_code;
            sqlCommand.Parameters.Add(pPostalCode);

            SqlParameter pCity = new SqlParameter();
            pCity.ParameterName = "@city";
            pCity.SqlDbType = SqlDbType.VarChar;
            pCity.Value = city;
            sqlCommand.Parameters.Add(pCity);

            SqlParameter pStateProvince = new SqlParameter();
            pStateProvince.ParameterName = "@state_province";
            pStateProvince.SqlDbType = SqlDbType.VarChar;
            pStateProvince.Value = state_province;
            sqlCommand.Parameters.Add(pStateProvince);

            SqlParameter pCountryId = new SqlParameter();
            pCountryId.ParameterName = "@country_id";
            pCountryId.SqlDbType = SqlDbType.VarChar;
            pCountryId.Value = country_id;
            sqlCommand.Parameters.Add(pCountryId);

            int result = sqlCommand.ExecuteNonQuery(); 
            if (result > 0)
            {
                Console.WriteLine("Insert success.");
            }
            else
            {
                Console.WriteLine("Insert failed.");
            }

            transaction.Commit();
            _connection.Close();
        }
        catch
        {
            transaction.Rollback();
            Console.WriteLine("Error connecting to database.");
        }
    }


    //UPDATE LOCATION
    public static void UpdateLocations(int id, string street_address, string postal_code, string city, string state_province, string country_id)
    {
        _connection = new SqlConnection(_connectionString);

        SqlCommand sqlCommand = new SqlCommand();
        sqlCommand.Connection = _connection;
        sqlCommand.CommandText = "UPDATE countries SET street_address = @street address, postal_code = @postal_code, city = @city, state_province = @state_province, country_id = @country_id WHERE id = @id";

        _connection.Open();
        SqlTransaction transaction = _connection.BeginTransaction();
        sqlCommand.Transaction = transaction;

        try
        {
            SqlParameter pId = new SqlParameter();
            pId.ParameterName = "@id";
            pId.SqlDbType = SqlDbType.Int;
            pId.Value = id;
            sqlCommand.Parameters.Add(pId);

            SqlParameter pStreetAddress = new SqlParameter();
            pStreetAddress.ParameterName = "@street_address";
            pStreetAddress.SqlDbType = SqlDbType.VarChar;
            pStreetAddress.Value = street_address;
            sqlCommand.Parameters.Add(pStreetAddress);

            SqlParameter pPostalCode = new SqlParameter();
            pPostalCode.ParameterName = "@postal_code";
            pPostalCode.SqlDbType = SqlDbType.VarChar;
            pPostalCode.Value = postal_code;
            sqlCommand.Parameters.Add(pPostalCode);

            SqlParameter pCity = new SqlParameter();
            pCity.ParameterName = "@city";
            pCity.SqlDbType = SqlDbType.VarChar;
            pCity.Value = city;
            sqlCommand.Parameters.Add(pCity);

            SqlParameter pStateProvince = new SqlParameter();
            pStateProvince.ParameterName = "@state_province";
            pStateProvince.SqlDbType = SqlDbType.VarChar;
            pStateProvince.Value = state_province;
            sqlCommand.Parameters.Add(pStateProvince);

            SqlParameter pCountryId = new SqlParameter();
            pCountryId.ParameterName = "@country_id";
            pCountryId.SqlDbType = SqlDbType.VarChar;
            pCountryId.Value = country_id;
            sqlCommand.Parameters.Add(pCountryId);

            int result = sqlCommand.ExecuteNonQuery();
            if (result > 0)
            {
                Console.WriteLine("Update success.");
            }
            else
            {
                Console.WriteLine("Update failed.");
            }

            transaction.Commit();
            _connection.Close();
        }
        catch
        {
            transaction.Rollback();
            Console.WriteLine("Error connecting to database.");
        }
    }


    //DELETE LOCATIONS
    public static void DeleteLocations(int id)
    {
        _connection = new SqlConnection(_connectionString);

        SqlCommand sqlCommand = new SqlCommand();
        sqlCommand.Connection = _connection;
        sqlCommand.CommandText = "DELETE FROM locations WHERE id = @id";

        _connection.Open();
        SqlTransaction transaction = _connection.BeginTransaction();
        sqlCommand.Transaction = transaction;

        try
        {
            SqlParameter pId = new SqlParameter();
            pId.ParameterName = "@id";
            pId.SqlDbType = SqlDbType.Int;
            pId.Value = id;
            sqlCommand.Parameters.Add(pId);

            int result = sqlCommand.ExecuteNonQuery();
            if (result > 0)
            {
                Console.WriteLine("Delete success.");
            }
            else
            {
                Console.WriteLine("Delete failed.");
            }

            transaction.Commit();
            _connection.Close();
        }
        catch
        {
            transaction.Rollback();
            Console.WriteLine("Error connecting to database.");
        }
    }


    //GET BY ID LOCATIONS
    public static void GetLocationsById(int id)
    {
        _connection = new SqlConnection(_connectionString);

        SqlCommand sqlCommand = new SqlCommand();
        sqlCommand.Connection = _connection;
        sqlCommand.CommandText = "SELECT * FROM locations WHERE Id = @id";

        SqlParameter parameter = new SqlParameter();
        parameter.ParameterName = "@id";
        parameter.SqlDbType = SqlDbType.VarChar;
        parameter.Value = id;
        sqlCommand.Parameters.Add(parameter);

        try
        {
            _connection.Open();
            using SqlDataReader reader = sqlCommand.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Console.WriteLine("Id: " + reader.GetInt32(0));
                    Console.WriteLine("StreetAddress: " + reader.GetString(1));
                    Console.WriteLine("PostalCode: " + reader.GetString(2));
                    Console.WriteLine("City: " + reader.GetString(3));
                    Console.WriteLine("StateProvince: " + reader.GetString(4));
                    Console.WriteLine("CountryId: " + reader.GetString(5));
                }
            }
            else
            {
                Console.WriteLine("No countries found for the given ID.");
            }

            reader.Close();
            _connection.Close();
        }
        catch
        {
            Console.WriteLine("Error connecting to database.");
        }
    }


    //GET DEPARTMENT
    public static void GetDepartmens()
    {
        _connection = new SqlConnection(_connectionString);

        SqlCommand sqlCommand = new SqlCommand();
        sqlCommand.Connection = _connection;
        sqlCommand.CommandText = "SELECT * FROM departments";

        try
        {
            _connection.Open();
            using SqlDataReader reader = sqlCommand.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Console.WriteLine("Id: " + reader.GetInt32(0));
                    Console.WriteLine("Name: " + reader.GetString(1));
                    Console.WriteLine("LocationId: " + reader.GetInt32(2));
                    Console.WriteLine("ManagerId: " + reader.GetInt32(3));
                }
            }
            else
            {
                Console.WriteLine("No departments found.");
            }

            reader.Close();
            _connection.Close();
        }
        catch
        {
            Console.WriteLine("Error connecting to database.");
        }
    }


    //INSERT DEPARTMENS
    public static void InsertDepartmens(int id, string name, int location_id, int manager_id)
    {
        _connection = new SqlConnection(_connectionString);

        SqlCommand sqlCommand = new SqlCommand();
        sqlCommand.Connection = _connection;
        sqlCommand.CommandText = "INSERT INTO departments (id, name, location_id, manager_id) VALUES (@id, @name, @location_id, @manager_id)";

        _connection.Open();
        SqlTransaction transaction = _connection.BeginTransaction();
        sqlCommand.Transaction = transaction;

        try
        {
            SqlParameter pId = new SqlParameter();
            pId.ParameterName = "@id";
            pId.SqlDbType = SqlDbType.Int;
            pId.Value = id;
            sqlCommand.Parameters.Add(pId);

            SqlParameter pName = new SqlParameter();
            pName.ParameterName = "@name";
            pName.SqlDbType = SqlDbType.VarChar;
            pName.Value = name;
            sqlCommand.Parameters.Add(pName);

            SqlParameter pLocationId = new SqlParameter();
            pLocationId.ParameterName = "@location_id";
            pLocationId.SqlDbType = SqlDbType.Int;
            pLocationId.Value = location_id;
            sqlCommand.Parameters.Add(pLocationId);

            SqlParameter pManagerId = new SqlParameter();
            pManagerId.ParameterName = "@manager_id";
            pManagerId.SqlDbType = SqlDbType.Int;
            pManagerId.Value = manager_id;
            sqlCommand.Parameters.Add(pManagerId);

            int result = sqlCommand.ExecuteNonQuery(); //ini int karena variabel result mengembalikan angka
            if (result > 0)
            {
                Console.WriteLine("Insert success.");
            }
            else
            {
                Console.WriteLine("Insert failed.");
            }

            transaction.Commit();
            _connection.Close();
        }
        catch
        {
            transaction.Rollback();
            Console.WriteLine("Error connecting to database.");
        }
    }


    //UPDATE Departmens
    public static void UpdateDepartmens(int id, string name, int location_id, int manager_id)
    {
        _connection = new SqlConnection(_connectionString);

        SqlCommand sqlCommand = new SqlCommand();
        sqlCommand.Connection = _connection;
        sqlCommand.CommandText = "UPDATE departments SET id = @id name = @name, location_id = @location_id, manager_id = @manager_id";

        _connection.Open();
        SqlTransaction transaction = _connection.BeginTransaction();
        sqlCommand.Transaction = transaction;

        try
        {
            SqlParameter pName = new SqlParameter();
            pName.ParameterName = "@name";
            pName.SqlDbType = SqlDbType.VarChar;
            pName.Value = name;
            sqlCommand.Parameters.Add(pName);

            SqlParameter pLocationId = new SqlParameter();
            pLocationId.ParameterName = "@location_id";
            pLocationId.SqlDbType = SqlDbType.Int;
            pLocationId.Value = location_id;
            sqlCommand.Parameters.Add(pLocationId);

            SqlParameter pManagerId = new SqlParameter();
            pManagerId.ParameterName = "@manager_id";
            pManagerId.SqlDbType = SqlDbType.Int;
            pManagerId.Value = manager_id;
            sqlCommand.Parameters.Add(pManagerId);

            int result = sqlCommand.ExecuteNonQuery();
            if (result > 0)
            {
                Console.WriteLine("Update success.");
            }
            else
            {
                Console.WriteLine("Update failed.");
            }

            transaction.Commit();
            _connection.Close();
        }
        catch (Exception e)
        {
            Console.WriteLine("Error : " + e);
        }
    }


    //Delete departmens
    public static void DeleteDepartmens(int id)
    {
        _connection = new SqlConnection(_connectionString);

        SqlCommand sqlCommand = new SqlCommand();
        sqlCommand.Connection = _connection;
        sqlCommand.CommandText = "DELETE FROM departmens WHERE id = @id";

        _connection.Open();
        SqlTransaction transaction = _connection.BeginTransaction();
        sqlCommand.Transaction = transaction;

        try
        {
            SqlParameter pId = new SqlParameter();
            pId.ParameterName = "@id";
            pId.SqlDbType = SqlDbType.Int;
            pId.Value = id;
            sqlCommand.Parameters.Add(pId);

            int result = sqlCommand.ExecuteNonQuery();
            if (result > 0)
            {
                Console.WriteLine("Delete success.");
            }
            else
            {
                Console.WriteLine("Delete failed.");
            }

            transaction.Commit();
            _connection.Close();
        }
        catch
        {
            transaction.Rollback();
            Console.WriteLine("Error connecting to database.");
        }
    }


    //get by id departments
    public static void GetDepartmensById(int id)
    {
        _connection = new SqlConnection(_connectionString);

        SqlCommand sqlCommand = new SqlCommand();
        sqlCommand.Connection = _connection;
        sqlCommand.CommandText = "SELECT * FROM departments WHERE Id = @id";

        SqlParameter parameter = new SqlParameter();
        parameter.ParameterName = "@id";
        parameter.SqlDbType = SqlDbType.VarChar;
        parameter.Value = id;
        sqlCommand.Parameters.Add(parameter);

        try
        {
            _connection.Open();
            using SqlDataReader reader = sqlCommand.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Console.WriteLine("Id: " + reader.GetInt32(0));
                    Console.WriteLine("Name: " + reader.GetString(1));
                    Console.WriteLine("LocationId: " + reader.GetInt32(2));
                    Console.WriteLine("ManagerId: " + reader.GetInt32(3));
                }
            }
            else
            {
                Console.WriteLine("No countries found for the given ID.");
            }

            reader.Close();
            _connection.Close();
        }
        catch
        {
            Console.WriteLine("Error connecting to database.");
        }
    }


    //GET Employee
    public static void GetEmployees()
    {
        _connection = new SqlConnection(_connectionString);

        SqlCommand sqlCommand = new SqlCommand();
        sqlCommand.Connection = _connection;
        sqlCommand.CommandText = "SELECT * FROM employees";

        try
        {
            _connection.Open();
            using SqlDataReader reader = sqlCommand.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Console.WriteLine("Id: " + reader.GetInt32(0));
                    Console.WriteLine("FristName: " + reader.GetString(1));
                    Console.WriteLine("LastName: " + reader.GetString(2));
                    Console.WriteLine("Email: " + reader.GetString(3));
                    Console.WriteLine("PhoneNumber: " + reader.GetString(4));
                    Console.WriteLine("HireDate: " + reader.GetDateTime(5));
                    Console.WriteLine("Salary: " + reader.GetInt32(6));
                    Console.WriteLine("Comission_pct: " + reader.GetDecimal(7));
                    Console.WriteLine("Manager_id: " + reader.GetInt32(8));
                    Console.WriteLine("Job_id: " + reader.GetString(9));
                    Console.WriteLine("Department_id: " + reader.GetInt32(10));
                }
            }
            else
            {
                Console.WriteLine("No locations found.");
            }

            reader.Close();
            _connection.Close();
        }
        catch
        {
            Console.WriteLine("Error connecting to database.");
        }
    }


    //INSERT EMPLOYEES
    public static void InsertEmployees(int id, string first_name, string last_name, string email, string phone_number, DateTime hire_date, int salary, decimal comission_pct, int manager_id, int job_id, int department_id)
    {
        _connection = new SqlConnection(_connectionString);

        SqlCommand sqlCommand = new SqlCommand();
        sqlCommand.Connection = _connection;
        sqlCommand.CommandText = "INSERT INTO employees (id, first_name, last_name, email, phone_number, hire_date, salary, comission_pct, manager_id, job_id, department_id) VALUES (@id, @first_name, @last_name, @email, @phone_number, @hire_date, @salary, @comission_pct, @manager_id, @job_id, @department_id)";

        _connection.Open();
        SqlTransaction transaction = _connection.BeginTransaction();
        sqlCommand.Transaction = transaction;

        try
        {
            SqlParameter pId = new SqlParameter();
            pId.ParameterName = "@id";
            pId.SqlDbType = SqlDbType.Int;
            pId.Value = id;
            sqlCommand.Parameters.Add(pId);

            SqlParameter pFirstName = new SqlParameter();
            pFirstName.ParameterName = "@first_name";
            pFirstName.SqlDbType = SqlDbType.VarChar;
            pFirstName.Value = first_name;
            sqlCommand.Parameters.Add(pFirstName);

            SqlParameter pLastName = new SqlParameter();
            pLastName.ParameterName = "@last_name";
            pLastName.SqlDbType = SqlDbType.VarChar;
            pLastName.Value = last_name;
            sqlCommand.Parameters.Add(pLastName);

            SqlParameter pEmail = new SqlParameter();
            pEmail.ParameterName = "@email";
            pEmail.SqlDbType = SqlDbType.VarChar;
            pEmail.Value = email;
            sqlCommand.Parameters.Add(pEmail);

            SqlParameter pPhoneNumber = new SqlParameter();
            pPhoneNumber.ParameterName = "@phone_number";
            pPhoneNumber.SqlDbType = SqlDbType.VarChar;
            pPhoneNumber.Value = phone_number;
            sqlCommand.Parameters.Add(pPhoneNumber);

            SqlParameter pHireDate = new SqlParameter();
            pHireDate.ParameterName = "@hire_date";
            pHireDate.SqlDbType = SqlDbType.DateTime;
            pHireDate.Value = hire_date;
            sqlCommand.Parameters.Add(pHireDate);

            SqlParameter pSalary = new SqlParameter();
            pSalary.ParameterName = "@salary";
            pSalary.SqlDbType = SqlDbType.Int;
            pSalary.Value = salary;
            sqlCommand.Parameters.Add(pSalary);

            SqlParameter pComissionPct = new SqlParameter();
            pComissionPct.ParameterName = "@comission_pct";
            pComissionPct.SqlDbType = SqlDbType.Decimal;
            pComissionPct.Value = comission_pct;
            sqlCommand.Parameters.Add(pComissionPct);

            SqlParameter pManagerId = new SqlParameter();
            pManagerId.ParameterName = "@manager_id";
            pManagerId.SqlDbType = SqlDbType.Int;
            pManagerId.Value = manager_id;
            sqlCommand.Parameters.Add(pManagerId);

            SqlParameter pJobId = new SqlParameter();
            pJobId.ParameterName = "@job_id";
            pJobId.SqlDbType = SqlDbType.Int;
            pJobId.Value = job_id;
            sqlCommand.Parameters.Add(pJobId);

            SqlParameter pDepartmentId = new SqlParameter();
            pDepartmentId.ParameterName = "@department_id";
            pDepartmentId.SqlDbType = SqlDbType.Int;
            pDepartmentId.Value = department_id;
            sqlCommand.Parameters.Add(pDepartmentId);

            int result = sqlCommand.ExecuteNonQuery(); //ini int karena variabel result mengembalikan angka
            if (result > 0)
            {
                Console.WriteLine("Insert success.");
            }
            else
            {
                Console.WriteLine("Insert failed.");
            }

            transaction.Commit();
            _connection.Close();
        }
        catch
        {
            transaction.Rollback();
            Console.WriteLine("Error connecting to database.");
        }
    }



    //UPDATE EMPLOYEE
    public static void UpdateEmployees(int id, string first_name, string last_name, string email, string phone_number, DateTime hire_date, int salary, decimal comission_pct, int manager_id, int job_id, int department_id)
    {
        _connection = new SqlConnection(_connectionString);

        SqlCommand sqlCommand = new SqlCommand();
        sqlCommand.Connection = _connection;
        sqlCommand.CommandText = "UPDATE employees SET first_name = @first_name, last_name = @last_name, email = @email, phone_number = @phone_number, hire_date = @hire_date, salary = @salary, comission_pct = @comission_pct, manager_id = @manager_id, job_id = @job_id, department_id = @department_id WHERE id = @id"; ;

        _connection.Open();
        SqlTransaction transaction = _connection.BeginTransaction();
        sqlCommand.Transaction = transaction;

        try
        {
            SqlParameter pId = new SqlParameter();
            pId.ParameterName = "@id";
            pId.SqlDbType = SqlDbType.Int;
            pId.Value = id;
            sqlCommand.Parameters.Add(pId);

            SqlParameter pFirstName = new SqlParameter();
            pFirstName.ParameterName = "@first_name";
            pFirstName.SqlDbType = SqlDbType.VarChar;
            pFirstName.Value = first_name;
            sqlCommand.Parameters.Add(pFirstName);

            SqlParameter pLastName = new SqlParameter();
            pLastName.ParameterName = "@last_name";
            pLastName.SqlDbType = SqlDbType.VarChar;
            pLastName.Value = last_name;
            sqlCommand.Parameters.Add(pLastName);

            SqlParameter pEmail = new SqlParameter();
            pEmail.ParameterName = "@email";
            pEmail.SqlDbType = SqlDbType.VarChar;
            pEmail.Value = email;
            sqlCommand.Parameters.Add(pEmail);

            SqlParameter pPhoneNumber = new SqlParameter();
            pPhoneNumber.ParameterName = "@phone_number";
            pPhoneNumber.SqlDbType = SqlDbType.VarChar;
            pPhoneNumber.Value = phone_number;
            sqlCommand.Parameters.Add(pPhoneNumber);

            SqlParameter pHireDate = new SqlParameter();
            pHireDate.ParameterName = "@hire_date";
            pHireDate.SqlDbType = SqlDbType.DateTime;
            pHireDate.Value = hire_date;
            sqlCommand.Parameters.Add(pHireDate);

            SqlParameter pSalary = new SqlParameter();
            pSalary.ParameterName = "@salary";
            pSalary.SqlDbType = SqlDbType.Int;
            pSalary.Value = salary;
            sqlCommand.Parameters.Add(pSalary);

            SqlParameter pComissionPct = new SqlParameter();
            pComissionPct.ParameterName = "@comission_pct";
            pComissionPct.SqlDbType = SqlDbType.Decimal;
            pComissionPct.Value = comission_pct;
            sqlCommand.Parameters.Add(pComissionPct);

            SqlParameter pManagerId = new SqlParameter();
            pManagerId.ParameterName = "@manager_id";
            pManagerId.SqlDbType = SqlDbType.Int;
            pManagerId.Value = manager_id;
            sqlCommand.Parameters.Add(pManagerId);

            SqlParameter pJobId = new SqlParameter();
            pJobId.ParameterName = "@job_id";
            pJobId.SqlDbType = SqlDbType.Int;
            pJobId.Value = job_id;
            sqlCommand.Parameters.Add(pJobId);

            SqlParameter pDepartmentId = new SqlParameter();
            pDepartmentId.ParameterName = "@department_id";
            pDepartmentId.SqlDbType = SqlDbType.Int;
            pDepartmentId.Value = department_id;
            sqlCommand.Parameters.Add(pDepartmentId);

            int result = sqlCommand.ExecuteNonQuery();
            if (result > 0)
            {
                Console.WriteLine("Update success.");
            }
            else
            {
                Console.WriteLine("Update failed.");
            }

            transaction.Commit();
            _connection.Close();
        }
        catch
        {
            transaction.Rollback();
            Console.WriteLine("Error connecting to database.");
        }
    }


    //DELETE EMPLOYEE
    public static void DeleteEmployees(int id)
    {
        _connection = new SqlConnection(_connectionString);

        SqlCommand sqlCommand = new SqlCommand();
        sqlCommand.Connection = _connection;
        sqlCommand.CommandText = "DELETE FROM employees WHERE id = @id";

        _connection.Open();
        SqlTransaction transaction = _connection.BeginTransaction();
        sqlCommand.Transaction = transaction;

        try
        {
            SqlParameter pId = new SqlParameter();
            pId.ParameterName = "@id";
            pId.SqlDbType = SqlDbType.Int;
            pId.Value = id;
            sqlCommand.Parameters.Add(pId);

            int result = sqlCommand.ExecuteNonQuery();
            if (result > 0)
            {
                Console.WriteLine("Delete success.");
            }
            else
            {
                Console.WriteLine("Delete failed.");
            }

            transaction.Commit();
            _connection.Close();
        }
        catch
        {
            transaction.Rollback();
            Console.WriteLine("Error connecting to database.");
        }
    }


    //Get By ID
    public static void GetEmployeesById(int id)
    {
        _connection = new SqlConnection(_connectionString);

        SqlCommand sqlCommand = new SqlCommand();
        sqlCommand.Connection = _connection;
        sqlCommand.CommandText = "SELECT * FROM employees WHERE Id = @id";

        SqlParameter parameter = new SqlParameter();
        parameter.ParameterName = "@id";
        parameter.SqlDbType = SqlDbType.VarChar;
        parameter.Value = id;
        sqlCommand.Parameters.Add(parameter);

        try
        {
            _connection.Open();
            using SqlDataReader reader = sqlCommand.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Console.WriteLine("Id: " + reader.GetInt32(0));
                    Console.WriteLine("First name: " + reader.GetString(1));
                    Console.WriteLine("Last name: " + reader.GetString(2));
                    Console.WriteLine("Email: " + reader.GetString(3));
                    Console.WriteLine("Phone number: " + reader.GetString(4));
                    Console.WriteLine("Hire date: " + reader.GetDateTime(5));
                    Console.WriteLine("Salary: " + reader.GetInt32(6));
                    Console.WriteLine("Comission pct: " + reader.GetDecimal(7));
                    Console.WriteLine("Manager id: " + reader.GetInt32(8));
                    Console.WriteLine("Job id: " + reader.GetString(9));
                    Console.WriteLine("Department id: " + reader.GetInt32(10));
                }
            }
            else
            {
                Console.WriteLine("No countries found for the given ID.");
            }

            reader.Close();
            _connection.Close();
        }
        catch
        {
            Console.WriteLine("Error connecting to database.");
        }
    }


    //GET ALL HISTORIES
    public static void GetHistories()
    {
        _connection = new SqlConnection(_connectionString);

        SqlCommand sqlCommand = new SqlCommand();
        sqlCommand.Connection = _connection;
        sqlCommand.CommandText = "SELECT * FROM histories";

        try
        {
            _connection.Open();
            using SqlDataReader reader = sqlCommand.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Console.WriteLine("Start date: " + reader.GetDateTime(0));
                    Console.WriteLine("Employee id: " + reader.GetInt32(1));
                    Console.WriteLine("End date: " + reader.GetDateTime(2));
                    Console.WriteLine("Department id: " + reader.GetInt32(3));
                    Console.WriteLine("Job id: " + reader.GetString(4));
                }
            }
            else
            {
                Console.WriteLine("No locations found.");
            }

            reader.Close();
            _connection.Close();
        }
        catch
        {
            Console.WriteLine("Error connecting to database.");
        }
    }


    //INSERT HISTORIES
    public static void InsertHistories(DateTime start_date, int employee_id, DateTime end_date, int department_id, string job_id)
    {
        _connection = new SqlConnection(_connectionString);

        SqlCommand sqlCommand = new SqlCommand();
        sqlCommand.Connection = _connection;
        sqlCommand.CommandText = "INSERT INTO employees (start_date, employee_id, end_date, department_id, job_id) VALUES (@start_date, @employee_id, @end_date, @department_id, @job_id)";

        _connection.Open();
        SqlTransaction transaction = _connection.BeginTransaction();
        sqlCommand.Transaction = transaction;

        try
        {
            SqlParameter pStartDate = new SqlParameter();
            pStartDate.ParameterName = "@start_date";
            pStartDate.SqlDbType = SqlDbType.DateTime;
            pStartDate.Value = start_date;
            sqlCommand.Parameters.Add(pStartDate);

            SqlParameter pEmployeeId = new SqlParameter();
            pEmployeeId.ParameterName = "@employee_id";
            pEmployeeId.SqlDbType = SqlDbType.Int;
            pEmployeeId.Value = employee_id;
            sqlCommand.Parameters.Add(pEmployeeId);

            SqlParameter pEndDate = new SqlParameter();
            pEndDate.ParameterName = "@end_date";
            pEndDate.SqlDbType = SqlDbType.DateTime;
            pEndDate.Value = end_date;
            sqlCommand.Parameters.Add(pEndDate);

            SqlParameter pDepartmentId = new SqlParameter();
            pDepartmentId.ParameterName = "@department_id";
            pDepartmentId.SqlDbType = SqlDbType.Int;
            pDepartmentId.Value = department_id;
            sqlCommand.Parameters.Add(pDepartmentId);

            SqlParameter pJobId = new SqlParameter();
            pJobId.ParameterName = "@job_id";
            pJobId.SqlDbType = SqlDbType.VarChar;
            pJobId.Value = job_id;
            sqlCommand.Parameters.Add(pJobId);

            int result = sqlCommand.ExecuteNonQuery();
            if (result > 0)
            {
                Console.WriteLine("Insert success.");
            }
            else
            {
                Console.WriteLine("Insert failed.");
            }

            transaction.Commit();
            _connection.Close();
        }
        catch
        {
            transaction.Rollback();
            Console.WriteLine("Error connecting to database.");
        }
    }


    //UPDATE HISTORIES
    public static void UpdateHistories(int employee_id, DateTime start_date, DateTime end_date, int department_id, string job_id)
    {
        _connection = new SqlConnection(_connectionString);

        SqlCommand sqlCommand = new SqlCommand();
        sqlCommand.Connection = _connection;
        sqlCommand.CommandText = "UPDATE histories SET start_date = @start_date, end_date = @end_date, department_id = @department_id, job_id = @job_id WHERE employee_id = @employee_id";

        _connection.Open();
        SqlTransaction transaction = _connection.BeginTransaction();
        sqlCommand.Transaction = transaction;
        try
        {
            SqlParameter pEmployeeId = new SqlParameter();
            pEmployeeId.ParameterName = "@employee_id";
            pEmployeeId.SqlDbType = SqlDbType.Int;
            pEmployeeId.Value = employee_id;
            sqlCommand.Parameters.Add(pEmployeeId);

            SqlParameter pStartDate = new SqlParameter();
            pStartDate.ParameterName = "@start_date";
            pStartDate.SqlDbType = SqlDbType.DateTime;
            pStartDate.Value = start_date;
            sqlCommand.Parameters.Add(pStartDate);

            SqlParameter pEndDate = new SqlParameter();
            pEndDate.ParameterName = "@end_date";
            pEndDate.SqlDbType = SqlDbType.DateTime;
            pEndDate.Value = end_date;
            sqlCommand.Parameters.Add(pEndDate);

            SqlParameter pDepartmentId = new SqlParameter();
            pDepartmentId.ParameterName = "@department_id";
            pDepartmentId.SqlDbType = SqlDbType.Int;
            pDepartmentId.Value = department_id;
            sqlCommand.Parameters.Add(pDepartmentId);

            SqlParameter pJobId = new SqlParameter();
            pJobId.ParameterName = "@job_id";
            pJobId.SqlDbType = SqlDbType.VarChar;
            pJobId.Value = job_id;
            sqlCommand.Parameters.Add(pJobId);

            int result = sqlCommand.ExecuteNonQuery();
            if (result > 0)
            {
                Console.WriteLine("Update success.");
            }
            else
            {
                Console.WriteLine("Update failed.");
            }
            transaction.Commit();
            _connection.Close();
        }
        catch
        {
            transaction.Rollback();
            Console.WriteLine("Error connecting to database.");
        }
    }


    //DELETE HISTORIES
    public static void DeleteHistories(int employee_id)
    {
        _connection = new SqlConnection(_connectionString);

        SqlCommand sqlCommand = new SqlCommand();
        sqlCommand.Connection = _connection;
        sqlCommand.CommandText = "DELETE FROM histories WHERE employee_id = @employee_id";

        _connection.Open();
        SqlTransaction transaction = _connection.BeginTransaction();
        sqlCommand.Transaction = transaction;
        try
        {
            SqlParameter pEmployeeId = new SqlParameter();
            pEmployeeId.ParameterName = "@employee_id";
            pEmployeeId.SqlDbType = SqlDbType.Int;
            pEmployeeId.Value = employee_id;
            sqlCommand.Parameters.Add(pEmployeeId);

            int result = sqlCommand.ExecuteNonQuery();
            if (result > 0)
            {
                Console.WriteLine("Delete success.");
            }
            else
            {
                Console.WriteLine("Delete failed.");
            }
            transaction.Commit();
            _connection.Close();
        }
        catch
        {
            transaction.Rollback();
            Console.WriteLine("Error connecting to database.");
        }
    }


    //GET BY ID HISTORIES
    public static void GetHistoriesById(int employee_id)
    {
        _connection = new SqlConnection(_connectionString);

        SqlCommand sqlCommand = new SqlCommand();
        sqlCommand.Connection = _connection;
        sqlCommand.CommandText = "SELECT * FROM histories WHERE Id = @employee_id";

        SqlParameter parameter = new SqlParameter();
        parameter.ParameterName = "@employee_id";
        parameter.SqlDbType = SqlDbType.VarChar;
        parameter.Value = employee_id;
        sqlCommand.Parameters.Add(parameter);

        try
        {
            _connection.Open();
            using SqlDataReader reader = sqlCommand.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Console.WriteLine("Start date: " + reader.GetDateTime(0));
                    Console.WriteLine("Employee id: " + reader.GetInt32(1));
                    Console.WriteLine("End date: " + reader.GetDateTime(2));
                    Console.WriteLine("Department id: " + reader.GetInt32(3));
                    Console.WriteLine("Job id: " + reader.GetString(4));
                }
            }
            else
            {
                Console.WriteLine("No countries found for the given ID.");
            }

            reader.Close();
            _connection.Close();
        }
        catch
        {
            Console.WriteLine("Error connecting to database.");
        }
    }


    public static void Menu()
    {
        bool exit = false;
        while (!exit)
        {
            Console.WriteLine("Main Menu:");
            Console.WriteLine("1. Regions");
            Console.WriteLine("2. Jobs");
            Console.WriteLine("3. Countries");
            Console.WriteLine("4. Locations");
            Console.WriteLine("5. Departmens");
            Console.WriteLine("6. Employees");
            Console.WriteLine("7. Histories");
            Console.WriteLine("0. Exit");
            Console.Write("Choose an option: ");
            string option = Console.ReadLine();

            switch (option)
            {
                case "1":
                    RegionsMenu();
                    break;
                case "2":
                    JobsMenu();
                    break;
                case "3":
                    CountriesMenu();
                    break;
                case "4":
                    LocationsMenu();
                    break;
                case "5":
                    DepartmensMenu();
                    break;
                case "6":
                    EmployeesMenu();
                    break;
                case "7":
                    HistoriesMenu();
                    break;
                case "0":
                    exit = true;
                    break;
                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }

            Console.WriteLine();
        }
    }

    public static void RegionsMenu()
    {
        bool back = false;
        while (!back)
        {
            Console.WriteLine("Regions Menu:");
            Console.WriteLine("1. Get All Regions");
            Console.WriteLine("2. Insert Region");
            Console.WriteLine("3. Update Region");
            Console.WriteLine("4. Delete Region");
            Console.WriteLine("5. Get Region by ID");
            Console.WriteLine("0. Back");
            Console.Write("Choose an option: ");
            string option = Console.ReadLine();

            switch (option)
            {
                case "1":
                    GetRegions();
                    break;
                case "2":
                    Console.Write("Enter region name: ");
                    string regionName = Console.ReadLine();
                    InsertRegions(regionName);
                    break;
                case "3":
                    Console.Write("Enter region ID: ");
                    int regionId = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Enter new region name: ");
                    string newRegionName = Console.ReadLine();
                    UpdateRegions(regionId, newRegionName);
                    break;
                case "4":
                    Console.Write("Enter region ID: ");
                    int deleteRegionId = Convert.ToInt32(Console.ReadLine());
                    DeleteRegions(deleteRegionId);
                    break;
                case "5":
                    Console.Write("Enter region ID: ");
                    int regionById = Convert.ToInt32(Console.ReadLine());
                    GetRegionsById(regionById);
                    break;
                case "0":
                    back = true;
                    break;
                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }

            Console.WriteLine();
        }
    }

    public static void JobsMenu()
    {
        bool back = false;
        while (!back)
        {
            Console.WriteLine("Jobs Menu:");
            Console.WriteLine("1. Get All Jobs");
            Console.WriteLine("2. Insert Job");
            Console.WriteLine("3. Update Job");
            Console.WriteLine("4. Delete Job");
            Console.WriteLine("5. Get Job by ID");
            Console.WriteLine("0. Back");
            Console.Write("Choose an option: ");
            string option = Console.ReadLine();

            switch (option)
            {
                case "1":
                    GetJobs();
                    break;
                case "2":
                    Console.Write("Enter job ID: ");
                    string jobId = Console.ReadLine();
                    Console.Write("Enter job title: ");
                    string jobTitle = Console.ReadLine();
                    Console.Write("Enter minimum salary: ");
                    int minSalary = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Enter maximum salary: ");
                    int maxSalary = Convert.ToInt32(Console.ReadLine());
                    InsertJobs(jobId, jobTitle, minSalary, maxSalary);
                    break;
                case "3":
                    Console.Write("Enter job ID: ");
                    string updateJobId = Console.ReadLine();
                    Console.Write("Enter new job title: ");
                    string newJobTitle = Console.ReadLine();
                    Console.Write("Enter new minimum salary: ");
                    int newMinSalary = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Enter new maximum salary: ");
                    int newMaxSalary = Convert.ToInt32(Console.ReadLine());
                    UpdateJobs(updateJobId, newJobTitle, newMinSalary, newMaxSalary);
                    break;
                case "4":
                    Console.Write("Enter job ID: ");
                    string deleteJobId = Console.ReadLine();
                    DeleteJobs(deleteJobId);
                    break;
                case "5":
                    Console.Write("Enter job ID: ");
                    string jobById = Console.ReadLine();
                    GetJobsById(jobById);
                    break;
                case "0":
                    back = true;
                    break;
                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }

            Console.WriteLine();
        }
    }

    public static void CountriesMenu()
    {
        bool back = false;
        while (!back)
        {
            Console.WriteLine("Countries Menu:");
            Console.WriteLine("1. Get All Countries");
            Console.WriteLine("2. Insert Country");
            Console.WriteLine("3. Update Country");
            Console.WriteLine("4. Delete Country");
            Console.WriteLine("5. Get Country by ID");
            Console.WriteLine("0. Back");
            Console.Write("Choose an option: ");
            string option = Console.ReadLine();

            switch (option)
            {
                case "1":
                    GetCountries();
                    break;
                case "2":
                    Console.Write("Enter country ID: ");
                    string countryId = Console.ReadLine();
                    Console.Write("Enter country name: ");
                    string countryName = Console.ReadLine();
                    Console.Write("Enter region ID: ");
                    int regionId = Convert.ToInt32(Console.ReadLine());
                    InsertCountries(countryId, countryName, regionId);
                    break;
                case "3":
                    Console.Write("Enter country ID: ");
                    string updateCountryId = Console.ReadLine();
                    Console.Write("Enter new country name: ");
                    string newCountryName = Console.ReadLine();
                    Console.Write("Enter new region ID: ");
                    int newRegionId = Convert.ToInt32(Console.ReadLine());
                    UpdateCountries(updateCountryId, newCountryName, newRegionId);
                    break;
                case "4":
                    Console.Write("Enter country ID: ");
                    string deleteCountryId = Console.ReadLine();
                    DeleteCountries(deleteCountryId);
                    break;
                case "5":
                    Console.Write("Enter country ID: ");
                    string countryById = Console.ReadLine();
                    GetCountriesById(countryById);
                    break;
                case "0":
                    back = true;
                    break;
                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }

            Console.WriteLine();
        }

    }


    public static void LocationsMenu()
    {
        bool back = false;
        while (!back)
        {
            Console.WriteLine("Locations Menu:");
            Console.WriteLine("1. Get All Locations");
            Console.WriteLine("2. Insert Location");
            Console.WriteLine("3. Update Location");
            Console.WriteLine("4. Delete Location");
            Console.WriteLine("5. Get Location by ID");
            Console.WriteLine("0. Back");
            Console.Write("Choose an option: ");
            string option = Console.ReadLine();

            switch (option)
            {
                case "1":
                    GetLocations();
                    break;
                case "2":
                    Console.Write("Enter location ID: ");
                    int locationId = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Enter street address: ");
                    string streetAddress = Console.ReadLine();
                    Console.Write("Enter postal code: ");
                    string postalCode = Console.ReadLine();
                    Console.Write("Enter city: ");
                    string city = Console.ReadLine();
                    Console.Write("Enter state province: ");
                    string stateProvince = Console.ReadLine();
                    Console.Write("Enter country ID: ");
                    string countryId = Console.ReadLine();
                    InsertLocations(locationId, streetAddress, postalCode, city, stateProvince, countryId);
                    break;
                case "3":
                    Console.Write("Enter location ID: ");
                    int updateLocationId = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Enter new street address: ");
                    string newStreetAddress = Console.ReadLine();
                    Console.Write("Enter new postal code: ");
                    string newPostalCode = Console.ReadLine();
                    Console.Write("Enter new city: ");
                    string newCity = Console.ReadLine();
                    Console.Write("Enter new state province: ");
                    string newStateProvince = Console.ReadLine();
                    Console.Write("Enter new country ID: ");
                    string newCountryId = Console.ReadLine();
                    UpdateLocations(updateLocationId, newStreetAddress, newPostalCode, newCity, newStateProvince, newCountryId);
                    break;
                case "4":
                    Console.Write("Enter location ID: ");
                    int deleteLocationId = Convert.ToInt32(Console.ReadLine());
                    DeleteLocations(deleteLocationId);
                    break;
                case "5":
                    Console.Write("Enter location ID: ");
                    int locationById = Convert.ToInt32(Console.ReadLine());
                    GetLocationsById(locationById);
                    break;
                case "0":
                    back = true;
                    break;
                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }

            Console.WriteLine();
        }
    }


    public static void DepartmensMenu()
    {
        bool back = false;
        while (!back)
        {
            Console.WriteLine("Departmens Menu:");
            Console.WriteLine("1. Get All Departmens");
            Console.WriteLine("2. Insert Department");
            Console.WriteLine("3. Update Department");
            Console.WriteLine("4. Delete Department");
            Console.WriteLine("5. Get Department by ID");
            Console.WriteLine("0. Back");
            Console.Write("Choose an option: ");
            string option = Console.ReadLine();

            switch (option)
            {
                case "1":
                    GetDepartmens();
                    break;
                case "2":
                    Console.Write("Enter department ID: ");
                    int departmentId = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Enter department name: ");
                    string departmentName = Console.ReadLine();
                    Console.Write("Enter location ID: ");
                    int locationId = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Enter manager ID: ");
                    int managerId = Convert.ToInt32(Console.ReadLine());
                    InsertDepartmens(departmentId, departmentName, locationId, managerId);
                    break;
                case "3":
                    Console.Write("Enter department ID: ");
                    int updateDepartmentId = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Enter new department name: ");
                    string newDepartmentName = Console.ReadLine();
                    Console.Write("Enter new location ID: ");
                    int newLocationId = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Enter new manager ID: ");
                    int newManagerId = Convert.ToInt32(Console.ReadLine());
                    UpdateDepartmens(updateDepartmentId, newDepartmentName, newLocationId, newManagerId);
                    break;
                case "4":
                    Console.Write("Enter department ID: ");
                    int deleteDepartmentId = Convert.ToInt32(Console.ReadLine());
                    DeleteDepartmens(deleteDepartmentId);
                    break;
                case "5":
                    Console.Write("Enter department ID: ");
                    int departmentById = Convert.ToInt32(Console.ReadLine());
                    GetDepartmensById(departmentById);
                    break;
                case "0":
                    back = true;
                    break;
                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }

            Console.WriteLine();
        }

    }


    public static void EmployeesMenu()
    {
        bool back = false;
        while (!back)
        {
            Console.WriteLine("Employees Menu:");
            Console.WriteLine("1. Get All Employees");
            Console.WriteLine("2. Insert Employee");
            Console.WriteLine("3. Update Employee");
            Console.WriteLine("4. Delete Employee");
            Console.WriteLine("5. Get Employee by ID");
            Console.WriteLine("0. Back");
            Console.Write("Choose an option: ");
            string option = Console.ReadLine();

            switch (option)
            {
                case "1":
                    GetEmployees();
                    break;
                case "2":
                    Console.Write("Enter employee ID: ");
                    int employeeId = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Enter first name: ");
                    string firstName = Console.ReadLine();
                    Console.Write("Enter last name: ");
                    string lastName = Console.ReadLine();
                    Console.Write("Enter email: ");
                    string email = Console.ReadLine();
                    Console.Write("Enter phone number: ");
                    string phoneNumber = Console.ReadLine();
                    Console.Write("Enter hire date (yyyy-mm-dd): ");
                    DateTime hireDate = Convert.ToDateTime(Console.ReadLine());
                    Console.Write("Enter salary: ");
                    int salary = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Enter commission percentage: ");
                    decimal commissionPct = Convert.ToDecimal(Console.ReadLine());
                    Console.Write("Enter manager ID: ");
                    int managerId = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Enter job ID: ");
                    int jobId = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Enter department ID: ");
                    int departmentId = Convert.ToInt32(Console.ReadLine());
                    InsertEmployees(employeeId, firstName, lastName, email, phoneNumber, hireDate, salary, commissionPct, managerId, jobId, departmentId);
                    break;
                case "3":
                    Console.Write("Enter employee ID: ");
                    int updateEmployeeId = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Enter new first name: ");
                    string newFirstName = Console.ReadLine();
                    Console.Write("Enter new last name: ");
                    string newLastName = Console.ReadLine();
                    Console.Write("Enter new email: ");
                    string newEmail = Console.ReadLine();
                    Console.Write("Enter new phone number: ");
                    string newPhoneNumber = Console.ReadLine();
                    Console.Write("Enter new hire date (yyyy-mm-dd): ");
                    DateTime newHireDate = Convert.ToDateTime(Console.ReadLine());
                    Console.Write("Enter new salary: ");
                    int newSalary = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Enter new commission percentage: ");
                    decimal newCommissionPct = Convert.ToDecimal(Console.ReadLine());
                    Console.Write("Enter new manager ID: ");
                    int newManagerId = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Enter new job ID: ");
                    int newJobId = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Enter new department ID: ");
                    int newDepartmentId = Convert.ToInt32(Console.ReadLine());
                    UpdateEmployees(updateEmployeeId, newFirstName, newLastName, newEmail, newPhoneNumber, newHireDate, newSalary, newCommissionPct, newManagerId, newJobId, newDepartmentId);
                    break;
                case "4":
                    Console.Write("Enter employee ID: ");
                    int deleteEmployeeId = Convert.ToInt32(Console.ReadLine());
                    DeleteEmployees(deleteEmployeeId);
                    break;
                case "5":
                    Console.Write("Enter employee ID: ");
                    int employeeById = Convert.ToInt32(Console.ReadLine());
                    GetEmployeesById(employeeById);
                    break;
                case "0":
                    back = true;
                    break;
                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }

            Console.WriteLine();
        }
    }

    public static void HistoriesMenu()
    {
        bool back = false;
        while (!back)
        {
            Console.WriteLine("Histories Menu:");
            Console.WriteLine("1. Get All Histories");
            Console.WriteLine("2. Insert Histories");
            Console.WriteLine("3. Update Histories");
            Console.WriteLine("4. Delete Histories");
            Console.WriteLine("5. Get Histories by Employee ID");
            Console.WriteLine("0. Back");
            Console.Write("Choose an option: ");
            string option = Console.ReadLine();

            switch (option)
            {
                case "1":
                    GetHistories();
                    break;
                case "2":
                    Console.Write("Enter start date (yyyy-mm-dd): ");
                    DateTime startDate = Convert.ToDateTime(Console.ReadLine());
                    Console.Write("Enter employee ID: ");
                    int employeeId = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Enter end date (yyyy-mm-dd): ");
                    DateTime endDate = Convert.ToDateTime(Console.ReadLine());
                    Console.Write("Enter department ID: ");
                    int departmentId = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Enter job ID: ");
                    string jobId = Console.ReadLine();
                    InsertHistories(startDate, employeeId, endDate, departmentId, jobId);
                    break;
                case "3":
                    Console.Write("Enter employee ID: ");
                    int updateEmployeeId = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Enter new start date (yyyy-mm-dd): ");
                    DateTime newStartDate = Convert.ToDateTime(Console.ReadLine());
                    Console.Write("Enter new end date (yyyy-mm-dd): ");
                    DateTime newEndDate = Convert.ToDateTime(Console.ReadLine());
                    Console.Write("Enter new department ID: ");
                    int newDepartmentId = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Enter new job ID: ");
                    string newJobId = Console.ReadLine();
                    UpdateHistories(updateEmployeeId, newStartDate, newEndDate, newDepartmentId, newJobId);
                    break;
                case "4":
                    Console.Write("Enter employee ID: ");
                    int deleteEmployeeId = Convert.ToInt32(Console.ReadLine());
                    DeleteHistories(deleteEmployeeId);
                    break;
                case "5":
                    Console.Write("Enter employee ID: ");
                    int employeeById = Convert.ToInt32(Console.ReadLine());
                    GetHistoriesById(employeeById);
                    break;
                case "0":
                    back = true;
                    break;
                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }

            Console.WriteLine();
        }
    }
}
