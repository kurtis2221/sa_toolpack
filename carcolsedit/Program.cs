using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace carcolsedit
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        const string dllfile = "toolpack.dll";
        [STAThread]
        static void Main()
        {
            if (!System.IO.File.Exists(dllfile))
            {
                MessageBox.Show(
                    "toolpack.dll not found! Shutting Down!\n" +
                    "toolpack.dll nem található! A program leáll!",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
            else
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new Form1());
            }
        }
    }
}
