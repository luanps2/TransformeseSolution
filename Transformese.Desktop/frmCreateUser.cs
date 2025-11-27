using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Transformese.Desktop
{
    public partial class frmCreateUser : Form
    {
        private readonly HttpClient _httpClient = new HttpClient { BaseAddress = new Uri("https://localhost:5001/") };

        public frmCreateUser()
        {
            InitializeComponent();
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            var nome = txtNome.Text;
            var email = txtEmail.Text;
            var senha = txtSenha.Text;
            var tipo = int.TryParse(txtTipo.Text, out var t) ? t : 3;

            if (string.IsNullOrWhiteSpace(nome) || string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(senha))
            {
                MessageBox.Show(this, "Preencha todos os campos.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var user = new { Nome = nome, Email = email, Senha = senha, TipoUsuarioId = tipo };
            var resp = await _httpClient.PostAsJsonAsync("api/usuarios", user);
            if (resp.IsSuccessStatusCode)
            {
                MessageBox.Show(this, "Usuário criado.", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                var err = await resp.Content.ReadAsStringAsync();
                MessageBox.Show(this, err, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
