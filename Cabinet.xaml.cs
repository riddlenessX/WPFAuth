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
            string str = "Личные данные:\n\n";
            int counter = 1;
            foreach (User user in users)
            {
                str += $"Пользователь {counter}. Login: " + user.login + " ";
                str += "Password: " + user.password + " ";
                str += "Email: " + user.email + "\n";
                counter++;
            }
            examletext.Text = str;

        }


    }
}
