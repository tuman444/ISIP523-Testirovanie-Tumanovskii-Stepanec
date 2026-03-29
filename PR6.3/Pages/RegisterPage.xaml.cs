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
    /// Логика взаимодействия для RegisterPage.xaml
    /// </summary>
    public partial class RegisterPage : Page
    {
        public RegisterPage()
        {
            InitializeComponent();
        }
        private void BtnReg_Click(object sender, RoutedEventArgs e)
        {
            Register(TxtName.Text, TxtLastName.Text, TxtLogin.Text, PBoxPass.Password, PBoxPassConfirm.Password);
        }


        public bool Register(string name, string lastName, string login, string pass, string confirmPass)
        {
            if (string.IsNullOrWhiteSpace(name) ||
                string.IsNullOrWhiteSpace(lastName) ||
                string.IsNullOrWhiteSpace(login) ||
                string.IsNullOrWhiteSpace(pass))
            {
                return false;
            }

            if (pass != confirmPass)
                return false;

            var existingUser = Core.Context.Users.FirstOrDefault(u => u.Login == login);
            if (existingUser != null)
                return false;

            Users newUser = new Users()
            {
                FirstName = name,
                LastName = lastName,
                Login = login,
                Password = pass
            };

            Core.Context.Users.Add(newUser);
            Core.Context.SaveChanges();

            return true;
        }

        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
