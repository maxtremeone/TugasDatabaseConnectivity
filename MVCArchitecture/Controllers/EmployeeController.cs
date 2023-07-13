using DatabaseConnectivity.Models;
using DatabaseConnectivity.Views;
using System;

namespace DatabaseConnectivity.Controllers
{
    public class EmployeeController
    {
        private Employee _employeeModel;
        private VEmployee _employeeView;

        public EmployeeController(Employee employeeModel, VEmployee employeeView)
        {
            _employeeModel = employeeModel;
            _employeeView = employeeView;
        }

        public void GetAllEmployee()
        {
            var result = _employeeModel.GetAll();
            if (result.Count == 0)
            {
                _employeeView.DataEmpty();
            }
            else
            {
                _employeeView.GetAll(result);
            }
        }

        public void InsertEmployee()
        {
            var employee = _employeeView.InsertMenu();
            int result = _employeeModel.Insert(employee);
            switch (result)
            {
                case -1:
                    _employeeView.Error();
                    break;
                case 0:
                    _employeeView.Failure();
                    break;
                default:
                    _employeeView.Success();
                    break;
            }
        }

        public void UpdateEmployee()
        {
            var employee = _employeeView.UpdateMenu();
            int result = _employeeModel.Update(employee);

            switch (result)
            {
                case -1:
                    _employeeView.Error();
                    break;
                case 0:
                    _employeeView.Failure();
                    break;
                default:
                    _employeeView.Success();
                    break;
            }
        }

        public void DeleteEmployee()
        {
            var id = _employeeView.DeleteMenu();
            var result = _employeeModel.Delete(id);

            switch (result)
            {
                case -1:
                    _employeeView.Error();
                    break;
                case 0:
                    _employeeView.Failure();
                    break;
                default:
                    _employeeView.Success();
                    break;
            }
        }

        public void SearchEmployeeById()
        {
            var id = _employeeView.SearchByIdMenu();
            var employee = _employeeModel.GetById(id);

            if (employee == null)
            {
                _employeeView.Failure();
            }
            else
            {
                _employeeView.GetById(employee);
            }
        }
    }
}
