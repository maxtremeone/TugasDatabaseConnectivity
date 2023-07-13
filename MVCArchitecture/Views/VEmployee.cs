using System;
using System.Collections.Generic;
using DatabaseConnectivity.Models;

namespace DatabaseConnectivity.Views
{
    public class VEmployee
    {
        public void GetAll(List<Employee> employees)
        {
            foreach (var employee in employees)
            {
                GetById(employee);
            }
        }

        public void GetById(Employee employee)
        {
            Console.WriteLine("Id: " + employee.Id);
            Console.WriteLine("First Name: " + employee.FirstName);
            Console.WriteLine("Last Name: " + employee.LastName);
            Console.WriteLine("Email: " + employee.Email);
            Console.WriteLine("Phone Number: " + employee.PhoneNumber);
            Console.WriteLine("Hire Date: " + employee.HireDate.ToString("yyyy-MM-dd"));
            Console.WriteLine("Salary: " + employee.Salary);
            Console.WriteLine("Commission Pct: " + employee.CommissionPct);
            Console.WriteLine("Manager Id: " + employee.ManagerId);
            Console.WriteLine("Job Id: " + employee.JobId);
            Console.WriteLine("Department Id: " + employee.DepartmentId);
            Console.WriteLine("==========================");
        }

        public int Menu()
        {
            Console.WriteLine("== Employee Menu ==");
            Console.WriteLine("1. Insert Employee");
            Console.WriteLine("2. Update Employee");
            Console.WriteLine("3. Delete Employee");
            Console.WriteLine("4. Search Employee by ID");
            Console.WriteLine("5. Get All Employees");
            Console.WriteLine("6. Main Menu");
            Console.WriteLine("Select an option: ");

            int input = Int32.Parse(Console.ReadLine());
            return input;
        }

        public Employee InsertMenu()
        {
            Console.WriteLine("Enter ID: ");
            int id = Int32.Parse(Console.ReadLine());

            Console.WriteLine("Enter First Name: ");
            string firstName = Console.ReadLine();

            Console.WriteLine("Enter Last Name: ");
            string lastName = Console.ReadLine();

            Console.WriteLine("Enter Email: ");
            string email = Console.ReadLine();

            Console.WriteLine("Enter Phone Number: ");
            string phoneNumber = Console.ReadLine();

            Console.WriteLine("Enter Hire Date (yyyy-MM-dd): ");
            DateTime hireDate = DateTime.Parse(Console.ReadLine());

            Console.WriteLine("Enter Salary: ");
            int salary = Int32.Parse(Console.ReadLine());

            Console.WriteLine("Enter Commission Pct: ");
            decimal commissionPct = Decimal.Parse(Console.ReadLine());

            Console.WriteLine("Enter Manager ID: ");
            int managerId = Int32.Parse(Console.ReadLine());

            Console.WriteLine("Enter Job ID: ");
            int jobId = Int32.Parse(Console.ReadLine());

            Console.WriteLine("Enter Department ID: ");
            int departmentId = Int32.Parse(Console.ReadLine());

            return new Employee
            {
                Id = id,
                FirstName = firstName,
                LastName = lastName,
                Email = email,
                PhoneNumber = phoneNumber,
                HireDate = hireDate,
                Salary = salary,
                CommissionPct = commissionPct,
                ManagerId = managerId,
                JobId = jobId,
                DepartmentId = departmentId
            };
        }

        public Employee UpdateMenu()
        {
            Console.WriteLine("Enter the ID to update: ");
            int id = Int32.Parse(Console.ReadLine());

            Console.WriteLine("Enter new First Name: ");
            string firstName = Console.ReadLine();

            Console.WriteLine("Enter new Last Name: ");
            string lastName = Console.ReadLine();

            Console.WriteLine("Enter new Email: ");
            string email = Console.ReadLine();

            Console.WriteLine("Enter new Phone Number: ");
            string phoneNumber = Console.ReadLine();

            Console.WriteLine("Enter new Hire Date (yyyy-MM-dd): ");
            DateTime hireDate = DateTime.Parse(Console.ReadLine());

            Console.WriteLine("Enter new Salary: ");
            int salary = Int32.Parse(Console.ReadLine());

            Console.WriteLine("Enter new Commission Pct: ");
            decimal commissionPct = Decimal.Parse(Console.ReadLine());

            Console.WriteLine("Enter new Manager ID: ");
            int managerId = Int32.Parse(Console.ReadLine());

            Console.WriteLine("Enter new Job ID: ");
            int jobId = Int32.Parse(Console.ReadLine());

            Console.WriteLine("Enter new Department ID: ");
            int departmentId = Int32.Parse(Console.ReadLine());

            return new Employee
            {
                Id = id,
                FirstName = firstName,
                LastName = lastName,
                Email = email,
                PhoneNumber = phoneNumber,
                HireDate = hireDate,
                Salary = salary,
                CommissionPct = commissionPct,
                ManagerId = managerId,
                JobId = jobId,
                DepartmentId = departmentId
            };
        }

        public int DeleteMenu()
        {
            Console.WriteLine("Enter the ID to delete: ");
            int id = Int32.Parse(Console.ReadLine());
            return id;
        }

        public int SearchByIdMenu()
        {
            Console.WriteLine("Enter the ID to search: ");
            int id = Int32.Parse(Console.ReadLine());
            return id;
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
            Console.WriteLine("Fail, Id not found!");
        }

        public void Error()
        {
            Console.WriteLine("Error retrieving from the database!");
        }
    }
}
