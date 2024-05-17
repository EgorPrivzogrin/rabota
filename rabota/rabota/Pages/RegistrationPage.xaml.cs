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

namespace rabota.Pages
{
    /// <summary>
    /// Логика взаимодействия для RegistrationPage.xaml
    /// </summary>
    public partial class RegistrationPage : Page
    {
        public RegistrationPage()
        {
            InitializeComponent();
        }
        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            MainWindow main = Window.GetWindow(this) as MainWindow;
            main.frame.Navigate(new LoginPage());
        }

        private void registration_Click(object sender, RoutedEventArgs e)
        {
            if (username.Text == "" || password.Password == "" || passwordConfirm.Password == "")
            {
                MessageBox.Show("Все поля долджны быть заполенны");
                return;
            }
            if  (password.Password !=  passwordConfirm.Password)
            {
                MessageBox.Show("пароли не совпадают");
                return;
            }
            if ( password.Password.Length <= 6)
            {
                MessageBox.Show("Пароль должен состоять из 6 символов");
                return;
            }
            singleton.DB.User.Add(new User()
            {
                Username = username.Text,
                Password = password.Password,
                Role_ID = 2
            });
            singleton.DB.SaveChanges();
            MainWindow main = Window.GetWindow(this) as MainWindow;
            main.frame.Navigate(new InfoRolePage());
        }

        
    }
}
