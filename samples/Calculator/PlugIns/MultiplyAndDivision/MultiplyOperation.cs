using Hik.Sps;
using CalculatorPlugInLib;

namespace MultiplyAndDivision
{
    [PlugIn("Multiply")]
    public class MultiplyOperation : PlugIn<ICalculatorApplication>, ICalculatorOperationPlugIn
    {
        public string OperationSign
        {
            get { return "*"; }
        }

        public double DoOperation(double number1, double number2)
        {
            return number1 * number2;
        }
    }
}
