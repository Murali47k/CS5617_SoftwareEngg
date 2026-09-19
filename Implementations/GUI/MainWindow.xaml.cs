using System;
using System.IO;
using System.Threading;
using System.Windows;

namespace GUI
{
    public partial class MainWindow : Window
    {
        string filePath;
        Thread fileThread;
        DateTime lastModified;

        public MainWindow()
        {
            InitializeComponent();

            filePath = Path.Combine(
                Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory)!.Parent!.Parent!.Parent!.FullName,
                "data.txt"
            );

            // Store the current modification time
            if (File.Exists(filePath))
            {
                lastModified = File.GetLastWriteTime(filePath);
            }

            // Start background thread
            fileThread = new Thread(CheckFile);
            fileThread.IsBackground = true;
            fileThread.Start();
        }

        // Background thread
        private void CheckFile()
        {
            while (true)
            {
                if (File.Exists(filePath))
                {
                    DateTime currentModified = File.GetLastWriteTime(filePath);

                    if (currentModified != lastModified)
                    {
                        lastModified = currentModified;
                    }
                }

                Thread.Sleep(500);
            }
        }

        // Runs on the MAIN/UI thread
        private void ReadFile_Click(object sender, RoutedEventArgs e)
        {
            if (File.Exists(filePath))
            {
                string text = File.ReadAllText(filePath);

                OutputTextBox.Text = text;
            }
            else
            {
                MessageBox.Show(
                    "data.txt file was not found!",
                    "Error",
                    MessageBoxButton.OK,
                    MessageBoxImage.Error
                );
            }
        }
    }
}

