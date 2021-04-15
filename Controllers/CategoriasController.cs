using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models;

namespace GerEstoque.Controllers {
    public class CategoriasController : Controller {
        private readonly Contexto _contexto;

        public CategoriasController (Contexto contexto) {
            _contexto = contexto;
        }

        public async Task<IActionResult> Index () {
            return View (await _contexto.Categorias.ToListAsync ());
        }

        [HttpGet]
        public IActionResult NovaCategoria () {
            return View ();
        }

        [HttpPost]
        public async Task<IActionResult> NovaCategoria (Categoria categoria) 
        {
            if (ModelState.IsValid) 
            {
                await _contexto.Categorias.AddAsync(categoria);
                await _contexto.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(categoria);
        }

        [HttpGet]
        public async Task<IActionResult> AtualizarCategoria(int categoriaId)
        {
            return View(await _contexto.Categorias.FindAsync(categoriaId));
        }

        [HttpPost]
        public async Task<IActionResult> AtualizarCategoria(Categoria categoria)
        {
            if(ModelState.IsValid)
            {
                _contexto.Categorias.Update(categoria);
                await _contexto.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(categoria);
        }

        [HttpPost]
        public async Task<IActionResult> ExcluirCategoria(int categoriaId)
        {
            Categoria categoria = await _contexto.Categorias.FindAsync(categoriaId);
            _contexto.Categorias.Remove(categoria);
            await _contexto.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

    }
}