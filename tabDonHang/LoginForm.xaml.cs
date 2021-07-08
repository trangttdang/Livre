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

namespace tabDonHang
{
    /// <summary>
    /// Interaction logic for LoginForm.xaml
    /// </summary>
    public partial class LoginForm : Window
    {
        CmangUser mangU = new CmangUser();
        public string username { get; set; }
        public int quyentruycap { get; set; }
        public LoginForm()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            SplashScreen newtab = new SplashScreen();
            CUser user = new CUser(txtUsername.Text, txtPass.Password);
            mangU.docfile("Userdata.txt");
            if (mangU.tim(user) == true)
            {
                username = user.username;
                quyentruycap = user.quyentruycap;
                lblTbao.Content = "";
                MessageBox.Show(mangU.phanquyen(user), "", MessageBoxButton.OK);
                newtab.Show();
                newtab.laythongtin(user.username, user.quyentruycap);
                this.Close();
            }
            else if (mangU.tim(user) == false)
            {
                lblTbao.Content = "Incorrect Username or Password, please try again";
            }
        }

        private void btnShutDown_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
