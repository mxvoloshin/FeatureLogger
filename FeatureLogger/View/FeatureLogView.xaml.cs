using System.Windows;
using FeatureLogger.ViewModel;
using Microsoft.Practices.Unity;

namespace FeatureLogger.View
{
    /// <summary>
    /// Interaction logic for FeatureLogView.xaml
    /// </summary>
    public partial class FeatureLogView
    {
        public FeatureLogView()
        {
            InitializeComponent();
        }

        public FeatureLogViewModel ViewModel
        {
            set { DataContext = value; }
        }
    }
}
