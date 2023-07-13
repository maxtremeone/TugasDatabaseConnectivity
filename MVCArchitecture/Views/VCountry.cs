using System;
using System.Collections.Generic;
using DatabaseConnectivity.Models;

namespace DatabaseConnectivity.Views
{
    public class VCountry
    {
        public void GetAll(List<Country> countries)
        {
            foreach (var country in countries)
            {
                GetById(country);
            }
        }

        public void GetById(Country country)
        {
            Console.WriteLine("Id: " + country.Id);
            Console.WriteLine("Name: " + country.Name);
            Console.WriteLine("Region Id: " + country.RegionId);
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
            Console.WriteLine("== Country Menu ==");
            Console.WriteLine("1. Insert Country");
            Console.WriteLine("2. Update Country");
            Console.WriteLine("3. Delete Country");
            Console.WriteLine("4. Search Country by ID");
            Console.WriteLine("5. Get All Countries");
            Console.WriteLine("6. Main Menu");
            Console.WriteLine("Select an option: ");

            int input = Int32.Parse(Console.ReadLine());
            return input;
        }

        public Country InsertMenu()
        {
            Console.WriteLine("Enter ID: ");
            string id = Console.ReadLine();

            Console.WriteLine("Enter Name: ");
            string name = Console.ReadLine();

            Console.WriteLine("Enter Region ID: ");
            int regionId = Int32.Parse(Console.ReadLine());

            return new Country
            {
                Id = id,
                Name = name,
                RegionId = regionId
            };
        }

        public Country UpdateMenu()
        {
            Console.WriteLine("Enter the ID to update: ");
            string id = Console.ReadLine();

            Console.WriteLine("Enter new Name: ");
            string name = Console.ReadLine();

            Console.WriteLine("Enter new Region ID: ");
            int regionId = Int32.Parse(Console.ReadLine());

            return new Country
            {
                Id = id,
                Name = name,
                RegionId = regionId
            };
        }

        public string DeleteMenu()
        {
            Console.WriteLine("Enter the ID to delete: ");
            string id = Console.ReadLine();
            return id;
        }

        internal string SearchByIdMenu()
        {
            throw new NotImplementedException();
        }

        internal Country GetById(string id)
        {
            throw new NotImplementedException();
        }
    }
}
