using DatabaseConnectivity.Models;
using DatabaseConnectivity.Views;
using System;

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

        public void InsertDepartment(int id, string name, int location_id, int manager_id)
        {
            var department = new Department
            {
                Id = id,
                Name = name,
                LocationId = location_id,
                ManagerId = manager_id
            };

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

        public void UpdateDepartment(int id, string name, int location_id, int manager_id)
        {
            var department = new Department
            {
                Id = id,
                Name = name,
                LocationId = location_id,
                ManagerId = manager_id
            };

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

        public void DeleteDepartment(int id)
        {
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

        public void SearchDepartmentById(int id)
        {
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

        internal void UpdateDepartment()
        {
            throw new NotImplementedException();
        }

        internal void DeleteDepartment()
        {
            throw new NotImplementedException();
        }

        internal void SearchDepartmentById()
        {
            throw new NotImplementedException();
        }
    }
}
