using System.Data.SqlClient;

namespace DatabaseConnectivity;

public class Connection
{
    private static string _connectionString = "Data Source=CAMOUFLY;Database=db_mcc_79;Integrated Security=True;Connect Timeout=30;";

    private static SqlConnection _connection;

    public static SqlConnection Get()
    {
        try
        {
            _connection = new SqlConnection(_connectionString);
            return _connection;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}