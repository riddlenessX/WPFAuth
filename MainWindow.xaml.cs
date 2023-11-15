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

namespace FirstWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        ApplicationContext db;
        public MainWindow()
        {
            InitializeComponent();
            db = new ApplicationContext();

            List<User> users = db.Users.ToList();
            string str = "";
            foreach (User user in users)
                str += "Login" + user.login + "|";
            examletext.Text = str;
        }

        private void OpenAuth(object sender, RoutedEventArgs e)
        {
            AuthWindows auth = new AuthWindows();
            auth.Show();
            this.Close();

        }

        private void Button_Reg_Click(object sender, RoutedEventArgs e)
        {
            string login = TextBoxLogin.Text.Trim();
            string pass_1 = passbox_1.Password.Trim();
            string pass_2 = passbox_2.Password.Trim();
            string email = TextBoxEmail.Text.Trim().ToLower();

            if (login.Length < 5)
            {
                TextBoxLogin.ToolTip = "Это поле введено некорректно! (Логин не менее 5 символов)";
                TextBoxLogin.Background = Brushes.DarkRed;
            }
            else if (pass_1.Length < 5)
            {
                passbox_1.ToolTip = "Это поле введено некорректно! (Пароль не менее 5 символов)";
                passbox_1.Background = Brushes.DarkRed;
            }
            else if (pass_2.Length < 5)
            {
                passbox_2.ToolTip = "Это поле введено некорректно! (Пароль не менее 5 символов)";
                passbox_2.Background = Brushes.DarkRed;
            }
            else if (pass_1 != pass_2)
            {
                passbox_2.ToolTip = "Пароли не совпадают!";
                passbox_2.Background = Brushes.DarkRed;
            }
            else if (email.Length < 5 || !email.Contains("@") || !email.Contains("."))
            {
                TextBoxEmail.ToolTip = "Это поле введено некорректно! (Адрес почты не менее 5 символов, включая '@' и '.')";
                TextBoxEmail.Background = Brushes.DarkRed;
            }
            else
            {
                TextBoxLogin.Text = string.Empty;
                TextBoxLogin.Background = Brushes.Transparent;
                passbox_1.Password = string.Empty;
                passbox_1.Background = Brushes.Transparent;
                passbox_2.Password = string.Empty;
                passbox_2.Background = Brushes.Transparent;
                TextBoxEmail.Text = string.Empty;
                TextBoxEmail.Background = Brushes.Transparent;
                MessageBox.Show("Вы успешно зарегистрировались.");


                User user = new User(login, pass_1, email);

                db.Users.Add(user);
                db.SaveChanges();
            }
        }
    }
}
