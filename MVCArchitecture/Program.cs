using DatabaseConnectivity.Controllers;
using DatabaseConnectivity.Models;
using DatabaseConnectivity.Views;
using System;

namespace DatabaseConnectivity
{
    public class Program
    {
        public static void Main()
        {
            Menu();
        }

        public static void Menu()
        {
            bool ulang = true;
            do
            {
                Console.WriteLine("Main Menu:");
                Console.WriteLine("1. Regions");
                Console.WriteLine("2. Jobs");
                Console.WriteLine("3. Countries");
                Console.WriteLine("4. Locations");
                Console.WriteLine("5. Departments");
                Console.WriteLine("6. Employees");
                Console.WriteLine("7. Histories");
                Console.WriteLine("0. Exit");
                string option = Console.ReadLine();

                try
                {
                    int optionInt = Int32.Parse(option);
                    switch (optionInt)
                    {
                        case 1:
                            RegionsMenu();
                            break;
                        //case 2:
                        //    jobsmenu();
                        //    break;
                        //case 3:
                        //    countriesmenu();
                        //    break;
                        //case 4:
                        //    locationsmenu();
                        //    break;
                        //case 5:
                        //    departmentsmenu();
                        //    break;
                        //case 6:
                        //    employeesmenu();
                        //    break;
                        //case 7:
                        //    historiesmenu();
                        //    break;
                        case 0:
                            ulang = false;
                            break;
                        default:
                            Console.WriteLine("Invalid option. Please try again.");
                            break;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("Invalid input. Please try again.");
                }

            } while (ulang);
        }

        private static void RegionsMenu()
        {
            Region region = new Region();
            VRegion vRegion = new VRegion();
            RegionController regionController = new RegionController(region, vRegion);

            bool isTrue = true;
            do
            {
                int pilihMenu = vRegion.Menu();
                switch (pilihMenu)
                {
                    case 1:
                        regionController.InsertRegion();
                        PressAnyKey();
                        break;
                    case 2:
                        regionController.UpdateRegion();
                        PressAnyKey();
                        break;
                    case 3:
                        regionController.DeleteRegion();
                        PressAnyKey();
                        break;
                    case 4:
                        regionController.SearchRegionById();
                        PressAnyKey();
                        break;
                    case 5:
                        regionController.GetAllRegion();
                        PressAnyKey();
                        break;
                    case 6:
                        isTrue = false;
                        break;
                    default:
                        InvalidInput();
                        break;
                }
            } while (isTrue);
        }

        private static void InvalidInput()
        {
            throw new NotImplementedException();
        }

        private static void PressAnyKey()
        {
            throw new NotImplementedException();
        }

        //    private static void JobsMenu()
        //    {
        //        Job job = new Job();
        //        VJob vJob = new VJob();
        //        JobController jobController = new JobController(job, vJob);
        //    }

        //    private static void CountriesMenu()
        //    {
        //        Country country = new Country();
        //        VCountry vCountry = new VCountry();
        //        CountryController countryController = new CountryController(country, vCountry);
        //    }

        //    private static void Countriesmenu()
        //    {
        //        throw new NotImplementedException();
        //    }

        //    private static void LocationsMenu()
        //    {
        //        Location location = new Location();
        //        VLocation vLocation = new VLocation();
        //        LocationController locationController = new LocationController(location, vLocation);
        //    }
        //}
    }
}
    

