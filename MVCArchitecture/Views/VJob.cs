using System;
using System.Collections.Generic;
using DatabaseConnectivity.Models;

namespace DatabaseConnectivity.Views
{
    public class VJob
    {
        public void GetAll(List<Job> jobs)
        {
            foreach (var job in jobs)
            {
                GetById(job);
            }
        }

        public void GetById(Job job)
        {
            Console.WriteLine("Id: " + job.Id);
            Console.WriteLine("Title: " + job.Title);
            Console.WriteLine("Min Salary: " + job.MinSalary);
            Console.WriteLine("Max Salary: " + job.MaxSalary);
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
            Console.WriteLine("== Job Menu ==");
            Console.WriteLine("1. Insert Job");
            Console.WriteLine("2. Update Job");
            Console.WriteLine("3. Delete Job");
            Console.WriteLine("4. Search Job by ID");
            Console.WriteLine("5. Get All Jobs");
            Console.WriteLine("6. Main Menu");
            Console.WriteLine("Select an option: ");

            int input = Int32.Parse(Console.ReadLine());
            return input;
        }

        public Job InsertMenu()
        {
            Console.WriteLine("Enter ID: ");
            string id = Console.ReadLine();

            Console.WriteLine("Enter Title: ");
            string title = Console.ReadLine();

            Console.WriteLine("Enter Min Salary: ");
            int minSalary = Int32.Parse(Console.ReadLine());

            Console.WriteLine("Enter Max Salary: ");
            int maxSalary = Int32.Parse(Console.ReadLine());

            return new Job
            {
                Id = id,
                Title = title,
                MinSalary = minSalary,
                MaxSalary = maxSalary
            };
        }

        public Job UpdateMenu()
        {
            Console.WriteLine("Enter the ID to update: ");
            string id = Console.ReadLine();

            Console.WriteLine("Enter new Title: ");
            string title = Console.ReadLine();

            Console.WriteLine("Enter new Min Salary: ");
            int minSalary = Int32.Parse(Console.ReadLine());

            Console.WriteLine("Enter new Max Salary: ");
            int maxSalary = Int32.Parse(Console.ReadLine());

            return new Job
            {
                Id = id,
                Title = title,
                MinSalary = minSalary,
                MaxSalary = maxSalary
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

        internal Job GetById(string id)
        {
            throw new NotImplementedException();
        }
    }
}
