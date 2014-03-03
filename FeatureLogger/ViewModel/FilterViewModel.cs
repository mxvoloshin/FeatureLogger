using System;
using FeatureLogger.ServiceReference;
using GalaSoft.MvvmLight;

namespace FeatureLogger.ViewModel
{
    public class FilterViewModel : ViewModelBase
    {
        public FilterViewModel()
        {
            _filterByFid = false;
            _filterByPeriod = false;
            _filterByState = false;
            _filterByFeatureClass = false;
            _filterByUser = false;
        }
        
        private Boolean _filterByFid;
        public Boolean FilterByFid
        {
            get { return _filterByFid; }
            set
            {
                _filterByFid = value;
                RaisePropertyChanged("FilterByFid");

                if (_filterByFid)
                {
                    FilterByFeatureClass = false;   
                }
            }
        }

        private Boolean _filterByUser;
        public Boolean FilterByUser
        {
            get { return _filterByUser; }
            set
            {
                _filterByUser = value;
                RaisePropertyChanged("FilterByUser");
            }
        }

        private Boolean _filterByFeatureClass;
        public Boolean FilterByFeatureClass
        {
            get { return _filterByFeatureClass; }
            set
            {
                _filterByFeatureClass = value;
                RaisePropertyChanged("FilterByFeatureClass");

                if (_filterByFeatureClass)
                {
                    FilterByFid = false; 
                }
            }
        }

        private Boolean _filterByState;
        public Boolean FilterByState
        {
            get { return _filterByState; }
            set
            {
                _filterByState = value;
                RaisePropertyChanged("FilterByState");
            }
        }

        private Boolean _filterByPeriod;
        public Boolean FilterByPeriod
        {
            get { return _filterByPeriod; }
            set
            {
                _filterByPeriod = value;
                RaisePropertyChanged("FilterByPeriod");
            }
        }
    }
}
