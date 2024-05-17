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
    /// Логика взаимодействия для InfoRolePage.xaml
    /// </summary>
    public partial class InfoRolePage : Page
    {
        public InfoRolePage()
        {
            InitializeComponent();
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            MainWindow main = Window.GetWindow(this) as MainWindow;
            main.frame.Navigate(new LoginPage());
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            singleton.DB.Role.ToList();
            table.ItemsSource = singleton.DB.Role.Local;
        }
    }
}
