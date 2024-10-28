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
    /// Логика взаимодействия для Task4Form.xaml
    /// </summary>
    public partial class Task4Form : Window
    {
        public Task4Form()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }

        // Определение количества промежутков монотонности
        private int CountMonotonicIntervals(int[] array)
        {
            if (array.Length == 0)
            {
                return 0;
            }

            int intervalCount = 1;

            // Сравнение для первых двух элементов
            if (array.Length >= 2)
            {
                if (array[1] > array[0])
                {
                    intervalCount++;
                }
            }

            // Сравнение для остальных элементов
            for (int i = 2; i < array.Length; i++)
            {
                if ((array[i] > array[i - 1] && array[i - 1] >= array[i - 2]) ||
                    (array[i] < array[i - 1] && array[i - 1] <= array[i - 2]))
                {
                    intervalCount++;
                }
            }

            return intervalCount;
        }

        // Перестановка первого и последнего промежутков монотонности
        private void SwapFirstAndLastIntervals(int[] array)
        {
            int firstIntervalStart = 0;
            int firstIntervalEnd = 0;
            int lastIntervalStart = 0;
            int lastIntervalEnd = 0;

            // Поиск первого промежутка монотонности
            
            
                // хз бро
                for (int i = 0; i-2 < array.Length; i++)
                {
                MessageBox.Show(i.ToString());
                if ((array[i + 1] > array[i]) || (array[i + 1] < array[i]))
                    {
                        firstIntervalEnd = i;
                    }
                }
                
            

            // Поиск последнего промежутка монотонности
            if (array.Length < 3)
            {
                lastIntervalStart = array.Length - 1;
            }
            else
            {
                for (int i = array.Length - 2; i > 0 && i < array.Length - 2; i--)
                {
                    if ((array[i] > array[i + 1] && array[i + 1] >= array[i + 2]) ||
                        (array[i] < array[i + 1] && array[i + 1] <= array[i + 2]))
                    {
                        lastIntervalStart = i + 1;
                        break;
                    }
                }

                // Проверка последнего элемента массива
                if (array.Length >= 3 && ((array[array.Length - 2] > array[array.Length - 1]) || (array[array.Length - 2] < array[array.Length - 1])))
                {
                    lastIntervalStart = array.Length - 1;
                }
            }

            //Перестановка элементов
            if (lastIntervalEnd >= lastIntervalStart)
            {
                int[] temp = new int[lastIntervalEnd - lastIntervalStart + 1];
                for (int i = 0; i < temp.Length; i++)
                {
                    temp[i] = array[lastIntervalStart + i];
                }
                for (int i = 0; i < temp.Length; i++)
                {
                    array[lastIntervalStart + i] = array[firstIntervalStart + i];
                }
                for (int i = 0; i < temp.Length; i++)
                {
                    array[firstIntervalStart + i] = temp[i];
                }
            }
            else
            {
                MessageBox.Show("Ошибка: некорректные значения lastIntervalEnd и lastIntervalStart.");
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            // Ввод размера массива
            int N;
            if (!int.TryParse(SizeTextBox.Text, out N))
            {
                MessageBox.Show("Некорректный размер массива.");
                return;
            }

            // Ввод элементов массива
            int[] array = new int[N];
            string[] inputValues = InputTextBox.Text.Split(' ');
            if (inputValues.Length != N)
            {
                MessageBox.Show("Некорректное количество элементов массива.");
                return;
            }
            for (int i = 0; i < N; i++)
            {
                if (!int.TryParse(inputValues[i], out array[i]))
                {
                    MessageBox.Show("Некорректный элемент массива.");
                    return;
                }
            }

            // Определение количества и перестановка промежутков монотонности
            int intervalCount = CountMonotonicIntervals(array);
            SwapFirstAndLastIntervals(array);

            // Вывод результата
            ResultTextBlock.Text = $"Количество промежутков монотонности: {intervalCount}\n\n";
            ResultTextBlock.Text += "Массив после перестановки:\n";
            foreach (int element in array)
            {
                ResultTextBlock.Text += $"{element} ";
            }
        }
    }
}
