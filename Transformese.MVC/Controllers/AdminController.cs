using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using Transformese.MVC.Services;
using Transformese.Domain.Entities;
using Transformese.Api.DTOs;

namespace TransformeSeMVC.Web.Controllers
{
    [Authorize(Roles = "Administrador")]
    public class AdminController : Controller
    {
        private readonly IUsuarioApiClient _usuarioApi;

        public AdminController(IUsuarioApiClient usuarioApi)
        {
            _usuarioApi = usuarioApi;
        }

        // GET: /Admin
        public async Task<IActionResult> Index()
        {
            var usuarios = await _usuarioApi.GetAllAsync(); // IEnumerable<Usuario>
            var admins = (usuarios ?? Enumerable.Empty<Usuario>())
                .Where(u => u.TipoUsuarioId == 1)
                .Select(u => new UsuarioDto
                {
                    IdUsuario = u.IdUsuario,
                    Nome = u.Nome,
                    Email = u.Email,
                    DataNascimento = u.DataNascimento,
                    Imagem = u.FotoPerfil,
                    TipoUsuarioId = u.TipoUsuarioId,
                    TipoUsuarioDescricao = u.TipoUsuario?.DescricaoTipoUsuario ?? "Administrador"
                })
                .ToList();

            return View(admins);
        }

        // GET: /Admin/Create
        [HttpGet]
        public IActionResult Create()
        {
            return View(new UsuarioDto());
        }

        // POST: /Admin/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(IFormCollection form, IFormFile? FotoPerfil)
        {
            var nome = form["Nome"].ToString();
            var email = form["Email"].ToString();
            var senha = form["Senha"].ToString();
            DateTime.TryParse(form["DataNascimento"].ToString(), out var dataNascimento);

            if (string.IsNullOrWhiteSpace(nome) || string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(senha))
            {
                ModelState.AddModelError("", "Nome, Email e Senha são obrigatórios.");
                return View(new UsuarioDto { Nome = nome, Email = email });
            }

            var usuario = new Usuario
            {
                Nome = nome,
                Email = email,
                Senha = senha,
                DataNascimento = dataNascimento == default ? DateTime.UtcNow : dataNascimento,
                TipoUsuarioId = 1 // Administrador
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

                ModelState.AddModelError("", $"Erro ao criar administrador. Código: {resp.StatusCode}");
                return View(new UsuarioDto { Nome = usuario.Nome, Email = usuario.Email, DataNascimento = usuario.DataNascimento });
            }
            finally
            {
                ms?.Dispose();
            }
        }

        // GET: /Admin/Details/{id}
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
                TipoUsuarioDescricao = u.TipoUsuario?.DescricaoTipoUsuario ?? "Administrador"
            };

            return View(dto);
        }

        // GET: /Admin/Edit/{id}
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
                TipoUsuarioDescricao = u.TipoUsuario?.DescricaoTipoUsuario ?? "Administrador"
            };

            return View(dto);
        }

        // POST: /Admin/Edit/{id}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, IFormCollection form, IFormFile? FotoPerfil)
        {
            var nome = form["Nome"].ToString();
            var email = form["Email"].ToString();
            var senha = form["Senha"].ToString();
            DateTime.TryParse(form["DataNascimento"].ToString(), out var dataNascimento);

            var usuario = new Usuario
            {
                IdUsuario = id,
                Nome = nome,
                Email = email,
                Senha = senha,
                DataNascimento = dataNascimento,
                TipoUsuarioId = 1
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

                ModelState.AddModelError("", $"Erro ao atualizar administrador. Código: {resp.StatusCode}");
                return View(new UsuarioDto { IdUsuario = id, Nome = nome, Email = email, DataNascimento = dataNascimento });
            }
            finally
            {
                ms?.Dispose();
            }
        }

        // GET: /Admin/Delete/{id}
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
                TipoUsuarioDescricao = u.TipoUsuario?.DescricaoTipoUsuario ?? "Administrador"
            };

            return View(dto);
        }

        // POST: /Admin/Delete/{id}
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var resp = await _usuarioApi.DeleteAsync(id);
            if (!resp.IsSuccessStatusCode)
            {
                TempData["Error"] = "Erro ao deletar administrador.";
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
