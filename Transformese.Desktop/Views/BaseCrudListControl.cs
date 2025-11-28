using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;
using Guna.UI2.WinForms;
using System.Text.Json;
using System.Linq;

namespace Transformese.Desktop.Views
{
    // Base UserControl that renders a header with CRUD buttons and a grid
    public class BaseCrudListControl : UserControl
    {
        protected internal readonly HttpClient _http;
        protected readonly Guna2Panel _header;
        protected readonly Guna2Button _btnNew;
        protected readonly Guna2Button _btnEdit;
        protected readonly Guna2Button _btnDelete;
        protected readonly Guna2TextBox _txtSearch;
        protected readonly Guna2DataGridView _grid;
        protected readonly Label _title;

        public BaseCrudListControl(HttpClient http, string title)
        {
            _http = http;
            Dock = DockStyle.Fill;
            BackColor = System.Drawing.Color.White;

            _header = new Guna2Panel { Dock = DockStyle.Top, Height = 64, Padding = new Padding(12), FillColor = System.Drawing.Color.White };
            _title = new Label { Text = title, Dock = DockStyle.Left, AutoSize = false, Width = 220, Font = new System.Drawing.Font("Segoe UI", 16, System.Drawing.FontStyle.Bold) };
            _txtSearch = new Guna2TextBox { PlaceholderText = "Pesquisar...", Width = 240, BorderRadius = 8, Anchor = AnchorStyles.Top | AnchorStyles.Right };
            _btnNew = new Guna2Button { Text = "+ Novo", BorderRadius = 8, Width = 100 };
            _btnEdit = new Guna2Button { Text = "Editar", BorderRadius = 8, Width = 100 };
            _btnDelete = new Guna2Button { Text = "Excluir", BorderRadius = 8, Width = 100, FillColor = System.Drawing.Color.FromArgb(231, 76, 60) };

            _grid = new Guna2DataGridView { Dock = DockStyle.Fill, ReadOnly = true, AllowUserToAddRows = false, AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill };

            Controls.Add(_grid);
            Controls.Add(_header);
            _header.Controls.Add(_title);
            _header.Controls.Add(_btnDelete);
            _header.Controls.Add(_btnEdit);
            _header.Controls.Add(_btnNew);
            _header.Controls.Add(_txtSearch);

            // layout simple
            _txtSearch.Left = Width - _txtSearch.Width - 12;
            _txtSearch.Top = 16;
            _btnNew.Left = _txtSearch.Left - _btnNew.Width - 8;
            _btnNew.Top = 12;
            _btnEdit.Left = _btnNew.Left - _btnEdit.Width - 8;
            _btnEdit.Top = 12;
            _btnDelete.Left = _btnEdit.Left - _btnDelete.Width - 8;
            _btnDelete.Top = 12;

            Resize += (s, e) =>
            {
                _txtSearch.Left = Width - _txtSearch.Width - 12;
                _btnNew.Left = _txtSearch.Left - _btnNew.Width - 8;
                _btnEdit.Left = _btnNew.Left - _btnEdit.Width - 8;
                _btnDelete.Left = _btnEdit.Left - _btnDelete.Width - 8;
            };

            _btnNew.Click += async (s, e) => await OnNewAsync();
            _btnEdit.Click += async (s, e) => await OnEditAsync();
            _btnDelete.Click += async (s, e) => await OnDeleteAsync();
        }

        protected virtual Task OnNewAsync() => Task.CompletedTask;
        protected virtual Task OnEditAsync() => Task.CompletedTask;
        protected virtual Task OnDeleteAsync() => Task.CompletedTask;

        protected async Task<JsonElement?> GetJsonAsync(string route)
        {
            try
            {
                var resp = await _http.GetAsync(route);
                if (!resp.IsSuccessStatusCode) return null;
                var json = await resp.Content.ReadAsStringAsync();
                return JsonDocument.Parse(json).RootElement;
            }
            catch { return null; }
        }

        protected void BindGrid(JsonElement? el, params string[] columns)
        {
            _grid.Columns.Clear();
            _grid.Rows.Clear();
            if (el == null) return;
            if (el.Value.ValueKind == JsonValueKind.Array)
            {
                foreach (var c in columns) _grid.Columns.Add(c, c);
                foreach (var item in el.Value.EnumerateArray())
                {
                    var vals = columns.Select(col => (item.TryGetProperty(col, out var p) ? p.ToString() : string.Empty)).ToArray();
                    _grid.Rows.Add(vals);
                }
            }
        }
    }
}
