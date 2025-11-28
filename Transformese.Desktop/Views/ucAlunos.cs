using System;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Transformese.Desktop.Views
{
    public class ucAlunos : BaseCrudListControl
    {
        public ucAlunos(System.Net.Http.HttpClient http) : base(http, "Alunos")
        {
            _ = LoadDataAsync();
        }

        private async Task LoadDataAsync()
        {
            var data = await GetJsonAsync("api/usuarios");
            if (data != null && data.Value.ValueKind == JsonValueKind.Array)
            {
                var arr = new System.Text.Json.Nodes.JsonArray();
                foreach (var u in data.Value.EnumerateArray())
                {
                    if (u.TryGetProperty("tipoUsuarioId", out var t) && t.GetInt32() == 3) // assume 3=Aluno
                        arr.Add(System.Text.Json.Nodes.JsonNode.Parse(u.GetRawText()));
                }
                BindGrid(JsonDocument.Parse(arr.ToJsonString()).RootElement, "idUsuario", "nome", "email", "tipoUsuarioId");
            }
        }

        protected override async Task OnNewAsync()
        {
            using var f = new frmCreateUser();
            if (f.ShowDialog() == DialogResult.OK)
                await LoadDataAsync();
        }

        protected override async Task OnEditAsync()
        {
            if (_grid.CurrentRow == null) return;
            var id = int.Parse(_grid.CurrentRow.Cells[0].Value?.ToString() ?? "0");
            MessageBox.Show($"Implementar edição do usuário #{id}.");
        }

        protected override async Task OnDeleteAsync()
        {
            if (_grid.CurrentRow == null) return;
            var id = int.Parse(_grid.CurrentRow.Cells[0].Value?.ToString() ?? "0");
            if (MessageBox.Show($"Excluir aluno #{id}?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                var resp = await _http.DeleteAsync($"api/usuarios/{id}");
                if (!resp.IsSuccessStatusCode) MessageBox.Show("Erro ao excluir.");
                await LoadDataAsync();
            }
        }
    }
}
