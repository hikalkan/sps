using System.Windows.Forms;
using CalculatorPlugInLib;
using Hik.Sps;

namespace CalculatorHostApp
{
    /// <summary>
    /// Implements ICalculatorApplication and provides a container/manager for plug-ins
    /// </summary>
    [PlugInApplication("Calculator")]
    internal class CalculatorPlugInManager : PlugInBasedApplication<ICalculatorOperationPlugIn>, ICalculatorApplication
    {
        /// <summary>
        /// This method can be called by plugins to show a message to the user if needed.
        /// </summary>
        /// <param name="message">The message to be shown</param>
        public void ShowMessage(string message)
        {
            MessageBox.Show(message);
        }
    }
}
