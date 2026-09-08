using System.Windows;
using Calculator.App.ViewModels;

namespace Calculator.App.Views
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            DataContext = new CalculatorViewModel();
        }
    }
}