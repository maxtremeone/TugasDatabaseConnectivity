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
        //----------------------------------------EKSEKUSI READ
        //GetDepartmens();

        //----------------------------------------EKSEKUSI INSERT
        // InsertLocations(21, "359 Street", "7878", "City 21", "State 21", "ZZ");
        //InsertDepartments(20, "IT Program", 21, 12);

        //----------------------------------------EKSEKUSI UPDATE

        //int Id = 20;
        //string newName = "IT Program";
        //int newLocationId = 7 ;
        //int newManagerId = 9;

        //UpdateDepartmens(Id, newName, newLocationId, newManagerId);
        //------------------------------------------------------------------
        //int Id = 21;
        //string newStreetAddress = "627 Street";
        //string newPostalCode = "6341";
        //string newCity = "Pringsewu";
        //string newStateProvince = "Lampung";
        //string newCountryId = "ID";

        //UpdateLocations(Id, newStreetAddress, newPostalCode, newCity, newStateProvince, newCountryId);

        //----------------------------------------EKSEKUSI DELETE
        //DeleteDepartmens(20);

        //----------------------------------------EKSEKUSI GET BY
        int Id = 1;

        GetDepartmensById(Id);
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


    //--------------------DELETE COUNTRIES TIDAK BISA DIHAPUS KARENA TABEL BERELASI DENGAN LOCATION
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
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
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
    public static void InsertLocations(int id, string street_address, string postal_code, string city, string state_province, string country_id)
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
                    //Console.WriteLine("ManagerId: " + reader.GetInt32(3));
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
    public static void InsertDepartments(int id, string name, int location_id, int manager_id)
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
        catch
        {
            transaction.Rollback();
            Console.WriteLine("Error connecting to database.");
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
                    //Console.WriteLine("ManagerId: " + reader.GetInt32(3));
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
}
