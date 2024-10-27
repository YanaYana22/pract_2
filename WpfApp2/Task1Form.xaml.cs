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

namespace WpfApp2
{
    /// <summary>
    /// Логика взаимодействия для Task1Form.xaml
    /// </summary>
    public partial class Task1Form : Window
    {
        public Task1Form()
        {
            InitializeComponent();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(YearTextBox.Text, out int year))
            {
                int century = (year + 99) / 100;
                CenturyTextBlock.Text = century.ToString();
            }
            else
            {
                MessageBox.Show("Введите корректное числовое значение.");
            }
        }
    }
}
