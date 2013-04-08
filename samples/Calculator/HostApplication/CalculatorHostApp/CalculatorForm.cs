using System;
using System.IO;
using System.Reflection;
using System.Windows.Forms;

namespace CalculatorHostApp
{
    public partial class CalculatorForm : Form
    {
        /// <summary>
        /// The plug-in manager objects to communicate with plug-ins.
        /// </summary>
        private readonly CalculatorPlugInManager _plugInManager;

        public CalculatorForm()
        {
            InitializeComponent();

            //Create plug-in manager and set plug-in directory
            _plugInManager = new CalculatorPlugInManager();
            _plugInManager.PlugInFolder = Path.Combine(GetCurrentDirectory(), "PlugIns");
            
            //Load all plugins
            _plugInManager.LoadPlugIns();

            //Fill combobox and listbox by plugins
            foreach (var plugIn in _plugInManager.PlugIns)
            {
                cmbOperation.Items.Add(plugIn.PlugInProxy.OperationSign);
                lstPlugIns.Items.Add(plugIn.Name);
            }
            
            //Select first operation in combobox
            if (cmbOperation.Items.Count > 0)
            {
                cmbOperation.SelectedIndex = 0;
            }
            else
            {
                btnCalculate.Enabled = false;
            }
        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            //Get inputs from form
            var number1 = Convert.ToDouble(txtNumber1.Text);
            var number2 = Convert.ToDouble(txtNumber2.Text);
            var operation = cmbOperation.SelectedItem.ToString();

            //Calculate!
            var result = Calculate(operation, number1, number2);

            lblResult.Text = result.ToString("0.0");
        }

        public double Calculate(string operation, double number1, double number2)
        {
            //Find the plug-in according to operation
            foreach (var plugIn in _plugInManager.PlugIns)
            {
                if (plugIn.PlugInProxy.OperationSign == operation)
                {
                    //Calculate result using plug-in
                    return plugIn.PlugInProxy.DoOperation(number1, number2);
                }
            }

            throw new ApplicationException("Can not found any plug-in for operation " + operation);
        }

        private static string GetCurrentDirectory()
        {
            try
            {
                return (new FileInfo(Assembly.GetExecutingAssembly().Location)).Directory.FullName;
            }
            catch (Exception)
            {
                return Directory.GetCurrentDirectory();
            }
        }
    }
}
