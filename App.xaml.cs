using CVSSCalculator.MVVM.ViewModels;
using System;
using System.Windows;
using System.Windows.Media.Media3D;
using Forms = System.Windows.Forms;

namespace CVSSCalculator
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly CvssViewModel _cvssViewModel;

        public App()
        {
            _cvssViewModel = new CvssViewModel();
        }
        protected override void OnStartup(StartupEventArgs e)
        {
            MainWindow = new MainWindow()
            {
                DataContext = _cvssViewModel
            };
            MainWindow.Show();
        }
    }
}
