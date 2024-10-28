using System;
using System.Windows;
using System.Windows.Controls;

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

        private void generateButton_Click(object sender, RoutedEventArgs e)
        {
            int M = int.Parse(Mcount.Text);
            int N = int.Parse(Ncount.Text);
            int[,] array = new int[N, M];
            Random random = new Random();
            int min = 10, max = -10;

            for (int i = 0; i < N; i++)
                for (int j = 0; j < M; j++)
                {
                    array[i, j] = random.Next(-10, 11);

                    if (array[i, j] < min)
                        min = array[i, j];

                    if (array[i, j] > max)
                        max = array[i, j];
                }

            minCount.Text = "";
            minCount.Text += Convert.ToString(min);
            maxCount.Text = "";
            maxCount.Text += Convert.ToString(max);

            for (int i = 0; i < N; i++)
                for (int j = i + 1; j < N; j++)
                    if (array[i, 0] > array[j, 0])
                        for (int k = 0; k < M; k++)
                            (array[i, k], array[j, k]) = (array[j, k], array[i, k]);

            ascSorted.Text = "";
            descSorted.Text = "";

            for (int i = 0; i < N; i++, ascSorted.Text += "\n")
                for (int j = 0; j < M; j++)
                    ascSorted.Text += $"{array[i, j]} ";

            for (int i = 0; i < N; i++)
                for (int j = i + 1; j < N; j++)
                    if (array[i, 0] < array[j, 0])
                        for (int k = 0; k < M; k++)
                            (array[i, k], array[j, k]) = (array[j, k], array[i, k]);

            for (int i = 0; i < N; i++, descSorted.Text += "\n")
                for (int j = 0; j < M; j++)
                    descSorted.Text += $"{array[i, j]} ";
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }
    }
}
