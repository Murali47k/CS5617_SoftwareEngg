using System;
using System.IO;
using System.Windows;

namespace GUI
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ReadFile_Click(object sender, RoutedEventArgs e)
        {
            string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory,"data.txt");

            if (File.Exists(filePath))
            {
                string text = File.ReadAllText(filePath);

                OutputTextBox.Text = text;
            }
            else
            {
                MessageBox.Show("data.txt file was not found!","Error",MessageBoxButton.OK,MessageBoxImage.Error);
            }
        }
    }
}