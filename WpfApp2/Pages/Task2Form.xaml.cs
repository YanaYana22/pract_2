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
    /// Логика взаимодействия для Task2Form.xaml
    /// </summary>
    public partial class Task2Form : Window
    {
        public Task2Form()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            string str = StringTextBox.Text;
            int openBrackets = 0;
            int result = 0;

            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] == '(')
                {
                    openBrackets++;
                }
                else if (str[i] == ')')
                {
                    if (openBrackets == 0)
                    {
                        result = i + 1; // Позиция первой ошибочной скобки
                        break;
                    }
                    openBrackets--;
                }
            }

            if (openBrackets > 0)
            {
                result = -1; // Не хватает закрывающих скобок
            }

            ResultTextBlock.Text = result.ToString();
        }
    }
}
