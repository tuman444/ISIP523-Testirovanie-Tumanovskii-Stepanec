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

namespace PR6._3.Pages
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
        private void BtnLogin_Click(object sender, RoutedEventArgs e)
        {
            Auth(TxtLogin.Text, PBoxPassword.Password);
        }

        public bool IsTest = false;

        public bool Auth(string login, string pass)
        {
            if (string.IsNullOrWhiteSpace(login) || string.IsNullOrWhiteSpace(pass))
            {
                if (!IsTest)
                    MessageBox.Show("Пожалуйста, заполните все поля!");
                return false;
            }

            var user = Core.Context.Users.FirstOrDefault(u => u.Login == login && u.Password == pass);

            if (user != null)
            {
                Core.CurrentUser = user;

                if (!IsTest)
                {
                    MessageBox.Show($"Добро пожаловать, {user.FirstName}!");

                    if (NavigationService != null)
                        NavigationService.Navigate(new Pages.MainPage());
                }

                return true;
            }
            else
            {
                if (!IsTest)
                    MessageBox.Show("Неверный логин или пароль");

                return false;
            }
        }

        private void BtnReg_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Pages.RegisterPage());
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
