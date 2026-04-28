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
using PR7._2.Services;

namespace PR7._2
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void OnEncryptClick(object sender, RoutedEventArgs e)
        {
            try
            {
                if (!int.TryParse(RowsInput.Text, out int r) || !int.TryParse(ColsInput.Text, out int c))
                    throw new Exception("Укажите числовые размеры матрицы.");

                var service = new MatrixEncryptor();
                ResultOutput.Text = service.Encrypt(InputTextBox.Text, r, c);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка шифрования", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void OnDecryptClick(object sender, RoutedEventArgs e)
        {
            try
            {
                if (!int.TryParse(RowsInput.Text, out int r) || !int.TryParse(ColsInput.Text, out int c))
                    throw new Exception("Укажите числовые размеры матрицы.");

                var service = new MatrixDecryptor();
                ResultOutput.Text = service.Decrypt(InputTextBox.Text, r, c);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка дешифрования", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
    }
}
