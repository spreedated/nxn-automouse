using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Gma.System.MouseKeyHook;
using System.Windows.Forms;
using System.Diagnostics;
using System.Threading;
using nxn_AutoMouse.Windows;

namespace nxn_AutoMouse
{
    public partial class MainWindow : Window
    {
        private Logic MainLogic = null;
        public MainWindow()
        {
           InitializeComponent();
           MainLogic = new Logic();
        }
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            MainLogic.Dispose();
            nxnNotifyIcon.Dispose();
        }
        #region "NotifiyIcon"
        private void NIExit(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void NISettings(object sender, RoutedEventArgs e)
        {
            this.WindowState = this.WindowState == WindowState.Normal ? WindowState.Minimized : WindowState.Normal;
            NISettingsItem.Header = NISettingsItem.Header.ToString().ToLower().Contains("close") ? "Settings" : "Close settings";
        }
        #endregion
    }
}
