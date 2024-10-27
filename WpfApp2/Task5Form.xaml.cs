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
    /// Логика взаимодействия для Task5Form.xaml
    /// </summary>
    public partial class Task5Form : Window
    {
        private int[,] array;
        private int M, N;
        public Task5Form()
        {
            InitializeComponent();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                M = int.Parse(MTextBox.Text);
                N = int.Parse(NTextBox.Text);

                // Генерация массива
                array = new int[N, M];
                Random random = new Random();
                for (int i = 0; i < N; i++)
                {
                    for (int j = 0; j < M; j++)
                    {
                        array[i, j] = random.Next(-10, 11);
                    }
                }

                // Отображение массива
                DisplayArray(array);

                // Сортировка по возрастанию
                int[,] sortedAscending = SortArray(array, true);
                DisplayArray(sortedAscending, "Отсортированный по возрастанию");

                // Сортировка по убыванию
                int[,] sortedDescending = SortArray(array, false);
                DisplayArray(sortedDescending, "Отсортированный по убыванию");

                // Поиск максимального и минимального элементов
                int max = FindMax(array);
                int min = FindMin(array);
                MaxMinLabel.Content = $"Максимальный элемент: {max}, Минимальный элемент: {min}";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка: " + ex.Message);
            }
        }

        // Отображение массива в DataGrid
        private void DisplayArray(int[,] array, string title = "Исходный массив")
        {
            DataGrid dataGrid = new DataGrid();
            dataGrid.ItemsSource = (System.Collections.IEnumerable)GetDataTable(array);
            dataGrid.AutoGenerateColumns = true;
            dataGrid.HeadersVisibility = DataGridHeadersVisibility.Column;
            dataGrid.Margin = new Thickness(10);
            dataGrid.Name = title;

            // Добавление DataGrid на окно
            MainGrid.Children.Add(dataGrid);
        }

        // Преобразование двумерного массива в DataTable
        private System.Data.DataTable GetDataTable(int[,] array)
        {
            System.Data.DataTable table = new System.Data.DataTable();
            for (int i = 0; i < array.GetLength(1); i++)
            {
                table.Columns.Add($"Столбец {i + 1}", typeof(int));
            }
            for (int i = 0; i < array.GetLength(0); i++)
            {
                System.Data.DataRow row = table.NewRow();
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    row[j] = array[i, j];
                }
                table.Rows.Add(row);
            }
            return table;
        }

        // Сортировка массива по возрастанию/убыванию
        private int[,] SortArray(int[,] array, bool ascending = true)
        {
            int[,] sortedArray = (int[,])array.Clone();

            // Сортировка элементов в массиве
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < M - 1; j++)
                {
                    for (int k = j + 1; k < M; k++)
                    {
                        if (ascending)
                        {
                            if (sortedArray[i, j] > sortedArray[i, k])
                            {
                                int temp = sortedArray[i, j];
                                sortedArray[i, j] = sortedArray[i, k];
                                sortedArray[i, k] = temp;
                            }
                        }
                        else
                        {
                            if (sortedArray[i, j] < sortedArray[i, k])
                            {
                                int temp = sortedArray[i, j];
                                sortedArray[i, j] = sortedArray[i, k];
                                sortedArray[i, k] = temp;
                            }
                        }
                    }
                }
            }

            return sortedArray;
        }

        // Поиск максимального элемента в массиве
        private int FindMax(int[,] array)
        {
            int max = array[0, 0];
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < M; j++)
                {
                    if (array[i, j] > max)
                    {
                        max = array[i, j];
                    }
                }
            }
            return max;
        }

        // Поиск минимального элемента в массиве
        private int FindMin(int[,] array)
        {
            int min = array[0, 0];
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < M; j++)
                {
                    if (array[i, j] < min)
                    {
                        min = array[i, j];
                    }
                }
            }
            return min;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
            {
                MainWindow mainWindow = new MainWindow();
                mainWindow.Show();
                this.Close();
            }
        }
    }
