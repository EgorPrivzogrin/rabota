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
    /// Логика взаимодействия для InfoUserPage.xaml
    /// </summary>
    public partial class InfoUserPage : Page
    {
        public InfoUserPage()
        {
            InitializeComponent();
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            MainWindow main = Window.GetWindow(this) as MainWindow;
            main.frame.Navigate(new LoginPage());
        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            if(table.Items == null)
            {
                MessageBox.Show("Выбирете то что хотите редактировать");
            }
            MainWindow main = Window.GetWindow(this) as MainWindow;
            main.frame.Navigate(new EditUserPage(table.SelectedItem as User));
        }

        private void filter_TextChanged(object sender, TextChangedEventArgs e)
        {
            if(filter.Text != "")
            {
                table.ItemsSource = singleton.DB.User.Where(u =>
                u.Username.Contains(filter.Text) ||
                u.Password.Contains(filter.Text)).ToList();
            }
            else
            {
                singleton.DB.User.ToList();
                table.ItemsSource = singleton.DB.User.Local;
            }
           
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            singleton.DB.User.ToList();
            table.ItemsSource = singleton.DB.User.Local;
        }
    }
}
