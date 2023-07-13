using DatabaseConnectivity.Controllers;
using DatabaseConnectivity.Models;
using DatabaseConnectivity.Views;
using System;

namespace DatabaseConnectivity.Controllers
{
    public class LocationController
    {
        private Location _locationModel;
        private VLocation _locationView;

        public LocationController(Location locationModel, VLocation locationView)
        {
            _locationModel = locationModel;
            _locationView = locationView;
        }

        public void GetAllLocation()
        {
            var result = _locationModel.GetAll();
            if (result.Count == 0)
            {
                _locationView.DataEmpty();
            }
            else
            {
                _locationView.GetAll(result);
            }
        }

        public void InsertLocation()
        {
            var location = _locationView.InsertMenu();
            int result = _locationModel.Insert(location);
            switch (result)
            {
                case -1:
                    _locationView.Error();
                    break;
                case 0:
                    _locationView.Failure();
                    break;
                default:
                    _locationView.Success();
                    break;
            }
        }

        public void UpdateLocation()
        {
            var location = _locationView.UpdateMenu();
            int result = _locationModel.Update(location);

            switch (result)
            {
                case -1:
                    _locationView.Error();
                    break;
                case 0:
                    _locationView.Failure();
                    break;
                default:
                    _locationView.Success();
                    break;
            }
        }

        public void DeleteLocation()
        {
            int id = _locationView.DeleteMenu();
            int result = _locationModel.Delete(id);

            switch (result)
            {
                case -1:
                    _locationView.Error();
                    break;
                case 0:
                    _locationView.Failure();
                    break;
                default:
                    _locationView.Success();
                    break;
            }
        }

        public void SearchLocationById()
        {
            int id = _locationView.SearchByIdMenu();
            var location = _locationModel.GetById(id);

            if (location == null)
            {
                _locationView.Failure();
            }
            else
            {
                _locationView.GetById(location);
            }
        }
    }
}
