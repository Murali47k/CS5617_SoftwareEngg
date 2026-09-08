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
        private double firstNumber;
        private string operation = "";

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
                parameter => EnterNumber(parameter.ToString())
            );

            OperationCommand = new RelayCommand(
                parameter => SetOperation(parameter.ToString())
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
                Display = number;
            else
                Display += number;
        }

        private void SetOperation(string op)
        {
            firstNumber = double.Parse(Display);
            operation = op;
            Display = "0";
        }

        private void Calculate()
        {
            double secondNumber = double.Parse(Display);
            double result = 0;

            switch (operation)
            {
                case "+":
                    result = model.Add(firstNumber, secondNumber);
                    break;

                case "-":
                    result = model.Subtract(firstNumber, secondNumber);
                    break;

                case "*":
                    result = model.Multiply(firstNumber, secondNumber);
                    break;

                case "/":
                    result = model.Divide(firstNumber, secondNumber);
                    break;
            }

            Display = result.ToString();
        }

        private void Clear()
        {
            Display = "0";
            firstNumber = 0;
            operation = "";
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(
            [CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(
                this,
                new PropertyChangedEventArgs(propertyName));
        }
    }
}