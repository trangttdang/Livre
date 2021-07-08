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
using System.Windows.Shapes;
using System.Windows.Threading;

namespace tabDonHang
{
    /// <summary>
    /// Interaction logic for SplashScreen.xaml
    /// </summary>
    public partial class SplashScreen : Window
    {
        string username;
        int quyentruycap;
        public SplashScreen()
        {
            InitializeComponent();
            media.Source = new Uri(Environment.CurrentDirectory + @"\load2.gif");
            Loading();
        }
        DispatcherTimer timer = new DispatcherTimer();
        private void media_MediaEnded(object sender, RoutedEventArgs e)
        {
            media.Position = new TimeSpan(0, 0, 1);
            media.Play();
        }
        private void timer_tick(object sender, EventArgs e)
        {
            timer.Stop();
            Hide();
            Han_MaiAnh form = new Han_MaiAnh();
            if (quyentruycap == 1)
            {
                form.Show();
                form.laytenuser(username);
            }

            else if (quyentruycap == 2)
            {
                form.Show();
                form.tabBC.IsEnabled = false;
                form.tabKH.IsEnabled = false;
                form.tabSP.IsEnabled = false;
                form.tabNCC.IsEnabled = false;
                form.laytenuser(username);
            }
            Close();
        }
        void Loading()
        {
            timer.Tick += timer_tick;
            timer.Interval = new TimeSpan(0, 0, 6);
            timer.Start();
        }
        public void laythongtin(string a, int b)
        {
            username = a;
            quyentruycap = b;
        }
    }
}
