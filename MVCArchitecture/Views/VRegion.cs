using System;
using System.Collections.Generic;
using DatabaseConnectivity.Models;

namespace DatabaseConnectivity.Views
{
    public class VRegion
    {
        public void GetAll(List<Region> regions)
        {
            foreach (var region in regions)
            {
                GetById(region);
            }
        }

        public void GetById(Region region)
        {
            Console.WriteLine("Id: " + region.Id);
            Console.WriteLine("Name: " + region.Name);
            Console.WriteLine("Region Id: " + region.RegionId);
            Console.WriteLine("==========================");
        }

        public string SearchByIdMenu()
        {
            Console.WriteLine("Enter the ID to search: ");
            string id = Console.ReadLine();
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

        public int Menu()
        {
            Console.WriteLine("== Region Menu ==");
            Console.WriteLine("1. Insert Region");
            Console.WriteLine("2. Update Region");
            Console.WriteLine("3. Delete Region");
            Console.WriteLine("4. Search Region by ID");
            Console.WriteLine("5. Get All Regions");
            Console.WriteLine("6. Main Menu");
            Console.WriteLine("Select an option: ");

            int input = Int32.Parse(Console.ReadLine());
            return input;
        }

        public Region InsertMenu()
        {
            Console.WriteLine("Enter Name: ");
            string inputName = Console.ReadLine();

            return new Region
            {
                Id = 0,
                Name = inputName
            };
        }

        public Region UpdateMenu()
        {
            Console.WriteLine("Enter the ID to update: ");
            int id = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter new Name: ");
            string name = Console.ReadLine();

            return new Region
            {
                Id = id,
                Name = name
            };
        }

        public int DeleteMenu()
        {
            Console.WriteLine("Enter the ID to delete: ");
            int id = Convert.ToInt32(Console.ReadLine());
            return id;
        }

        //internal int SearchByIdMenu()
        //{
        //    throw new NotImplementedException();
        //}
    }
}
