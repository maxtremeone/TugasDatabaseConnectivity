using System;
using System.Collections.Generic;
using DatabaseConnectivity.Models;

namespace DatabaseConnectivity.Views
{
    public class VHistory
    {
        public void GetAll(List<History> histories)
        {
            foreach (var history in histories)
            {
                GetById(history);
            }
        }

        public void GetById(History history)
        {
            Console.WriteLine("Employee ID: " + history.EmployeeId);
            Console.WriteLine("Start Date: " + history.StartDate.ToString("yyyy-MM-dd"));
            Console.WriteLine("End Date: " + history.EndDate.ToString("yyyy-MM-dd"));
            Console.WriteLine("Department ID: " + history.DepartmentId);
            Console.WriteLine("Job ID: " + history.JobId);
            Console.WriteLine("==========================");
        }

        public void DataEmpty()
        {
            Console.WriteLine("Data Not Found!");
        }

        public void Success()
        {
            Console.WriteLine("Success!");
        }

        public void Failure()
        {
            Console.WriteLine("Fail, ID not found!");
        }

        public void Error()
        {
            Console.WriteLine("Error retrieving from the database!");
        }

        public int Menu()
        {
            Console.WriteLine("== History Menu ==");
            Console.WriteLine("1. Insert History");
            Console.WriteLine("2. Update History");
            Console.WriteLine("3. Delete History");
            Console.WriteLine("4. Search History by ID");
            Console.WriteLine("5. Get All Histories");
            Console.WriteLine("6. Main Menu");
            Console.WriteLine("Select an option: ");

            int input = Int32.Parse(Console.ReadLine());
            return input;
        }

        public History InsertMenu()
        {
            Console.WriteLine("Enter Employee ID: ");
            int employeeId = Int32.Parse(Console.ReadLine());

            Console.WriteLine("Enter Start Date (yyyy-MM-dd): ");
            DateTime startDate = DateTime.Parse(Console.ReadLine());

            Console.WriteLine("Enter End Date (yyyy-MM-dd): ");
            DateTime endDate = DateTime.Parse(Console.ReadLine());

            Console.WriteLine("Enter Department ID: ");
            int departmentId = Int32.Parse(Console.ReadLine());

            Console.WriteLine("Enter Job ID: ");
            string jobId = Console.ReadLine();

            return new History
            {
                EmployeeId = employeeId,
                StartDate = startDate,
                EndDate = endDate,
                DepartmentId = departmentId,
                JobId = jobId
            };
        }

        public History UpdateMenu()
        {
            Console.WriteLine("Enter the Employee ID to update: ");
            int employeeId = Int32.Parse(Console.ReadLine());

            Console.WriteLine("Enter new Start Date (yyyy-MM-dd): ");
            DateTime startDate = DateTime.Parse(Console.ReadLine());

            Console.WriteLine("Enter new End Date (yyyy-MM-dd): ");
            DateTime endDate = DateTime.Parse(Console.ReadLine());

            Console.WriteLine("Enter new Department ID: ");
            int departmentId = Int32.Parse(Console.ReadLine());

            Console.WriteLine("Enter new Job ID: ");
            string jobId = Console.ReadLine();

            return new History
            {
                EmployeeId = employeeId,
                StartDate = startDate,
                EndDate = endDate,
                DepartmentId = departmentId,
                JobId = jobId
            };
        }

        public int DeleteMenu()
        {
            Console.WriteLine("Enter the Employee ID to delete: ");
            int employeeId = Int32.Parse(Console.ReadLine());
            return employeeId;
        }

        public int SearchByIdMenu()
        {
            Console.WriteLine("Enter the Employee ID to search: ");
            int employeeId = Int32.Parse(Console.ReadLine());
            return employeeId;
        }
    }
}
