using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.Json;

namespace Transformese.Desktop
{
    public partial class frmAluno : Form
    {
        private readonly HttpClient _httpClient;

        public frmAluno()
        {
            InitializeComponent();
            _httpClient = new HttpClient { BaseAddress = new Uri("https://localhost:5001/") };
        }

        private async void frmAluno_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Session.Token))
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Session.Token);

            await LoadCoursesAsync();
        }

        private async Task LoadCoursesAsync()
        {
            try
            {
                var resp = await _httpClient.GetAsync("api/cursos");
                if (!resp.IsSuccessStatusCode) return;
                var json = await resp.Content.ReadAsStringAsync();
                txtCourses.Text = JsonDocument.Parse(json).RootElement.ToString();
            }
            catch (Exception ex) { MessageBox.Show(this, ex.Message); }
        }

        private void btnEnroll_Click(object sender, EventArgs e)
        {
            MessageBox.Show(this, "Implementar matrícula em curso (API necessária).", "Matricular", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
