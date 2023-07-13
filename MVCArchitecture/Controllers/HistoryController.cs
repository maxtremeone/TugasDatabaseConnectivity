using System;
using System.Collections.Generic;
using DatabaseConnectivity.Models;
using DatabaseConnectivity.Views;

namespace DatabaseConnectivity.Controllers
{
    public class HistoryController
    {
        private History _historyModel;
        private VHistory _historyView;

        public HistoryController(History historyModel, VHistory historyView)
        {
            _historyModel = historyModel;
            _historyView = historyView;
        }

        public void GetAllHistory()
        {
            var result = _historyModel.GetAll();
            if (result.Count == 0)
            {
                _historyView.DataEmpty();
            }
            else
            {
                _historyView.GetAll(result);
            }
        }

        public void InsertHistory()
        {
            var history = _historyView.InsertMenu();
            int result = _historyModel.Insert(history);
            switch (result)
            {
                case -1:
                    _historyView.Error();
                    break;
                case 0:
                    _historyView.Failure();
                    break;
                default:
                    _historyView.Success();
                    break;
            }
        }

        public void UpdateHistory()
        {
            var history = _historyView.UpdateMenu();
            int result = _historyModel.Update(history);

            switch (result)
            {
                case -1:
                    _historyView.Error();
                    break;
                case 0:
                    _historyView.Failure();
                    break;
                default:
                    _historyView.Success();
                    break;
            }
        }

        public void DeleteHistory()
        {
            var id = _historyView.DeleteMenu();
            var result = _historyModel.Delete(id);

            switch (result)
            {
                case -1:
                    _historyView.Error();
                    break;
                case 0:
                    _historyView.Failure();
                    break;
                default:
                    _historyView.Success();
                    break;
            }
        }

        public void SearchHistoryById()
        {
            var id = _historyView.SearchByIdMenu();
            var history = _historyModel.GetById(id);

            if (history == null)
            {
                _historyView.Failure();
            }
            else
            {
                _historyView.GetById(history);
            }
        }
    }
}
