using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using LabV1Data;

namespace LabV1Application
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            try
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new PrimaryForm());
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, "Greska pri izvrsenju", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
