using System;
using System.Collections.Generic;
using DatabaseConnectivity.Models;

namespace DatabaseConnectivity.Views
{
    public class VDepartment
    {
        public void GetAll(List<Department> departments)
        {
            foreach (var department in departments)
            {
                GetById(department);
            }
        }

        public void GetById(Department department)
        {
            Console.WriteLine("Id: " + department.Id);
            Console.WriteLine("Name: " + department.Name);
            Console.WriteLine("Location Id: " + department.LocationId);
            Console.WriteLine("Manager Id: " + department.ManagerId);
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
            Console.WriteLine("Fail, Id not found!");
        }

        public void Error()
        {
            Console.WriteLine("Error retrieving from the database!");
        }

        public int Menu()
        {
            Console.WriteLine("== Department Menu ==");
            Console.WriteLine("1. Insert Department");
            Console.WriteLine("2. Update Department");
            Console.WriteLine("3. Delete Department");
            Console.WriteLine("4. Search Department by ID");
            Console.WriteLine("5. Get All Departments");
            Console.WriteLine("6. Main Menu");
            Console.WriteLine("Select an option: ");

            int input = Int32.Parse(Console.ReadLine());
            return input;
        }

        public Department InsertMenu()
        {
            Console.WriteLine("Enter ID: ");
            int id = Int32.Parse(Console.ReadLine());

            Console.WriteLine("Enter Name: ");
            string name = Console.ReadLine();

            Console.WriteLine("Enter Location ID: ");
            int locationId = Int32.Parse(Console.ReadLine());

            Console.WriteLine("Enter Manager ID: ");
            int managerId = Int32.Parse(Console.ReadLine());

            return new Department
            {
                Id = id,
                Name = name,
                LocationId = locationId,
                ManagerId = managerId
            };
        }

        public Department UpdateMenu()
        {
            Console.WriteLine("Enter the ID to update: ");
            int id = Int32.Parse(Console.ReadLine());

            Console.WriteLine("Enter new Name: ");
            string name = Console.ReadLine();

            Console.WriteLine("Enter new Location ID: ");
            int locationId = Int32.Parse(Console.ReadLine());

            Console.WriteLine("Enter new Manager ID: ");
            int managerId = Int32.Parse(Console.ReadLine());

            return new Department
            {
                Id = id,
                Name = name,
                LocationId = locationId,
                ManagerId = managerId
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
    }
}
