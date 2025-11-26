using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using Transformese.Domain.Entities;
using Transformese.MVC.Services;
using Transformese.Api.DTOs;

namespace TransformeSeMVC.Web.Controllers
{
    public class CursoController : Controller
    {
        private readonly ICursoApiClient _api;
        private readonly IUnidadeApiClient _unidadeApi;

        public CursoController(ICursoApiClient api, IUnidadeApiClient unidadeApi)
        {
            _api = api;
            _unidadeApi = unidadeApi;
        }

        // LISTA
        public async Task<IActionResult> Index()
        {
            var cursos = await _api.GetAllAsync();

            if (cursos == null)
                throw new Exception("Erro: API retornou NULL para listagem de cursos.");

            return View(cursos);
        }

        // DETAILS
        public async Task<IActionResult> Details(int id)
        {
            var curso = await _api.GetByIdAsync(id);
            if (curso == null) return NotFound();

            return View(curso);
        }

        // MODAL (AJAX)
        [HttpGet]
        public async Task<IActionResult> DetalhesModal(int id)
        {
            var curso = await _api.GetByIdAsync(id);
            if (curso == null) return NotFound();

            var imagem = !string.IsNullOrEmpty(curso.Imagem)
                ? $"/images/cursos/{curso.Imagem}"
                : "/images/default-course.jpg";

            return Json(new
            {
                id = curso.IdCurso,
                titulo = curso.Nome,
                descricao = curso.Descricao,
                unidade = curso.UnidadeNome ?? "Não informada",
                imagem
            });
        }

        // CREATE
        [Authorize(Roles = "Administrador")]
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            // popula ViewBag.Unidades para a view
            var unidades = await _unidadeApi.GetAllAsync();
            var unidadesDto = (unidades ?? Enumerable.Empty<Unidade>())
                .Select(u => new UnidadeDto
                {
                    IdUnidade = u.IdUnidade,
                    Nome = u.Nome,
                    Endereco = u.Endereco
                })
                .ToList();

            ViewBag.Unidades = unidadesDto;
            return View();
        }

        [Authorize(Roles = "Administrador")]
        [HttpPost]
        public async Task<IActionResult> Create(Curso curso, IFormFile? arquivo)
        {
            Stream? stream = null;
            string? fileName = null;

            if (arquivo != null && arquivo.Length > 0)
            {
                stream = arquivo.OpenReadStream();
                fileName = arquivo.FileName;
            }

            var response = await _api.CreateAsync(curso, stream, fileName);

            if (!response.IsSuccessStatusCode)
            {
                // Re-popular ViewBag em caso de erro para reexibir a view corretamente
                var unidades = await _unidadeApi.GetAllAsync();
                ViewBag.Unidades = (unidades ?? Enumerable.Empty<Unidade>())
                    .Select(u => new UnidadeDto { IdUnidade = u.IdUnidade, Nome = u.Nome, Endereco = u.Endereco })
                    .ToList();

                return BadRequest("Erro ao criar curso.");
            }

            return RedirectToAction("Index");
        }

        // EDIT
        [Authorize(Roles = "Administrador")]
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var curso = await _api.GetByIdAsync(id);
            if (curso == null) return NotFound();

            // popula unidades para o select
            var unidades = await _unidadeApi.GetAllAsync();
            ViewBag.Unidades = (unidades ?? Enumerable.Empty<Unidade>())
                .Select(u => new UnidadeDto { IdUnidade = u.IdUnidade, Nome = u.Nome, Endereco = u.Endereco })
                .ToList();

            return View(curso);
        }

        [Authorize(Roles = "Administrador")]
        [HttpPost]
        public async Task<IActionResult> Edit(int id, Curso curso, IFormFile? arquivo)
        {
            Stream? stream = null;
            string? fileName = null;

            if (arquivo != null && arquivo.Length > 0)
            {
                stream = arquivo.OpenReadStream();
                fileName = arquivo.FileName;
            }

            var resp = await _api.UpdateAsync(id, curso, stream, fileName);

            if (!resp.IsSuccessStatusCode)
            {
                // Re-popular ViewBag em caso de erro para reexibir a view corretamente
                var unidades = await _unidadeApi.GetAllAsync();
                ViewBag.Unidades = (unidades ?? Enumerable.Empty<Unidade>())
                    .Select(u => new UnidadeDto { IdUnidade = u.IdUnidade, Nome = u.Nome, Endereco = u.Endereco })
                    .ToList();

                return BadRequest("Erro ao atualizar curso.");
            }

            return RedirectToAction("Index");
        }

        // DELETE
        [Authorize(Roles = "Administrador")]
        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _api.DeleteAsync(id);

            if (!result.IsSuccessStatusCode)
                return BadRequest("Erro ao excluir o curso.");

            return RedirectToAction(nameof(Index));
        }
    }
}
