using FirstWPF;
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

namespace FirstWPF
{
    /// <summary>
    /// Логика взаимодействия для Cabinet.xaml
    /// </summary>


    public partial class Cabinet : Window
    {

        ApplicationContext db;
        public Cabinet()
        {
            InitializeComponent();
            db = new ApplicationContext();

            List<User> users = db.Users.ToList();


            table.ItemsSource = users;
            Window.Height += table.ActualHeight*30;
            this.Height += table.ActualHeight * 30;

        }
        private void Logout(object sender, RoutedEventArgs e)
        {
            AuthWindows auth = new AuthWindows();
            auth.Show();
            this.Close();
        }
    }
}
