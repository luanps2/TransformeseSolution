using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Transformese.Domain.Entities;
using Transformese.MVC.Services;

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

        public async Task<IActionResult> Index()
        {
            var usuarios = await _usuarioApi.GetAllAsync();
            var profs = usuarios?.Where(u => u.TipoUsuarioId == 2) ?? Enumerable.Empty<Usuario>();
            return View(profs);
        }

        public async Task<IActionResult> Details(int id)
        {
            var u = await _usuarioApi.GetByIdAsync(id);
            if (u == null) return NotFound();
            return View(u);
        }

        [HttpGet]
        public IActionResult Create() => View();

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

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var u = await _usuarioApi.GetByIdAsync(id);
            if (u == null) return NotFound();
            return View(u);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, Usuario model, IFormFile? FotoPerfil)
        {
            if (!ModelState.IsValid) return View(model);

            Stream? ms = null;
            if (FotoPerfil != null && FotoPerfil.Length > 0) ms = FotoPerfil.OpenReadStream();

            var resp = await _usuarioApi.UpdateAsync(id, model, ms, FotoPerfil?.FileName);
            ms?.Dispose();

            if (!resp.IsSuccessStatusCode)
            {
                ModelState.AddModelError("", "Erro ao atualizar professor.");
                return View(model);
            }

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var resp = await _usuarioApi.DeleteAsync(id);
            if (!resp.IsSuccessStatusCode) TempData["Error"] = "Erro ao deletar.";
            return RedirectToAction(nameof(Index));
        }
    }
}
