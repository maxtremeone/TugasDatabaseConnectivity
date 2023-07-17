using DatabaseConnectivity.Models;
using DatabaseConnectivity.Views;
using System;

namespace DatabaseConnectivity.Controllers
{
    public class JobController
    {
        private Job _jobModel;
        private VJob _jobView;

        public JobController(Job jobModel, VJob jobView)
        {
            _jobModel = jobModel;
            _jobView = jobView;
        }

        public void GetAllJobs()
        {
            var result = _jobModel.GetAll();
            if (result.Count == 0)
            {
                _jobView.DataEmpty();
            }
            else
            {
                _jobView.GetAll(result);
            }
        }

        public void InsertJob()
        {
            var job = _jobView.InsertMenu();
            int result = _jobModel.Insert(job);
            switch (result)
            {
                case -1:
                    _jobView.Error();
                    break;
                case 0:
                    _jobView.Failure();
                    break;
                default:
                    _jobView.Success();
                    break;
            }
        }

        public void UpdateJob()
        {
            var job = _jobView.UpdateMenu();
            int result = _jobModel.Update(job);

            switch (result)
            {
                case -1:
                    _jobView.Error();
                    break;
                case 0:
                    _jobView.Failure();
                    break;
                default:
                    _jobView.Success();
                    break;
            }
        }

        public void DeleteJob()
        {
            var id = _jobView.DeleteMenu();
            var result = _jobModel.Delete(id);

            switch (result)
            {
                case -1:
                    _jobView.Error();
                    break;
                case 0:
                    _jobView.Failure();
                    break;
                default:
                    _jobView.Success();
                    break;
            }
        }

        public void SearchJobById()
        {
            var id = _jobView.SearchByIdMenu();
            var job = _jobModel.GetById(id);

            if (job == null)
            {
                _jobView.Failure();
            }
            else
            {
                _jobView.GetById(job);
            }
        }
    }
}
