using System;
using System.Linq;
using System.Threading.Tasks;
using Autodesk.Map.IM.Events;
using Autodesk.Map.IM.Forms.Events;
using Autodesk.Map.IM.PlugInHandler;
using FeatureLogger.ServiceReference;

namespace FeatureLogger
{
    public class DocumentPlugIn : Autodesk.Map.IM.Forms.DocumentPlugIn
    {
        private FeatureModifyFactory _factory;
        private FeatureLogCommands _commands;

        public override void OnLoad(object sender, EventArgs e)
        {
            if (Application.TargetPlatform != PlugInTarget.Client)
                return;

            _factory = new FeatureModifyFactory();

            foreach (var featureClass in Document.Connection.FeatureClasses)
            {
                featureClass.Inserted += featureClass_Inserted;
                featureClass.Updated += featureClass_Updated;
                featureClass.Updating += featureClass_Updating;
                featureClass.UpdatingCanceled += featureClass_UpdatingCanceled;
                featureClass.Deleted += featureClass_Deleted;
            }
        }

        private void featureClass_UpdatingCanceled(object sender, FeatureEventArgs e)
        {
            _factory.RemoveUpdatingModificationInfo(x => x.UserName == Application.User.Name && x.FID == e.FID);
        }

        private void featureClass_Updating(object sender, FeatureCancelEventArgs e)
        {
            var modificationInfo = _factory.CreateFeatureModificationInfo(Application.User.Name, ModifyState.Modified, e.Feature.FID, e.Feature.FeatureClass.Name, e.Feature);
            _factory.AddUpdatingModificationInfo(modificationInfo);
        }

        private void StartNewTask(Action action)
        {
            var task = new Task(action);

            task.ContinueWith(continuation =>
            {
                if (continuation.IsFaulted)
                    Application.ShowErrorMessage(continuation.Exception, string.Empty, continuation.Exception != null ? continuation.Exception.InnerException.Message : string.Empty);
            });

            task.Start();
        }


        void featureClass_Inserted(object sender, FeatureEventArgs e)
        {
            Action action = () =>
            {
                var modificationInfo = _factory.CreateFeatureModificationInfo(Application.User.Name, ModifyState.Inserted, e.Feature.FID, e.FeatureClass.Name, e.Feature);
                using (var logChannel = new FeatureLogServiceClient("BasicHttpBinding_IFeatureLogService"))
                {
                    logChannel.AddFeatureModifyLog(modificationInfo);
                }
            };
            StartNewTask(action);
        }

        void featureClass_Updated(object sender, FeatureEventArgs e)
        {
            Action action = () =>
            {
                var modificationInfo = _factory.GetUpdatingModificationInfo(x => x.UserName == Application.User.Name && x.FID == e.FID);
                using (var logChannel = new FeatureLogServiceClient("BasicHttpBinding_IFeatureLogService"))
                {
                    if (modificationInfo != null && (modificationInfo.SemanticsInfo.Any() || modificationInfo.GeometryInfo != null))
                        logChannel.AddFeatureModifyLog(modificationInfo);

                    if (modificationInfo != null)
                    {
                        _factory.RemoveUpdatingModificationInfo(modificationInfo);
                    }
                }
            };
            StartNewTask(action);
        }

        void featureClass_Deleted(object sender, FidEventArgs e)
        {
            Action action = () =>
            {
                var modificationInfo = _factory.CreateFeatureModificationInfo(Application.User.Name, ModifyState.Deleted, e.FID, e.FeatureClass.Name, e.FeatureClass.Caption);
                using (var logChannel = new FeatureLogServiceClient("BasicHttpBinding_IFeatureLogService"))
                {
                    logChannel.AddFeatureModifyLog(modificationInfo);
                }
            };
            StartNewTask(action);
        }

        public Autodesk.Map.IM.Forms.ToolBarButton ShowLogReportButton = new Autodesk.Map.IM.Forms.ToolBarButton();
        public Autodesk.Map.IM.Forms.ToolBarButton ShowLogReportForFeatureButton = new Autodesk.Map.IM.Forms.ToolBarButton();

        public override void OnInitToolBars(object sender, ToolBarsEventArgs e)
        {
            _commands = new FeatureLogCommands(Document);

            var logReportToolbar = e.ToolBars.Add("LogReport", "Log Report");

            logReportToolbar.Buttons.Add(ShowLogReportButton, "ShowLogReportButton.png", Properties.Resources.LOG_BUTTON_TOOLTIP);
            ShowLogReportButton.Click += (bsender, be) => _commands.ShowLogReport();

            logReportToolbar.Buttons.Add(ShowLogReportForFeatureButton, "ShowLogReportForFeatureButton.png", Properties.Resources.LOG_FOR_SELECTED_FEATURE_BUTTON_TOOLTIP);
            ShowLogReportForFeatureButton.Click += (bsender, be) => _commands.ShowLogReportForFeature();
        }
    }
}
