using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.Json;

namespace Transformese.Desktop
{
    public partial class frmProfessor : Form
    {
        private readonly HttpClient _httpClient;

        public frmProfessor()
        {
            InitializeComponent();
            _httpClient = new HttpClient { BaseAddress = new Uri("https://localhost:5001/") };
        }

        private async void frmProfessor_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Session.Token))
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Session.Token);

            await LoadCoursesAsync();
            await LoadStudentsAsync();
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

        private async Task LoadStudentsAsync()
        {
            try
            {
                var resp = await _httpClient.GetAsync("api/usuarios");
                if (!resp.IsSuccessStatusCode) return;
                var json = await resp.Content.ReadAsStringAsync();
                txtStudents.Text = JsonDocument.Parse(json).RootElement.ToString();
            }
            catch (Exception ex) { MessageBox.Show(this, ex.Message); }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            _ = LoadCoursesAsync();
            _ = LoadStudentsAsync();
        }
    }
}
