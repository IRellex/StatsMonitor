using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Stats_Monitoring.Config;
using Stats_Monitoring.ViewModel;
using Unity;

namespace Stats_Monitoring
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void App_OnStartup(object sender, StartupEventArgs e)
        {
            UnityConfiguration conf = new UnityConfiguration();
            conf.SetupContainer();
            MainWindow mv = new MainWindow();
            MainWindowViewModel mvvm = UnityConfiguration.Container.Resolve<MainWindowViewModel>();
            mv.DataContext = mvvm;

            mv.ShowDialog();
        }
    }
}
