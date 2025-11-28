using System;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Transformese.Desktop.Views
{
    public class ucCursos : BaseCrudListControl
    {
        public ucCursos(System.Net.Http.HttpClient http) : base(http, "Cursos")
        {
            _ = LoadDataAsync();
        }

        private async Task LoadDataAsync()
        {
            var data = await GetJsonAsync("api/cursos");
            BindGrid(data, "idCurso", "nome", "descricao", "unidadeId");
        }

        protected override async Task OnNewAsync()
        {
            MessageBox.Show("Implementar formulário de criação de curso.");
        }

        protected override async Task OnEditAsync()
        {
            if (_grid.CurrentRow == null) return;
            var id = int.Parse(_grid.CurrentRow.Cells[0].Value?.ToString() ?? "0");
            MessageBox.Show($"Implementar edição do curso #{id}.");
        }

        protected override async Task OnDeleteAsync()
        {
            if (_grid.CurrentRow == null) return;
            var id = int.Parse(_grid.CurrentRow.Cells[0].Value?.ToString() ?? "0");
            if (MessageBox.Show($"Excluir curso #{id}?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                var resp = await _http.DeleteAsync($"api/cursos/{id}");
                if (!resp.IsSuccessStatusCode) MessageBox.Show("Erro ao excluir.");
                await LoadDataAsync();
            }
        }
    }
}
