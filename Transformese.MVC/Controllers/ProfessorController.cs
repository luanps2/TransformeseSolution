using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using Transformese.Domain.Entities;
using Transformese.MVC.Services;
using Transformese.Api.DTOs;

namespace TransformeSeMVC.Web.Controllers
{
    [Authorize(Roles = "Administrador")] // ajuste conforme sua regra
    public class ProfessorController : Controller
    {
        private readonly IUsuarioApiClient _usuarioApi;

        public ProfessorController(IUsuarioApiClient usuarioApi)
        {
            _usuarioApi = usuarioApi;
        }

        // GET: /Professor
        public async Task<IActionResult> Index()
        {
            var usuarios = await _usuarioApi.GetAllAsync();
            var profsDto = (usuarios ?? Enumerable.Empty<Usuario>())
                .Where(u => u.TipoUsuarioId == 2)
                .Select(u => new UsuarioDto
                {
                    IdUsuario = u.IdUsuario,
                    Nome = u.Nome,
                    Email = u.Email,
                    DataNascimento = u.DataNascimento,
                    Imagem = u.FotoPerfil,
                    TipoUsuarioId = u.TipoUsuarioId,
                    TipoUsuarioDescricao = u.TipoUsuario?.DescricaoTipoUsuario ?? "Professor"
                })
                .ToList();

            return View(profsDto);
        }

        // GET: /Professor/Details/{id}
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
                TipoUsuarioDescricao = u.TipoUsuario?.DescricaoTipoUsuario ?? "Professor"
            };

            return View(dto);
        }

        // GET: /Professor/Create
        [HttpGet]
        public IActionResult Create() => View();

        // POST: /Professor/Create
        [HttpPost]
        public async Task<IActionResult> Create(Usuario model, IFormFile? FotoPerfil)
        {
            if (!ModelState.IsValid) return View(model);

            model.TipoUsuarioId = 2; // Professor

            Stream? ms = null;
            if (FotoPerfil != null && FotoPerfil.Length > 0)
            {
                ms = FotoPerfil.OpenReadStream();
            }

            var resp = await _usuarioApi.RegisterAsync(model, ms, FotoPerfil?.FileName);
            ms?.Dispose();

            if (!resp.IsSuccessStatusCode)
            {
                ModelState.AddModelError("", "Erro ao criar professor.");
                return View(model);
            }

            return RedirectToAction(nameof(Index));
        }

        // GET: /Professor/Edit/{id}
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
                TipoUsuarioDescricao = u.TipoUsuario?.DescricaoTipoUsuario ?? "Professor"
            };

            return View(dto);
        }

        // POST: /Professor/Edit/{id}
        [HttpPost]
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
                TipoUsuarioId = 2
            };

            Stream? ms = null;
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

                ModelState.AddModelError("", $"Erro ao atualizar professor. Código: {resp.StatusCode}");
                return View(new UsuarioDto { IdUsuario = id, Nome = nome, Email = email, DataNascimento = dataNascimento, TipoUsuarioId = usuario.TipoUsuarioId });
            }
            finally
            {
                ms?.Dispose();
            }
        }

        // POST: /Professor/Delete/{id}
        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var resp = await _usuarioApi.DeleteAsync(id);
            if (!resp.IsSuccessStatusCode) TempData["Error"] = "Erro ao deletar.";
            return RedirectToAction(nameof(Index));
        }
    }
}
