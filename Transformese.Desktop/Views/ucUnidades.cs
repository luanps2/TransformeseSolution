using System;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Http.Json;

namespace Transformese.Desktop.Views
{
    public class ucUnidades : BaseCrudListControl
    {
        public ucUnidades(System.Net.Http.HttpClient http) : base(http, "Unidades")
        {
            _ = LoadDataAsync();
        }

        private async Task LoadDataAsync()
        {
            var data = await GetJsonAsync("api/unidades");
            BindGrid(data, "idUnidade", "nome", "endereco");
        }

        protected override async Task OnNewAsync()
        {
            var nome = Microsoft.VisualBasic.Interaction.InputBox("Nome da Unidade", "Nova Unidade");
            var endereco = Microsoft.VisualBasic.Interaction.InputBox("Endereço", "Nova Unidade");
            if (!string.IsNullOrWhiteSpace(nome))
            {
                var resp = await _http.PostAsJsonAsync("api/unidades", new { Nome = nome, Endereco = endereco });
                if (!resp.IsSuccessStatusCode) MessageBox.Show("Erro ao criar unidade.");
                await LoadDataAsync();
            }
        }

        protected override async Task OnEditAsync()
        {
            if (_grid.CurrentRow == null) return;
            var id = int.Parse(_grid.CurrentRow.Cells[0].Value?.ToString() ?? "0");
            var nome = Microsoft.VisualBasic.Interaction.InputBox("Nome", "Editar Unidade", _grid.CurrentRow.Cells[1].Value?.ToString());
            var endereco = Microsoft.VisualBasic.Interaction.InputBox("Endereço", "Editar Unidade", _grid.CurrentRow.Cells[2].Value?.ToString());
            var resp = await _http.PutAsJsonAsync($"api/unidades/{id}", new { Nome = nome, Endereco = endereco });
            if (!resp.IsSuccessStatusCode) MessageBox.Show("Erro ao atualizar unidade.");
            await LoadDataAsync();
        }

        protected override async Task OnDeleteAsync()
        {
            if (_grid.CurrentRow == null) return;
            var id = int.Parse(_grid.CurrentRow.Cells[0].Value?.ToString() ?? "0");
            if (MessageBox.Show($"Excluir unidade #{id}?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                var resp = await _http.DeleteAsync($"api/unidades/{id}");
                if (!resp.IsSuccessStatusCode) MessageBox.Show("Erro ao excluir unidade.");
                await LoadDataAsync();
            }
        }
    }
}
