using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;
using Guna.UI2.WinForms;

namespace Transformese.Desktop
{
    public partial class LoginForm : Form
    {
        private HttpClient? _httpClient; // inicializado no Load

        public LoginForm()
        {
            InitializeComponent();
        }

        // Inicializa recursos que só devem rodar em tempo de execução (evita problemas no designer)
        private void LoginForm_Load(object? sender, EventArgs e)
        {
            try
            {
                _httpClient = new HttpClient { BaseAddress = new Uri("https://localhost:5001/") };
            }
            catch
            {
                _httpClient = null;
            }
        }

        // Handler ligado pelo designer (assinatura void para o designer carregar)
        private async void BtnLogin_Click(object? sender, EventArgs e)
        {
            await BtnLogin_ClickAsync(sender, e);
        }

        // Lógica assíncrona real
        private async Task BtnLogin_ClickAsync(object? sender, EventArgs e)
        {
            var btn = this.ControlsFind<Guna2GradientButton>("btnLogin");
            if (btn != null) btn.Enabled = false;

            try
            {
                if (_httpClient == null)
                {
                    MessageBox.Show(this, "HttpClient não inicializado.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                var txtEmail = this.ControlsFind<Guna2TextBox>("txtEmail");
                var txtPassword = this.ControlsFind<Guna2TextBox>("txtPassword");
                var email = txtEmail?.Text?.Trim() ?? string.Empty;
                var senha = txtPassword?.Text ?? string.Empty;

                if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(senha))
                {
                    MessageBox.Show(this, "Preencha e-mail e senha.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

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
                var btn2 = this.ControlsFind<Guna2GradientButton>("btnLogin");
                if (btn2 != null) btn2.Enabled = true;
            }
        }

        // fechar
        private void BtnClose_Click(object? sender, EventArgs e)
        {
            this.Close();
        }

        // cadastrar (placeholder)
        private void BtnRegister_Click(object? sender, EventArgs e)
        {
            MessageBox.Show(this, "Tela de cadastro não implementada.", "Cadastrar", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }

    // sessão simples
    public static class Session
    {
        public static string Token { get; set; } = string.Empty;
        public static string Nome { get; set; } = string.Empty;
    }

    // helper para localizar controles em runtime
    public static class ControlExtensions
    {
        public static T? ControlsFind<T>(this Control parent, string fieldName) where T : Control
        {
            foreach (Control c in parent.Controls)
            {
                if (c is T t && string.Equals(c.Name, fieldName, StringComparison.OrdinalIgnoreCase))
                    return t;

                var found = c.ControlsFind<T>(fieldName);
                if (found != null) return found;
            }
            foreach (Control c in parent.Controls)
                if (c is T t) return t;
            return default;
        }
    }
}
