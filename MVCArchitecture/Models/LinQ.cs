
using System.Data;
using System.Data.SqlClient;
using System.Transactions;

namespace DatabaseConnectivity.Models;

public class LinQ
{
    public LinQ(int id, string fullName, string email, string phoneNumber, int salary, string departmentName, string streetAddress, string countryName, string regionName)
    {
        Id = id;
        FullName = fullName;
        Email = email;
        PhoneNumber = phoneNumber;
        Salary = salary;
        DepartmentName = departmentName;
        StreetAddress = streetAddress;
        CountryName = countryName;
        RegionName = regionName;
    }
    public int Id { get; set; }
    public string FullName { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public int Salary { get; set; }
    public string DepartmentName { get; set; }
    public string StreetAddress { get; set; }
    public string CountryName { get; set; }
    public string RegionName { get; set; }

}




//e.Id,
//FullName = e.FirstName + " " + e.LastName,
//e.Email,
//e.PhoneNumber,
//e.Salary,
//DepartmentName = d.Name,
//StreetAddrees = l.StreetAddress,
//CountryName = c.Name,
//RegionName = r.Name,