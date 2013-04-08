using Hik.Sps;
using CalculatorPlugInLib;

namespace MultiplyAndDivision
{
    [PlugIn("Division")]
    public class DivisionOperation : PlugIn<ICalculatorApplication>, ICalculatorOperationPlugIn
    {
        public string OperationSign
        {
            get { return "/"; }
        }

        public double DoOperation(double number1, double number2)
        {
            if (number2 == 0.0)
            {
                Application.ApplicationProxy.ShowMessage("Second number can not be zero in division!");
                return 0.0;
            }

            return number1 / number2;
        }
    }
}