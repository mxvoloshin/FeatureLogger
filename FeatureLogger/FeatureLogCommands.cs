﻿using System;
using Autodesk.Map.IM.CommandRegistry.API;
using Autodesk.Map.IM.CommandRegistry.API.Util;
using Autodesk.Map.IM.Forms;
using Autodesk.Map.IM.Map.PromptResults;
using FeatureLogger.Properties;
using FeatureLogger.Services;
using FeatureLogger.View;
using FeatureLogger.ViewModel;
using Microsoft.Practices.Unity;
using UnhandledExceptionEventArgs = Autodesk.Map.IM.CommandRegistry.API.UnhandledExceptionEventArgs;

namespace FeatureLogger
{
    class FeatureLogCommands : DocumentMapCommands
    {
        private readonly IUnityContainer _container;

        public FeatureLogCommands(Document document) : base(document)
        {
            _container = new UnityContainer();
            _container.RegisterType<IAnalyzeService, ModificationAnalyzeService>();
        }

        protected override void UnhandledException(UnhandledExceptionEventArgs args)
        {
            Application.ShowErrorMessage(args.Exception, args.GlobalName, args.Exception.Message);
        }

        [TBCommand("ShowLogReport", "localShowLogReport", TBCommandFlags.CMD_DOCLEVEL, "{1625ACD7-E2DC-465F-90C7-976DC0F3B9CB}")]
        public void ShowLogReport(params object[] args)
        {
            try
            {
                var filter = new FilterViewModel { FilterByPeriod = true };
                
                var vm = _container.Resolve<FeatureLogViewModel>();
                vm.Filter = filter;
                vm.ApplyFilter();

                var view = new FeatureLogView {ViewModel = vm};
                view.ShowDialog();
            }
            catch (Exception ex)
            {
                Application.ShowErrorMessage(ex, ex.Source, ex.Message);
            }
        }

        [TBCommand("ShowLogReportForFeature", "localShowLogReportForFeature", TBCommandFlags.CMD_DOCLEVEL, "{971A648C-BE9A-49C6-9A4D-51F9233DDD17}")]
        public void ShowLogReportForFeature(params object[] args)
        {
            try
            {
                var selectResult = Document.Map.SelectFeature(Resources.MSG_SELECT_FEATURE);
                if (selectResult.Feature == null || selectResult.Status != MapPromptStatus.OK)
                {
                    return;
                }

                var filter = new FilterViewModel {FilterByFid = true};

                var vm = _container.Resolve<FeatureLogViewModel>();
                vm.FeatureFid = selectResult.Feature.FID;
                vm.Filter = filter;
                vm.ApplyFilter();

                var view = new FeatureLogView { ViewModel = vm};
                view.ShowDialog();
            }
            catch (Exception ex)
            {
                Application.ShowErrorMessage(ex, ex.Source, ex.Message);
            }
        }
    }
}
