using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Transformese.Desktop
{
    public partial class LoginForm : Form
    {
        private readonly HttpClient _httpClient;

        public LoginForm()
        {
            _httpClient = new HttpClient { BaseAddress = new Uri("https://localhost:5001/") };
            InitializeComponent();
        }

        // Designer-friendly event handler signature
        private async void BtnLogin_Click(object? sender, EventArgs e)
        {
            // forward to async worker
            await BtnLogin_ClickAsync(sender, e);
        }

        private async Task BtnLogin_ClickAsync(object? sender, EventArgs e)
        {
            // locate button control safely
            var btn = this.ControlsFind<Guna.UI2.WinForms.Guna2GradientButton>("btnLogin");
            if (btn != null) btn.Enabled = false;

            try
            {
                // find inputs
                var txtEmail = this.ControlsFind<Guna.UI2.WinForms.Guna2TextBox>("txtEmail");
                var txtPassword = this.ControlsFind<Guna.UI2.WinForms.Guna2TextBox>("txtPassword");
                var email = txtEmail?.Text?.Trim() ?? string.Empty;
                var senha = txtPassword?.Text ?? string.Empty;

                var payload = new { Email = email, Senha = senha };
                var response = await _httpClient.PostAsJsonAsync("api/auth/login", payload);
                if (!response.IsSuccessStatusCode)
                {
                    var err = await response.Content.ReadAsStringAsync();
                    MessageBox.Show(this, err, "Login failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var json = await response.Content.ReadAsStringAsync();
                var doc = JsonDocument.Parse(json);
                var root = doc.RootElement;
                var token = root.GetProperty("token").GetString();
                var nome = root.GetProperty("nome").GetString();

                // Store token in a simple static session
                Session.Token = token ?? string.Empty;
                Session.Nome = nome ?? string.Empty;

                MessageBox.Show(this, $"Bem-vindo, {Session.Nome}!", "Login successful", MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                var btn2 = this.ControlsFind<Guna.UI2.WinForms.Guna2GradientButton>("btnLogin");
                if (btn2 != null) btn2.Enabled = true;
            }
        }
    }

    // simple static session container
    public static class Session
    {
        public static string Token { get; set; } = string.Empty;
        public static string Nome { get; set; } = string.Empty;
    }

    // small helper extension to find controls by field name created by designer
    public static class ControlExtensions
    {
        public static T? ControlsFind<T>(this Control parent, string fieldName) where T : Control
        {
            // designer fields are private; we try to find by runtime type and maybe matching placeholder like Name
            foreach (Control c in parent.Controls)
            {
                if (c is T t && string.Equals(c.Name, fieldName, StringComparison.OrdinalIgnoreCase))
                    return t;

                // recursive
                var found = c.ControlsFind<T>(fieldName);
                if (found != null) return found;
            }
            // fallback: try first T
            foreach (Control c in parent.Controls)
                if (c is T t) return t;
            return default;
        }
    }
}
