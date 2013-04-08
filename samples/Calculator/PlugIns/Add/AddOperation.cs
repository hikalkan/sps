using Hik.Sps;
using CalculatorPlugInLib;

namespace Add
{
    [PlugIn("Addition")]
    public class AddOperation : PlugIn<ICalculatorApplication>, ICalculatorOperationPlugIn
    {
        public string OperationSign
        {
            get { return "+"; }
        }

        public double DoOperation(double number1, double number2)
        {
            return number1 + number2;
        }
    }
}
