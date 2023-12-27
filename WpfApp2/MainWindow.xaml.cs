using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace WpfApp2
{
    public partial class MainWindow : Window
    {
        private Dictionary<string, string> users;

        public MainWindow()
        {
            InitializeComponent();
            InitializeUsers();
        }

        private void InitializeUsers()
        {
           
            users = new Dictionary<string, string>()
            {
                { "manager1", "password1" },
                { "manager2", "password2" },
                { "manager3", "password3" }
            };
        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Password;

            if (users.ContainsKey(username) && users[username] == password)
            {
                MessageBox.Show("Авторизация успешна!");

                BolcaWindow bolcaWindow = new BolcaWindow();
                bolcaWindow.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Неверное имя пользователя или пароль.");
            }
        }

        private void Register_Click(object sender, RoutedEventArgs e)
        {
            if (DBConnect.entobj.User.Count(x => x.Login == txtUsername.Text) > 0)
            {
                MessageBox.Show("Такой пользователь уже есть!",
                "Уведомление",
                MessageBoxButton.OK,
                MessageBoxImage.Information);
                return;
            }
            else
            {
                try
                {
                    User userObj = new User()
                    {
                        Login = txtUsername.Text,
                        Password = txtPassword.Password,
                        IdRole = 2
                    };
                    DBConnect.entobj.User.Add(userObj);
                    DBConnect.entobj.SaveChanges();

                    MessageBox.Show("Пользователь создан!",
                    "Уведомление",
                    MessageBoxButton.OK,
                    MessageBoxImage.Information);
                }
                catch
                {

                }
            
            }
            }
    }
}
