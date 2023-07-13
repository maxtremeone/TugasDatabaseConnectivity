using DatabaseConnectivity.Models;
using DatabaseConnectivity.Views;
using System;

namespace DatabaseConnectivity.Controllers
{
    public class RegionController
    {
        private Region _regionModel;
        private VRegion _regionView;

        public RegionController(Region regionModel, VRegion regionView)
        {
            _regionModel = regionModel;
            _regionView = regionView;
        }

        public void GetAllRegion()
        {
            var result = _regionModel.GetAll();
            if (result.Count == 0)
            {
                _regionView.DataEmpty();
            }
            else
            {
                _regionView.GetAll(result);
            }
        }

        public void InsertRegion()
        {
            var region = _regionView.InsertMenu();
            int result = _regionModel.Insert(region);
            switch (result)
            {
                case -1:
                    _regionView.Error();
                    break;
                case 0:
                    _regionView.Failure();
                    break;
                default:
                    _regionView.Success();
                    break;
            } 
        }

        public void UpdateRegion()
        {
            var region = _regionView.UpdateMenu();
            int result = _regionModel.Update(region);

            switch (result)
            {
                case -1:
                    _regionView.Error();
                    break;
                case 0:
                    _regionView.Failure();
                    break;
                default:
                    _regionView.Success();
                    break;
            }
        }

        public void DeleteRegion()
        {
            int id = _regionView.DeleteMenu();
            int result = _regionModel.Delete(id);

            switch (result)
            {
                case -1:
                    _regionView.Error();
                    break;
                case 0:
                    _regionView.Failure();
                    break;
                default:
                    _regionView.Success();
                    break;
            }
        }

        public void SearchRegionById()
        {
            var id = _regionView.SearchByIdMenu();
            var region = _regionModel.GetById(id);
            
            if (region == null)
            {
                _regionView.Failure();
            }
            else
            {
                _regionView.GetById(region);
            }
        }
    }
}
