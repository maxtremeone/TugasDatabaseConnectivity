using DatabaseConnectivity.Controllers;
using DatabaseConnectivity.Models;
using DatabaseConnectivity.Views;
using System;

namespace DatabaseConnectivity
{
    public class Program
    {
        private static VDepartment vDepartment;

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
                        case 2:
                            JobsMenu();
                            break;
                        case 3:
                            CountriesMenu();
                            break;
                        case 4:
                            LocationsMenu();
                            break;
                        case 5:
                            DepartmentsMenu();
                            break;
                        case 6:
                            EmployeesMenu();
                            break;
                        case 7:
                            HistoriesMenu();
                            break;
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
                    Console.WriteLine("Invalid option. Please try again.");
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
            Console.WriteLine("Your input is not valid!");
        }

        private static void PressAnyKey()
        {
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

        private static void JobsMenu()
        {
            Job job = new Job();
            VJob vJob = new VJob();
            JobController jobController = new JobController(job, vJob);


            bool isTrue = true;
            do
            {
                int pilihMenu = vJob.Menu();
                switch (pilihMenu)
                {
                    case 1:
                        jobController.UpdateJob();
                        PressAnyKey();
                        break;
                    case 2:
                        jobController.UpdateJob();
                        PressAnyKey();
                        break;
                    case 3:
                        jobController.DeleteJob();
                        PressAnyKey();
                        break;
                    case 4:
                        jobController.SearchJobById();
                        PressAnyKey();
                        break;
                    case 5:
                        jobController.GetAllJob();
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

        private static void CountriesMenu()
        {
            Country country = new Country();
            VCountry vCountry = new VCountry();
            CountryController countryController = new CountryController(country, vCountry);



            bool isTrue = true;
            do
            {
                int pilihMenu = vCountry.Menu();
                switch (pilihMenu)
                {
                    case 1:
                        countryController.UpdateCountry();
                        PressAnyKey();
                        break;
                    case 2:
                        countryController.UpdateCountry();
                        PressAnyKey();
                        break;
                    case 3:
                        countryController.DeleteCountry();
                        PressAnyKey();
                        break;
                    case 4:
                        countryController.SearchCountryById();
                        PressAnyKey();
                        break;
                    case 5:
                        countryController.GetAllCountry();
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


        private static void LocationsMenu()
        {
            Location location = new Location();
            VLocation vLocation = new VLocation();
            LocationController locationController = new LocationController(location, vLocation);

            bool isTrue = true;
            do
            {
                int pilihMenu = vLocation.Menu();
                switch (pilihMenu)
                {
                    case 1:
                        locationController.UpdateLocation();
                        PressAnyKey();
                        break;
                    case 2:
                        locationController.UpdateLocation();
                        PressAnyKey();
                        break;
                    case 3:
                        locationController.DeleteLocation();
                        PressAnyKey();
                        break;
                    case 4:
                        locationController.SearchLocationById();
                        PressAnyKey();
                        break;
                    case 5:
                        locationController.GetAllLocation();
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

        private static void DepartmentsMenu()
        {
            Department department = new Department();
            VDepartment vDepartment = new VDepartment();
            DepartmentController departmentController = new DepartmentController(department, vDepartment);

            bool isTrue = true;
            do
            {
                int pilihMenu = vDepartment.Menu();
                switch (pilihMenu)
                {
                    case 1:
                        departmentController.UpdateDepartment();
                        PressAnyKey();
                        break;
                    case 2:
                        departmentController.UpdateDepartment();
                        PressAnyKey();
                        break;
                    case 3:
                        departmentController.DeleteDepartment();
                        PressAnyKey();
                        break;
                    case 4:
                        departmentController.SearchDepartmentById();
                        PressAnyKey();
                        break;
                    case 5:
                        departmentController.GetAllDepartments();
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


        private static void EmployeesMenu()
        {
            Employee employee = new Employee();
            VEmployee vEmployee = new VEmployee();
            EmployeeController employeeController = new EmployeeController(employee, vEmployee);

            bool isTrue = true;
            do
            {
                int pilihMenu = vEmployee.Menu();
                switch (pilihMenu)
                {
                    case 1:
                        employeeController.InsertEmployee();
                        PressAnyKey();
                        break;
                    case 2:
                        employeeController.UpdateEmployee();
                        PressAnyKey();
                        break;
                    case 3:
                        employeeController.DeleteEmployee();
                        PressAnyKey();
                        break;
                    case 4:
                        employeeController.SearchEmployeeById();
                        PressAnyKey();
                        break;
                    case 5:
                        employeeController.GetAllEmployee();
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

        private static void HistoriesMenu()
        {
            History history = new History();
            VHistory vHistory = new VHistory();
            HistoryController historyController = new HistoryController(history, vHistory);

            bool isTrue = true;
            do
            {
                int pilihMenu = vHistory.Menu();
                switch (pilihMenu)
                {
                    case 1:
                        historyController.InsertHistory();
                        PressAnyKey();
                        break;
                    case 2:
                        historyController.UpdateHistory();
                        PressAnyKey();
                        break;
                    case 3:
                        historyController.DeleteHistory();
                        PressAnyKey();
                        break;
                    case 4:
                        historyController.SearchHistoryById();
                        PressAnyKey();
                        break;
                    case 5:
                        historyController.GetAllHistory();
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
    }
}
    

