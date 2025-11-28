using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;

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
                // determine user type: prefer Session.Tipo, fallback to JWT role
                var tipo = Session.Tipo ?? string.Empty;

                if (string.IsNullOrWhiteSpace(tipo) && !string.IsNullOrEmpty(Session.Token))
                {
                    try
                    {
                        var handler = new JwtSecurityTokenHandler();
                        var jwt = handler.ReadJwtToken(Session.Token);
                        // check common claim names for role
                        var roleClaim = jwt.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role || c.Type == "role" || c.Type.EndsWith("/role"));
                        if (roleClaim != null)
                        {
                            tipo = roleClaim.Value ?? string.Empty;
                            Session.Tipo = tipo;
                        }
                    }
                    catch
                    {
                        // ignore token parse errors
                    }
                }

                Form mainForm = tipo switch
                {
                    "Administrador" => new frmAdmin(),
                    "Professor" => new frmProfessor(),
                    "Aluno" => new frmAluno(),
                    _ => new Form { Text = $"Transformese", Width = 1000, Height = 700 }
                };

                Application.Run(mainForm);
            }
        }
    }
}
