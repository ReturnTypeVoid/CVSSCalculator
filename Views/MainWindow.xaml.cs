using System;
using System.Drawing;
using System.IO;
using System.Windows;
using System.Windows.Forms;

namespace CVSSCalculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly NotifyIcon notifyIcon;
        public MainWindow()
        {
            InitializeComponent();
            Loaded += MainWindow_Loaded;
            notifyIcon = new();
            Stream iconStream = System.Windows.Application.GetResourceStream(new Uri("pack://application:,,,/CVSSCalculator;component/Resources/Icon.ico")).Stream;
            notifyIcon.Icon = new Icon(iconStream);
            notifyIcon.Text = "CVSS Calculator";
            notifyIcon.DoubleClick += delegate (object? sender, EventArgs args)
            {
                Show();
                WindowState = WindowState.Normal;
            };
            notifyIcon.ContextMenuStrip = new();
            notifyIcon.ContextMenuStrip.Items.Add("Open", null, OpenClicked);
            notifyIcon.ContextMenuStrip.Items.Add("Close", null, CloseClicked);

            notifyIcon.Visible = true;
        }

        private void OpenClicked(object? sender, EventArgs e)
        {
            Show();
            WindowState = WindowState.Normal;
        }

        private void CloseClicked(object? sender, EventArgs e)
        {
            notifyIcon.Dispose();
            Close();
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            var desktopWorkingArea = System.Windows.SystemParameters.WorkArea;
            Left = desktopWorkingArea.Right - Width;
            Top = desktopWorkingArea.Bottom - Height;
        }

        protected override void OnStateChanged(EventArgs e)
        {
            if (WindowState == System.Windows.WindowState.Minimized)
                Hide();

            base.OnStateChanged(e);
        }
    }
}
