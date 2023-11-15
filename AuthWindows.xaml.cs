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
    public partial class AuthWindows : Window
    {
        public AuthWindows()
        {
            InitializeComponent();
        }

        private void OpenReg(object sender, RoutedEventArgs e)
        {
            MainWindow reg = new MainWindow();
            reg.Show();
            this.Close();
        }

        private void Button_Auth_Click(object sender, RoutedEventArgs e)
        {
            string login = TextBoxLogin.Text.Trim();
            string pass_1 = passbox_1.Password.Trim();

            if (login.Length < 5)
            {
                Error.Visibility = Visibility.Visible;
                Error.Text = "Логин не менее 5 символов";
                TextBoxLogin.Background = Brushes.DarkRed;
            }
            else if (pass_1.Length < 5)
            {
                Error.Visibility = Visibility.Visible;
                Error.Text = "Пароль не менее 5 символов";
                passbox_1.Background = Brushes.DarkRed;
            }
            else
            {
                Error.Visibility = Visibility.Collapsed;
                TextBoxLogin.Text = string.Empty;
                TextBoxLogin.Background = Brushes.Transparent;
                passbox_1.Password = string.Empty;
                passbox_1.Background = Brushes.Transparent;


                User authUser = null;
                using (ApplicationContext db = new ApplicationContext())
                {
                    authUser = db.Users.Where(b => b.login == login && b.password == pass_1).FirstOrDefault();
                    
                }

                if (authUser != null)
                {
                    MessageBox.Show("Вы успешно вошли!");
                    Cabinet cabinet = new Cabinet();
                    cabinet.Show();
                    this.Close();
                }
                else MessageBox.Show("Данные введены неккоректно");
            }
        }
    }
}
