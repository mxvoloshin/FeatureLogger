using System;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using Autodesk.Map.IM.Forms;
using FeatureLogger.ServiceReference;
using FeatureLogger.Services;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;

namespace FeatureLogger.ViewModel
{
    public enum SelectPeriod { Today = 0, Yesterday, ThisWeek, ThisMonth, ThisYear };

    public class FeatureLogViewModel : ViewModelBase
    {
        private readonly IAnalyzeService _analyzeService;

        public FeatureLogViewModel(IAnalyzeService service)
        {
            Messenger.Default.Register<Exception>(this, (exception) =>
            {
                var sb = new StringBuilder();
                sb.AppendLine("Exception:");
                sb.AppendLine(exception.Message);

                sb.AppendLine("Inner exception:");
                sb.AppendLine(exception.InnerException != null ? exception.InnerException.Message : string.Empty);
                
                System.Windows.MessageBox.Show(sb.ToString());
            });

            try
            {
                _analyzeService = service;
                _analyzeService.PageSize = 100;

                Filter = new FilterViewModel();

                Users = _analyzeService.GetUsers();
                FeatureClasses = _analyzeService.GetFeatureClasses();

                CommandApplyFilter = new RelayCommand(ApplyFilter);
                CommandTakeFirst = new RelayCommand(TakeFirst);
                CommandTakePrevious = new RelayCommand(TakePrevious);
                CommandTakeNext = new RelayCommand(TakeNext);
                CommandTakeLast = new RelayCommand(TakeLast);

                State = ModifyState.None;

                DateFrom = DateTime.Now;
                DateTo = DateTime.Now + new TimeSpan(1, 0, 0, 0);

                CurrentPage = 0;

                //LoadObjects();
            }
            catch (Exception ex)
            {
                Messenger.Default.Send(ex);
            }
        }

        private FilterViewModel _filterViewModel;

        public FilterViewModel Filter
        {
            get { return _filterViewModel; }
            set
            {
                _filterViewModel = value;
                RaisePropertyChanged("Filter");
            }
        }

        private Int64 _featureFid;
        public Int64 FeatureFid
        {
            get { return _featureFid; }
            set
            {
                _featureFid = value;
                RaisePropertyChanged("FeatureFid");
            }
        }

        private String _user;
        public String User
        {
            get { return _user; }
            set
            {
                _user = value;
                RaisePropertyChanged("User");
            }
        }

        private String _featureClass;
        public String FeatureClass
        {
            get { return _featureClass; }
            set
            {
                _featureClass = value;
                RaisePropertyChanged("FeatureClass");
            }
        }

        private ModifyState _state;
        public ModifyState State
        {
            get { return _state; }
            set
            {
                _state = value;
                RaisePropertyChanged("State");
            }
        }

        private DateTime _dateFrom;
        public DateTime DateFrom
        {
            get { return _dateFrom; }
            set
            {
                _dateFrom = value.Date;
                RaisePropertyChanged("DateFrom");
            }
        }

        private DateTime _dateTo;
        public DateTime DateTo
        {
            get { return _dateTo; }
            set
            {
                _dateTo = value.Date;
                RaisePropertyChanged("DateTo");
            }
        }
        public ObservableCollection<String> Users { get; set; }
        public ObservableCollection<String> FeatureClasses { get; set; }
        
        private ObservableCollection<ModificationInfo> _modificationInfos;
        public ObservableCollection<ModificationInfo> ModificationInfos 
        {
            get { return _modificationInfos; }
            set
            {
                _modificationInfos = value; 
                RaisePropertyChanged("ModificationInfos");
            }
        }

        private int TotalPageCount { get; set; }
        private int CurrentPage { get; set; }
        private int TotalCount { get; set; }

        private void UpdateNavigate()
        {
            try
            {
                if (CurrentPage == 0)
                {
                    HasPrevious = false;
                }
                else if (CurrentPage == TotalPageCount)
                {
                    HasNext = false;
                }

                if (CurrentPage != TotalPageCount && TotalCount > TotalPageCount * _analyzeService.PageSize)
                {
                    HasNext = true;
                }
                if (CurrentPage != 0 && CurrentPage * _analyzeService.PageSize < TotalCount)
                {
                    HasPrevious = true;
                }

                /*var currentCount = 0;
                if (CurrentPage == 0)
                {
                    currentCount = TotalCount > _analyzeService.PageSize ? _analyzeService.PageSize : TotalCount;
                }
                else if (CurrentPage == TotalPageCount)
                {
                    currentCount = TotalCount;
                }
                else
                {
                    currentCount = (CurrentPage + 1) * _analyzeService.PageSize;
                }*/

                int count = ModificationInfos.Count;
                CurrentPageDisplayText = string.Format(Properties.Resources.PageDisplay, count, TotalCount);
            }
            catch (Exception ex)
            {
                Messenger.Default.Send(ex);
            }
        }

        public ICommand CommandApplyFilter { get; set; }   
        public void ApplyFilter()
        {
            CurrentPage = 0;
            
            LoadObjects();
        }

        private void LoadObjects()
        {
            try
            {
                if (Filter.FilterByPeriod)
                {
                    if (DateFrom > DateTo)
                    {
                        var date = DateTo;
                        DateTo = DateFrom;
                        DateFrom = date;
                    }
                }

                String user = Filter.FilterByUser ? User : String.Empty;
                String featureClass = Filter.FilterByFeatureClass ? FeatureClass : String.Empty;
                ModifyState state = Filter.FilterByState ? State : ModifyState.None;
                Int64 featureFid = Filter.FilterByFid ? FeatureFid : 0;

                ModificationInfoDTO minfoDTO;

                if (!Filter.FilterByPeriod)
                {
                    minfoDTO = _analyzeService.GetModificationInfos(CurrentPage, featureFid, user, featureClass, state);
                }
                else
                {
                    minfoDTO = _analyzeService.GetModificationInfos(DateFrom, DateTo, CurrentPage, featureFid, user, featureClass, state);
                }

                TotalCount = minfoDTO.TotalCount;
                ModificationInfos = new ObservableCollection<ModificationInfo>(minfoDTO.Infos);

                TotalCount = minfoDTO.TotalCount;
                TotalPageCount = TotalCount / _analyzeService.PageSize;

                UpdateNavigate();
            }
            catch (Exception ex)
            {
                Messenger.Default.Send(ex);
            }
        }

        private ModificationInfo _selectedModificationInfo;
        public ModificationInfo SelectedModificationInfo {
            get { return _selectedModificationInfo; }
            set
            {
                _selectedModificationInfo = value;

                if (_selectedModificationInfo == null)
                {
                    SemanticsModificationInfos = new ObservableCollection<SemanticsModificationInfo>();
                }
                else
                {
                    try
                    {
                        SemanticsModificationInfos = _analyzeService.GetSemanticsModificationInfos(_selectedModificationInfo.ID);
                        GeometryModification = _analyzeService.GetGeometryModificationInfo(_selectedModificationInfo.ID);
                    }
                    catch (Exception ex)
                    {
                        Messenger.Default.Send<Exception>(ex);
                        return;
                    }
                }

                RaisePropertyChanged("SelectedModificationInfo");
            }
        }

        private ObservableCollection<SemanticsModificationInfo> _semanticsModificationInfos;
        public ObservableCollection<SemanticsModificationInfo> SemanticsModificationInfos
        {
            get { return _semanticsModificationInfos; }
            set
            {
                _semanticsModificationInfos = value;
                RaisePropertyChanged("SemanticsModificationInfos");
            }
        }

        private Boolean _hasPrevious;
        public Boolean HasPrevious
        {
            get { return _hasPrevious; }
            set
            {
                _hasPrevious = value;
                RaisePropertyChanged("HasPrevious");
            }
        }

        private Boolean _hasNext;
        public Boolean HasNext
        {
            get { return _hasNext; }
            set
            {
                _hasNext = value;
                RaisePropertyChanged("HasNext");
            }
        }

        public ICommand CommandTakeFirst { get; set; }
        public void TakeFirst()
        {
            CurrentPage = 0;
            LoadObjects();

            UpdateNavigate();
        }

        public ICommand CommandTakePrevious { get; set; }
        public void TakePrevious()
        {
            CurrentPage--;
            LoadObjects();

            UpdateNavigate();
        }

        public ICommand CommandTakeNext { get; set; }
        public void TakeNext()
        {
            CurrentPage++;
            LoadObjects();

            UpdateNavigate();
        }

        public ICommand CommandTakeLast { get; set; }
        public void TakeLast()
        {
            CurrentPage = TotalPageCount;
            LoadObjects();

            UpdateNavigate();
        }

        private String _currentPageDisplayText;
        public String CurrentPageDisplayText
        {
            get
            {
                return _currentPageDisplayText; 
            }
            set
            {
                _currentPageDisplayText = value;
                RaisePropertyChanged("CurrentPageDisplayText");
            }
        }

        private String _geometryModification;
        public String GeometryModification
        {
            get { return _geometryModification; }
            set
            {
                _geometryModification = value;
                RaisePropertyChanged("GeometryModification");
            }
        }
    }
}
