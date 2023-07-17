using System;
using System.Collections.Generic;
using DatabaseConnectivity.Models;

namespace DatabaseConnectivity.Views
{
    public class VLinQ
    {
        public void TampilkanEmployeeData(List<LinQ> employees)
        {
            foreach (var employee in employees)
            {
                Console.WriteLine($"Id: {employee.Id}");
                Console.WriteLine($"Full Name: {employee.FullName}");
                Console.WriteLine($"Email: {employee.Email}");
                Console.WriteLine($"Phone Number: {employee.PhoneNumber}");
                Console.WriteLine($"Salary: {employee.Salary}");
                Console.WriteLine($"Department Name: {employee.DepartmentName}");
                Console.WriteLine($"Street Address: {employee.StreetAddress}");
                Console.WriteLine($"Country Name: {employee.CountryName}");
                Console.WriteLine($"Region Name: {employee.RegionName}");
                Console.WriteLine("==========================");
            }
        }
    }
}

        