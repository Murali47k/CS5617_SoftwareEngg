using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Calculator.App.Models;

namespace Calculator.App.ViewModels
{
    public class CalculatorViewModel : INotifyPropertyChanged
    {
        private readonly CalculatorModel model;

        private string display = "0";

        public string Display
        {
            get { return display; }
            set
            {
                display = value;
                OnPropertyChanged();
            }
        }

        public ICommand NumberCommand { get; }
        public ICommand OperationCommand { get; }
        public ICommand EqualsCommand { get; }
        public ICommand ClearCommand { get; }

        public CalculatorViewModel()
        {
            model = new CalculatorModel();

            NumberCommand = new RelayCommand(
                parameter => EnterNumber(parameter?.ToString() ?? "")
            );

            OperationCommand = new RelayCommand(
                parameter => EnterOperation(parameter?.ToString() ?? "")
            );

            EqualsCommand = new RelayCommand(
                parameter => Calculate()
            );

            ClearCommand = new RelayCommand(
                parameter => Clear()
            );
        }

        private void EnterNumber(string number)
        {
            if (Display == "0")
            {
                Display = number;
            }
            else
            {
                Display += number;
            }
        }

        private void EnterOperation(string op)
        {
            Display += op;
        }

        private void Calculate()
        {
            try
            {
                double result = model.Evaluate(Display);

                Display = result.ToString();
            }
            catch
            {
                Display = "Error";
            }
        }

        private void Clear()
        {
            Display = "0";
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        private void OnPropertyChanged(
            [CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(
                this,
                new PropertyChangedEventArgs(propertyName));
        }
    }
}