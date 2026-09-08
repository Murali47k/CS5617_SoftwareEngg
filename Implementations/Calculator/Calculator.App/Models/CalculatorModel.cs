using System.Data;

namespace Calculator.App.Models
{
    public class CalculatorModel
    {
        public double Add(double a, double b)
        {
            return a + b;
        }

        public double Subtract(double a, double b)
        {
            return a - b;
        }

        public double Multiply(double a, double b)
        {
            return a * b;
        }

        public double Divide(double a, double b)
        {
            if (b == 0)
                throw new DivideByZeroException();

            return a / b;
        }

        public double Evaluate(string expression)
        {
            DataTable table = new DataTable();

            object result = table.Compute(expression, "");

            return Math.Round(Convert.ToDouble(result),5);
        }
    }
}