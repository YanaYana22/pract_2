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
    /// Логика взаимодействия для Task3Form.xaml
    /// </summary>
    public partial class Task3Form : Window
    {
        public Task3Form()
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
            // Получаем введенные числа
            List<int> numbers = InputTextBox.Text.Split(' ').Select(int.Parse).ToList();

            // Проверяем, что введено не менее трёх чисел
            if (numbers.Count < 3)
            {
                ResultTextBlock.Text = "Необходимо ввести не менее трёх чисел.";
                return;
            }

            // Сортируем числа по возрастанию
            numbers.Sort();

            // Находим максимальное произведение
            long maxProduct = Math.Max(numbers[numbers.Count - 1] * numbers[numbers.Count - 2] * numbers[numbers.Count - 3],
                                     numbers[0] * numbers[1] * numbers[numbers.Count - 1]);

            // Находим три числа, дающие максимальное произведение
            int[] maxNumbers = maxProduct == numbers[numbers.Count - 1] * numbers[numbers.Count - 2] * numbers[numbers.Count - 3]
                ? new[] { numbers[numbers.Count - 1], numbers[numbers.Count - 2], numbers[numbers.Count - 3] }
                : new[] { numbers[0], numbers[1], numbers[numbers.Count - 1] };

            // Выводим результат
            ResultTextBlock.Text = $"Максимальное произведение: {maxProduct}\nЧисла: {maxNumbers[0]}, {maxNumbers[1]}, {maxNumbers[2]}";
        }
    }
}
