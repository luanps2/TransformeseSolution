using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.Json;
using System.Linq;
using System.Drawing;

namespace Transformese.Desktop
{
    public partial class frmAdmin : Form
    {
        private readonly HttpClient _httpClient;

        public frmAdmin()
        {
            InitializeComponent();
            _httpClient = new HttpClient { BaseAddress = new Uri("https://localhost:5001/") };

            // wire menu clicks
           
            btnAdministradores.Click += (_, __) => NavigateTo(new Views.ucAdministradores(_httpClient));
            btnProfessores.Click += (_, __) => NavigateTo(new Views.ucProfessores(_httpClient));
            btnAlunos.Click += (_, __) => NavigateTo(new Views.ucAlunos(_httpClient));
            btnCursos.Click += (_, __) => NavigateTo(new Views.ucCursos(_httpClient));
            btnUnidades.Click += (_, __) => NavigateTo(new Views.ucUnidades(_httpClient));
        }

        private async void frmAdmin_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Session.Token))
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Session.Token);

            // load header info
            lblUserName.Text = string.IsNullOrWhiteSpace(Session.Nome) ? "Administrador" : Session.Nome;
            lblUserEmail.Text = !string.IsNullOrWhiteSpace(Session.Tipo) ? Session.Tipo : "";
            try { imgAvatar.Image = Properties.Resources.user; } catch { }

           
        }

        private void NavigateTo(UserControl control)
        {
            pnlContent.SuspendLayout();
            pnlContent.Controls.Clear();
            control.Dock = DockStyle.Fill;
            pnlContent.Controls.Add(control);
            pnlContent.ResumeLayout();
        }

        private void btnHome_Click(object sender, EventArgs e)
        {

        }
    }
}
