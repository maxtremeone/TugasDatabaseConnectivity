using DatabaseConnectivity.Models;
//using MVCArchitecture.Models;

namespace MVCArchitecture.Controllers;

public class LinqController
{
    private Employee _employee;
    private Country _country;
    private Department _department;
    private Region _region;
    private Location _location;

    public LinqController(Employee employee, Country country, Region region, Location location, Department department)
    {
        _employee = employee;
        _country = country;
        _region = region;
        _location = location;
        _department = department;
    }

    public void DetailEmployee() 
    {
        var getEmployee = _employee.GetAll();
        var getDepartment = _department.GetAll();
        var getRegion = _region.GetAll();
        var getLocation = _location.GetAll();
        var getCountry = _country.GetAll();

        var detailEmployee = (from e in getEmployee
                              join d in getDepartment on e.DepartmentId equals d.Id
                              join l in getLocation on d.LocationId equals l.Id
                              join c in getCountry on l.CountryId equals c.Id
                              join r in getRegion on c.RegionId equals r.Id
                              select new LinQ(
                              
                                  e.Id,
                                  (e.FirstName + " " + e.LastName),
                                  e.Email,
                                  e.PhoneNumber,
                                  e.Salary,
                                  d.Name,
                                  l.StreetAddress,
                                  c.Name,
                                  r.Name)).ToList();

        foreach (var employee in detailEmployee)
        {
            Console.WriteLine($"{"Employee id : " + employee.Id}");
            Console.WriteLine($"{"Full Name : " + employee.FullName}");
            Console.WriteLine($"{"Email : " + employee.Email}");
            Console.WriteLine($"{"Phone Number : " + employee.PhoneNumber}");
            Console.WriteLine($"{"Department : " + employee.DepartmentName}");
            Console.WriteLine($"{"Salary : " + employee.Salary}");
            Console.WriteLine($"{"Street Address : " + employee.StreetAddress}");
            Console.WriteLine($"{"Country : " + employee.CountryName}");
            Console.WriteLine($"{"Region : " + employee.RegionName}");
            Console.WriteLine("===============================");
        }
    }
}

