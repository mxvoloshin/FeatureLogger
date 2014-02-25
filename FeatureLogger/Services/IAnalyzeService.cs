using System;
using System.Collections.ObjectModel;
using System.Linq;
using FeatureLogger.ServiceReference;
using FeatureLogger.ViewModel;

namespace FeatureLogger.Services
{
    public interface IAnalyzeService
    {
        int PageSize { get; set; }
        ObservableCollection<String> GetUsers();
        ObservableCollection<String> GetFeatureClasses();
        ObservableCollection<SemanticsModificationInfo> GetSemanticsModificationInfos(Int64 modificationInfoID);
        ModificationInfoDTO GetModificationInfos(int pageNumber, FilterViewModel filter);
        ModificationInfoDTO GetModificationInfos(int pageNumber, Int64 featureFid = 0, String user = "", String featureClass = "", ModifyState state = ModifyState.None);
        ModificationInfoDTO GetModificationInfos(DateTime dateFrom, DateTime dateTo, int pageNumber, Int64 featureFid = 0, String user = "", String featureClass = "", ModifyState state = ModifyState.None);
    }

    public class ModificationAnalyzeService : IAnalyzeService
    {
        private int _pageSize = 10;
        public int PageSize
        {
            get { return _pageSize; }
            set { _pageSize = value; }
        }

        public ObservableCollection<String> GetUsers()
        {
            using (var client = new FeatureLogServiceClient("BasicHttpBinding_IFeatureLogService"))
            {
                return new ObservableCollection<String>(client.GetUsers().ToList());
            }
        }

        public ObservableCollection<String> GetFeatureClasses()
        {
            using (var client = new FeatureLogServiceClient("BasicHttpBinding_IFeatureLogService"))
            {
                return new ObservableCollection<String>(client.GetFeatureClasses().ToList());
            }
        }

        public ObservableCollection<SemanticsModificationInfo> GetSemanticsModificationInfos(long modificationInfoID)
        {
            using (var client = new FeatureLogServiceClient("BasicHttpBinding_IFeatureLogService"))
            {
                var infos = client.GetSemanticsModificationInfo(modificationInfoID);
                return new ObservableCollection<SemanticsModificationInfo>(infos);
            }
        }

        public ModificationInfoDTO GetModificationInfos(int pageNumber, FilterViewModel filter)
        {
            throw new NotImplementedException();
        }

        public ModificationInfoDTO GetModificationInfos(int pageNumber, Int64 featureFid = 0, String user = "", String featureClass = "", ModifyState state = ModifyState.None)
        {
            using (var client = new FeatureLogServiceClient("BasicHttpBinding_IFeatureLogService"))
            {
                var dto = client.GetFeatureModifyInfos(featureFid, user, state, featureClass, pageNumber * PageSize, PageSize);
                return dto;
            }
        }

        public ModificationInfoDTO GetModificationInfos(DateTime dateFrom, DateTime dateTo, int pageNumber, Int64 featureFid = 0, String user = "", String featureClass = "", ModifyState state = ModifyState.None)
        {
            using (var client = new FeatureLogServiceClient("BasicHttpBinding_IFeatureLogService"))
            {
                var dto = client.GetFeatureModifyInfosInPeriod(featureFid, user, state, featureClass, dateFrom, dateTo, pageNumber * PageSize, PageSize);
                return dto;
            }
        }
    }
}
