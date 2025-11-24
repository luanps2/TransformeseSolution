using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Transformese.MVC.Services;

namespace TransformeSeMVC.Web.Controllers
{
    public class CursoController : Controller
    {
        private readonly ICursoApiClient _api;

        public CursoController(ICursoApiClient api)
        {
            _api = api;
        }

        //// Lista (GET /Curso)
        //[HttpGet]
        //public async Task<IActionResult> Index()
        //{
        //    var cursos = await _api.GetAllAsync();
        //    return View(cursos);
        //}

        public async Task<IActionResult> Index()
        {
            var cursos = await _api.GetAllAsync();

            if (cursos == null)
                throw new Exception("O API Client retornou NULL. O problema está no consumo da API.");

            return View(cursos);
        }


        // Exibe detalhes do curso
        public async Task<IActionResult> Detalhes(int id)
        {
            var curso = await _api.GetByIdAsync(id);
            if (curso == null) return NotFound();
            return PartialView("_DetalhesCursoPartial", curso);
        }

        // Endpoint para exibir detalhes no modal (AJAX)
        [HttpGet]
        public async Task<IActionResult> DetalhesModal(int id)
        {
            var curso = await _api.GetByIdAsync(id);
            if (curso == null) return NotFound();

            var imagem = !string.IsNullOrEmpty(curso.Imagem) ? $"/images/cursos/{curso.Imagem}" : "/images/default-course.jpg";

            return Json(new
            {
                id = curso.IdCurso,
                titulo = curso.Nome,
                descricao = curso.Descricao,
                unidade = curso.UnidadeNome ?? "Não informada",
                imagem
            });
        }
    }
}
