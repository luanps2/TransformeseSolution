using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Transformese.Desktop
{
    internal static class Program
    {
        [STAThread]
        static async Task Main()
        {
            ApplicationConfiguration.Initialize();
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // show login form
            using var login = new frmLogin();
            var result = login.ShowDialog();
            if (result == DialogResult.OK)
            {
                // open main form placeholder
                Application.Run(new Form { Text = $"Transformese", Width = 1000, Height = 700 });
            }
        }
    }
}
