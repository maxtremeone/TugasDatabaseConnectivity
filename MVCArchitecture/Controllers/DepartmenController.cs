using System;
using System.Collections.Generic;
using DatabaseConnectivity.Models;
using DatabaseConnectivity.Views;

namespace DatabaseConnectivity.Controllers
{
    public class DepartmentController
    {
        private Department _departmentModel;
        private VDepartment _departmentView;

        public DepartmentController(Department departmentModel, VDepartment departmentView)
        {
            _departmentModel = departmentModel;
            _departmentView = departmentView;
        }

        public void GetAllDepartments()
        {
            var result = _departmentModel.GetAll();
            if (result.Count == 0)
            {
                _departmentView.DataEmpty();
            }
            else
            {
                _departmentView.GetAll(result);
            }
        }

        public void InsertDepartment()
        {
            var department = _departmentView.InsertMenu();
            int result = _departmentModel.Insert(department);
            switch (result)
            {
                case -1:
                    _departmentView.Error();
                    break;
                case 0:
                    _departmentView.Failure();
                    break;
                default:
                    _departmentView.Success();
                    break;
            }
        }

        public void UpdateDepartment()
        {
            var department = _departmentView.UpdateMenu();
            int result = _departmentModel.Update(department);

            switch (result)
            {
                case -1:
                    _departmentView.Error();
                    break;
                case 0:
                    _departmentView.Failure();
                    break;
                default:
                    _departmentView.Success();
                    break;
            }
        }

        public void DeleteDepartment()
        {
            var id = _departmentView.DeleteMenu();
            var result = _departmentModel.Delete(id);

            switch (result)
            {
                case -1:
                    _departmentView.Error();
                    break;
                case 0:
                    _departmentView.Failure();
                    break;
                default:
                    _departmentView.Success();
                    break;
            }
        }

        public void SearchDepartmentById()
        {
            var id = _departmentView.SearchByIdMenu();
            var department = _departmentModel.GetById(id);

            if (department == null)
            {
                _departmentView.Failure();
            }
            else
            {
                _departmentView.GetById(department);
            }
        }
    }
}
