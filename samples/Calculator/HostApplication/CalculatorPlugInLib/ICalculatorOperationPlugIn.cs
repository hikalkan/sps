using Hik.Sps;
namespace CalculatorPlugInLib
{
    /// <summary>
    /// Defines the plug-in interface for the calculator application.
    /// A class must implement this interface to be a plug-in for the calculator.
    /// Calculator application uses plug-ins through this interface.
    /// </summary>
    public interface ICalculatorOperationPlugIn : IPlugIn
    {
        /// <summary>
        /// Gets the sign that represents this operation.
        /// For adding, it may be a plus sign (+).
        /// </summary>
        string OperationSign { get; }

        /// <summary>
        /// Performs the operation.
        /// </summary>
        /// <param name="number1">First number</param>
        /// <param name="number2">Second number</param>
        /// <returns>Result of opeartion according to this operation</returns>
        double DoOperation(double number1, double number2);
    }
}
