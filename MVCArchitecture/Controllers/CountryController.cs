//using DatabaseConnectivity.Models;
//using DatabaseConnectivity.Views;
//using System;

//namespace DatabaseConnectivity.Controllers
//{
//    public class CountryController
//    {
//        private Country _countryModel;
//        private VCountry _countryView;

//        public CountryController(Country countryModel, VCountry countryView)
//        {
//            _countryModel = countryModel;
//            _countryView = countryView;
//        }

//        public void GetAllCountry()
//        {
//            var result = _countryModel.GetAll();
//            if (result.Count == 0)
//            {
//                _countryView.DataEmpty();
//            }
//            else
//            {
//                _countryView.GetAll(result);
//            }
//        }

//        public void InsertCountry()
//        {
//            var country = _countryView.InsertMenu();
//            int country = _countryModel.Insert(country);
//            switch (result)
//            {
//                case -1:
//                    _countryView.Error();
//                    break;
//                case 0:
//                    _countryView.Failure();
//                    break;
//                default:
//                    _countryView.Success();
//                    break;
//            }
//        }

//        public void UpdateCountry()
//        {
//            var country = _countryView.UpdateMenu();
//            int result = _countryModel.Update(country);

//            switch (result)
//            {
//                case -1:
//                    _countryView.Error();
//                    break;
//                case 0:
//                    _countryView.Failure();
//                    break;
//                default:
//                    _countryView.Success();
//                    break;
//            }
//        }

//        public void DeleteCountry()
//        {
//            var id = _countryView.DeleteMenu();
//            var result = _countryModel.Delete(id);

//            switch (result)
//            {
//                case -1:
//                    _countryView.Error();
//                    break;
//                case 0:
//                    _countryView.Failure();
//                    break;
//                default:
//                    _countryView.Success();
//                    break;
//            }
//        }

//        public void SearchCountryById()
//        {
//            var id = _countryView.SearchByIdMenu();
//            var country = _countryModel.GetById(id);

//            if (country == null)
//            {
//                _countryView.Failure();
//            }
//            else
//            {
//                _countryView.GetById(country);
//            }
//        }
//    }
//}
