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
    /// Логика взаимодействия для EditUserPage.xaml
    /// </summary>
    public partial class EditUserPage : Page
    {
        User user = null;
        public EditUserPage()
        {
            InitializeComponent();
        }
        public EditUserPage(User user)
        {
            InitializeComponent();
            this.user = user;
        }
        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            MainWindow main = Window.GetWindow(this) as MainWindow;
            main.frame.Navigate(new InfoUserPage());
        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
             if (username.Text == "" || password.Password == "" || role.SelectedItem == null)
            {
                MessageBox.Show("Все поля долджны быть заполенны");
                return;
            }
            if ( password.Password.Length <= 6)
            {
                MessageBox.Show("Пароль должен состоять из 6 символов");
                return;
            }
            user.Username = username.Text;
            user.Password = password.Password;
            user.Role = role.SelectedItem as Role;
            singleton.DB.SaveChanges();
            MainWindow main = Window.GetWindow(this) as MainWindow;
            main.frame.Navigate(new InfoUserPage());

        }

        

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            role.ItemsSource = singleton.DB.Role.ToList();
            if(user != null) 
            {
                username.Text = user.Username;
                password.Password = user.Password;
                role.SelectedItem = user.Role;
            }

        }
    }
}
