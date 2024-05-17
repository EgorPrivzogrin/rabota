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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace rabota.Pages
{
    /// <summary>
    /// Логика взаимодействия для LoginPage.xaml
    /// </summary>
    public partial class LoginPage : Page
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            User user = singleton.DB.User.FirstOrDefault(u =>
            u.Username == username.Text &&
            u.Password == password.Password);
            if (user == null)
            {
                MessageBox.Show("Введите правильный Логин");
                return;
            }
            else
            {
                MainWindow main = Window.GetWindow(this)  as MainWindow;
                if(user.Role_ID == 1)
                {
                    main.frame.Navigate(new InfoUserPage());
                }
                if (user.Role_ID == 2)
                {
                    main.frame.Navigate(new InfoRolePage());
                }
            }
        }

        private void registration_Click(object sender, RoutedEventArgs e)
        {
            MainWindow main = Window.GetWindow(this) as MainWindow;
            main.frame.Navigate(new RegistrationPage());
        }
    }
}
