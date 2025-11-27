using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.Json;
using System.Linq;

namespace Transformese.Desktop
{
    public partial class frmAdmin : Form
    {
        private readonly HttpClient _httpClient;

        public frmAdmin()
        {
            InitializeComponent();
            _httpClient = new HttpClient { BaseAddress = new Uri("https://localhost:5001/") };
        }

        private async void frmAdmin_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Session.Token))
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Session.Token);

            await RefreshAllAsync();
        }

        private async Task RefreshAllAsync()
        {
            var users = await GetJsonAsync("api/usuarios");
            var courses = await GetJsonAsync("api/cursos");
            var units = await GetJsonAsync("api/unidades");

            // update cards
            lblUsersCount.Text = $"{GetCount(users)}\nUsers";
            lblCoursesCount.Text = $"{GetCount(courses)}\nCursos";
            lblUnitsCount.Text = $"{GetCount(units)}\nUnidades";
            lblEnrollmentsCount.Text = "0\nMatriculas"; // needs API for enrollments

            // bind grids (simple binding via JsonDocument)
            BindGrid(dgvUsers, users, new[] { "idUsuario", "nome", "email", "tipoUsuarioId" });
            BindGrid(dgvCourses, courses, new[] { "idCurso", "nome", "descricao", "unidadeId" });
            BindGrid(dgvUnits, units, new[] { "idUnidade", "nome", "endereco" });
        }

        private int GetCount(JsonElement? el)
        {
            if (el == null) return 0;
            if (el.Value.ValueKind == JsonValueKind.Array) return el.Value.GetArrayLength();
            return 1;
        }

        private async Task<JsonElement?> GetJsonAsync(string route)
        {
            try
            {
                var resp = await _httpClient.GetAsync(route);
                if (!resp.IsSuccessStatusCode) return null;
                var json = await resp.Content.ReadAsStringAsync();
                return JsonDocument.Parse(json).RootElement;
            }
            catch { return null; }
        }

        private void BindGrid(Guna.UI2.WinForms.Guna2DataGridView dgv, JsonElement? el, string[] columns)
        {
            dgv.Columns.Clear();
            dgv.Rows.Clear();
            if (el == null) return;
            if (el.Value.ValueKind == JsonValueKind.Array)
            {
                foreach (var c in columns) dgv.Columns.Add(c, c);
                foreach (var item in el.Value.EnumerateArray())
                {
                    var vals = columns.Select(col => (item.TryGetProperty(col, out var p) ? p.ToString() : string.Empty)).ToArray();
                    dgv.Rows.Add(vals);
                }
            }
            else
            {
                foreach (var prop in el.Value.EnumerateObject())
                {
                    dgv.Columns.Add(prop.Name, prop.Name);
                    dgv.Rows.Add(prop.Value.ToString());
                }
            }
        }

        private void btnCreateUser_Click(object sender, EventArgs e)
        {
            using var f = new frmCreateUser();
            if (f.ShowDialog() == DialogResult.OK)
            {
                _ = RefreshAllAsync();
            }
        }

        private void btnCreateCourse_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Criar curso (implementar frmEditCourse)");
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            _ = RefreshAllAsync();
        }
    }
}
