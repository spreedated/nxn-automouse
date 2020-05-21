using System;
using System.Windows;
using System.Windows.Forms;

namespace nxn_AutoMouse.Windows
{
    /// <summary>
    /// Interaction logic for Active.xaml
    /// </summary>
    public partial class Active : Window
    {
        private readonly System.Windows.Forms.Timer AniTimer = new System.Windows.Forms.Timer();
        public Active()
        {
            InitializeComponent();

            System.Drawing.Rectangle wArea = Screen.PrimaryScreen.Bounds;
            System.Drawing.Rectangle Padding = new System.Drawing.Rectangle() { Height = 40, Width = 8 };


            this.Top = wArea.Height - this.Height - Padding.Height;
            this.Left = wArea.Width - this.Width - Padding.Width;

            AniTimer.Tick += Timer_Tick;
            AniTimer.Interval = 350;
            AniTimer.Enabled = true;
            AniTimer.Start();
        }
        public void Timer_Tick(object sender, EventArgs e)
        {
            RedDot.Visibility = RedDot.Visibility == Visibility.Visible ? Visibility.Hidden : Visibility.Visible;
            LeftMouseButtonPressed.Visibility = LeftMouseButtonPressed.Visibility == Visibility.Visible ? Visibility.Hidden : Visibility.Visible;
        }
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            AniTimer.Stop();
        }
    }
}
