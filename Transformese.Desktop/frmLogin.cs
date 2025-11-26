using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Transformese.Desktop
{
    public partial class frmLogin : Form
    {
        private HttpClient? _httpClient;

        public frmLogin()
        {
            InitializeComponent();

            // wiring dos eventos (caso não estejam ligados no Designer)
            btnEntrar.Click += BtnEntrar_Click;
            btnCadastrar.Click += BtnCadastrar_Click;
        }

        private async void BtnEntrar_Click(object? sender, EventArgs e)
        {
            await HandleLoginAsync();
        }

        private async Task HandleLoginAsync()
        {
            btnEntrar.Enabled = false;
            try
            {
                var email = guna2TextBox1.Text?.Trim() ?? string.Empty;
                var senha = guna2TextBox2.Text ?? string.Empty;

                if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(senha))
                {
                    MessageBox.Show(this, "Preencha usuário e senha.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                _httpClient ??= new HttpClient { BaseAddress = new Uri("https://localhost:5001/") };

                var payload = new { Email = email, Senha = senha };
                var resp = await _httpClient.PostAsJsonAsync("api/auth/login", payload);

                if (!resp.IsSuccessStatusCode)
                {
                    var err = await resp.Content.ReadAsStringAsync();
                    MessageBox.Show(this, string.IsNullOrWhiteSpace(err) ? "Falha no login." : err, "Login", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var json = await resp.Content.ReadAsStringAsync();
                var doc = JsonDocument.Parse(json);
                var root = doc.RootElement;
                var token = root.GetProperty("token").GetString();
                var nome = root.GetProperty("nome").GetString();

                Session.Token = token ?? string.Empty; // usa classe Session já existente no projeto
                Session.Nome = nome ?? string.Empty;

                MessageBox.Show(this, $"Bem-vindo, {Session.Nome}!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                btnEntrar.Enabled = true;
            }
        }

        private void BtnCadastrar_Click(object? sender, EventArgs e)
        {
            // abrir formulário de cadastro ou navegação para criar conta
            MessageBox.Show(this, "Funcionalidade de cadastro não implementada.", "Cadastrar", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnEntrar_Click_1(object sender, EventArgs e)
        {

        }
    }
}
