using System;
using System.Collections.Generic;
using DatabaseConnectivity.Models;

namespace DatabaseConnectivity.Views
{
    public class VLocation
    {
        public void GetAll(List<Location> locations)
        {
            foreach (var location in locations)
            {
                GetById(location);
            }
        }

        public void GetById(Location location)
        {
            Console.WriteLine("Id: " + location.Id);
            Console.WriteLine("Street Address: " + location.StreetAddress);
            Console.WriteLine("Postal Code: " + location.PostalCode);
            Console.WriteLine("City: " + location.City);
            Console.WriteLine("State/Province: " + location.StateProvince);
            Console.WriteLine("Country Id: " + location.CountryId);
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
            Console.WriteLine("== Location Menu ==");
            Console.WriteLine("1. Insert Location");
            Console.WriteLine("2. Update Location");
            Console.WriteLine("3. Delete Location");
            Console.WriteLine("4. Search Location by ID");
            Console.WriteLine("5. Get All Locations");
            Console.WriteLine("6. Main Menu");
            Console.WriteLine("Select an option: ");

            int input = Int32.Parse(Console.ReadLine());
            return input;
        }

        public Location InsertMenu()
        {
            Console.WriteLine("Enter ID: ");
            int id = Int32.Parse(Console.ReadLine());

            Console.WriteLine("Enter Street Address: ");
            string streetAddress = Console.ReadLine();

            Console.WriteLine("Enter Postal Code: ");
            string postalCode = Console.ReadLine();

            Console.WriteLine("Enter City: ");
            string city = Console.ReadLine();

            Console.WriteLine("Enter State/Province: ");
            string stateProvince = Console.ReadLine();

            Console.WriteLine("Enter Country ID: ");
            string countryId = Console.ReadLine();

            return new Location
            {
                Id = id,
                StreetAddress = streetAddress,
                PostalCode = postalCode,
                City = city,
                StateProvince = stateProvince,
                CountryId = countryId
            };
        }

        public Location UpdateMenu()
        {
            Console.WriteLine("Enter the ID to update: ");
            int id = Int32.Parse(Console.ReadLine());

            Console.WriteLine("Enter new Street Address: ");
            string streetAddress = Console.ReadLine();

            Console.WriteLine("Enter new Postal Code: ");
            string postalCode = Console.ReadLine();

            Console.WriteLine("Enter new City: ");
            string city = Console.ReadLine();

            Console.WriteLine("Enter new State/Province: ");
            string stateProvince = Console.ReadLine();

            Console.WriteLine("Enter new Country ID: ");
            string countryId = Console.ReadLine();

            return new Location
            {
                Id = id,
                StreetAddress = streetAddress,
                PostalCode = postalCode,
                City = city,
                StateProvince = stateProvince,
                CountryId = countryId
            };
        }

        public int DeleteMenu()
        {
            Console.WriteLine("Enter the ID to delete: ");
            int id = Int32.Parse(Console.ReadLine());
            return id;
        }

        internal int SearchByIdMenu()
        {
            throw new NotImplementedException();
        }
    }
}
