using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Transformese.Domain.Entities;
using Transformese.MVC.Services;

namespace TransformeSeMVC.Web.Controllers
{
    [Authorize(Roles = "Administrador, Aluno")]
    public class AlunoController : Controller
    {
        private readonly IUsuarioApiClient _usuarioApi;

        public AlunoController(IUsuarioApiClient usuarioApi)
        {
            _usuarioApi = usuarioApi;
        }

        // GET: /Aluno
        public async Task<IActionResult> Index()
        {
            var usuarios = await _usuarioApi.GetAllAsync(); // IEnumerable<Usuario>
            var alunosDto = (usuarios ?? Enumerable.Empty<Usuario>())
                .Where(u => u.TipoUsuarioId == 3)
                .Select(u => new UsuarioDto
                {
                    IdUsuario = u.IdUsuario,
                    Nome = u.Nome,
                    Email = u.Email,
                    DataNascimento = u.DataNascimento,
                    Imagem = u.FotoPerfil,
                    TipoUsuarioId = u.TipoUsuarioId,
                    TipoUsuarioDescricao = u.TipoUsuario?.DescricaoTipoUsuario ?? "Aluno"
                })
                .ToList();

            return View(alunosDto);
        }

        // GET: /Aluno/Create
        [HttpGet]
        public IActionResult Create()
        {
            return View(new UsuarioDto());
        }

        // POST: /Aluno/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(IFormCollection form, IFormFile? FotoPerfil)
        {
            // Validação básica dos campos esperados
            var nome = form["Nome"].ToString();
            var email = form["Email"].ToString();
            var senha = form["Senha"].ToString();
            var dataNascimentoRaw = form["DataNascimento"].ToString();
            var tipoUsuarioIdRaw = form["TipoUsuarioId"].ToString();
            if (string.IsNullOrWhiteSpace(nome) || string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(senha))
            {
                ModelState.AddModelError("", "Nome, Email e Senha são obrigatórios.");
                return View(new UsuarioDto { Nome = nome, Email = email });
            }

            DateTime dataNascimento = DateTime.MinValue;
            if (!string.IsNullOrWhiteSpace(dataNascimentoRaw))
                DateTime.TryParse(dataNascimentoRaw, out dataNascimento);

            int tipoUsuarioId = 3;
            if (!string.IsNullOrWhiteSpace(tipoUsuarioIdRaw))
                int.TryParse(tipoUsuarioIdRaw, out tipoUsuarioId);

            var usuario = new Usuario
            {
                Nome = nome,
                Email = email,
                Senha = senha,
                DataNascimento = dataNascimento == DateTime.MinValue ? DateTime.UtcNow : dataNascimento,
                TipoUsuarioId = tipoUsuarioId
            };

            MemoryStream? ms = null;
            try
            {
                if (FotoPerfil != null && FotoPerfil.Length > 0)
                {
                    ms = new MemoryStream();
                    await FotoPerfil.CopyToAsync(ms);
                    ms.Position = 0;
                }

                var resp = await _usuarioApi.RegisterAsync(usuario, ms, FotoPerfil?.FileName);

                if (resp.IsSuccessStatusCode)
                    return RedirectToAction(nameof(Index));

                ModelState.AddModelError("", $"Erro ao criar aluno. Código: {resp.StatusCode}");
                return View(new UsuarioDto { Nome = usuario.Nome, Email = usuario.Email, DataNascimento = usuario.DataNascimento, TipoUsuarioId = usuario.TipoUsuarioId });
            }
            finally
            {
                ms?.Dispose();
            }
        }

        // GET: /Aluno/Details/{id}
        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var u = await _usuarioApi.GetByIdAsync(id);
            if (u == null) return NotFound();

            var dto = new UsuarioDto
            {
                IdUsuario = u.IdUsuario,
                Nome = u.Nome,
                Email = u.Email,
                DataNascimento = u.DataNascimento,
                Imagem = u.FotoPerfil,
                TipoUsuarioId = u.TipoUsuarioId,
                TipoUsuarioDescricao = u.TipoUsuario?.DescricaoTipoUsuario ?? "Aluno"
            };

            return View(dto);
        }

        // GET: /Aluno/Edit/{id}
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var u = await _usuarioApi.GetByIdAsync(id);
            if (u == null) return NotFound();

            var dto = new UsuarioDto
            {
                IdUsuario = u.IdUsuario,
                Nome = u.Nome,
                Email = u.Email,
                DataNascimento = u.DataNascimento,
                Imagem = u.FotoPerfil,
                TipoUsuarioId = u.TipoUsuarioId,
                TipoUsuarioDescricao = u.TipoUsuario?.DescricaoTipoUsuario ?? "Aluno"
            };

            return View(dto);
        }

        // POST: /Aluno/Edit/{id}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, IFormCollection form, IFormFile? FotoPerfil)
        {
            var nome = form["Nome"].ToString();
            var email = form["Email"].ToString();
            var senha = form["Senha"].ToString();
            var dataNascimentoRaw = form["DataNascimento"].ToString();
            DateTime.TryParse(dataNascimentoRaw, out var dataNascimento);

            var usuario = new Usuario
            {
                IdUsuario = id,
                Nome = nome,
                Email = email,
                Senha = senha,
                DataNascimento = dataNascimento,
                // manter TipoUsuarioId vindo do form ou forçar 3
                TipoUsuarioId = int.TryParse(form["TipoUsuarioId"].ToString(), out var t) ? t : 3
            };

            MemoryStream? ms = null;
            try
            {
                if (FotoPerfil != null && FotoPerfil.Length > 0)
                {
                    ms = new MemoryStream();
                    await FotoPerfil.CopyToAsync(ms);
                    ms.Position = 0;
                }

                var resp = await _usuarioApi.UpdateAsync(id, usuario, ms, FotoPerfil?.FileName);

                if (resp.IsSuccessStatusCode || resp.StatusCode == System.Net.HttpStatusCode.NoContent)
                    return RedirectToAction(nameof(Index));

                ModelState.AddModelError("", $"Erro ao atualizar aluno. Código: {resp.StatusCode}");
                return View(new UsuarioDto { IdUsuario = id, Nome = nome, Email = email, DataNascimento = dataNascimento, TipoUsuarioId = usuario.TipoUsuarioId });
            }
            finally
            {
                ms?.Dispose();
            }
        }

        // GET: /Aluno/Delete/{id}
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var u = await _usuarioApi.GetByIdAsync(id);
            if (u == null) return NotFound();

            var dto = new UsuarioDto
            {
                IdUsuario = u.IdUsuario,
                Nome = u.Nome,
                Email = u.Email,
                DataNascimento = u.DataNascimento,
                Imagem = u.FotoPerfil,
                TipoUsuarioId = u.TipoUsuarioId,
                TipoUsuarioDescricao = u.TipoUsuario?.DescricaoTipoUsuario ?? "Aluno"
            };

            return View(dto);
        }

        // POST: /Aluno/Delete/{id}
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var resp = await _usuarioApi.DeleteAsync(id);
            if (!resp.IsSuccessStatusCode)
            {
                TempData["Error"] = "Erro ao deletar aluno.";
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
