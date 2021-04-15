using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Models;

namespace GerEstoque.Controllers
{
    public class ProdutosController : Controller
    {
        private readonly Contexto _contexto;

        public ProdutosController(Contexto contexto)
        {
            _contexto = contexto;
        }

        public async Task<IActionResult> Index(){
            return View(await _contexto.Produtos.Include(p => p.Categoria).ToListAsync());
        }

        [HttpGet]
        public async Task<IActionResult> NovoProduto(){
            ViewData["CategoriaId"] = new SelectList(await _contexto.Categorias.ToListAsync(), "CategoriaId", "Nome");
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> DetalhesProduto(int produtoId)
        {
            Produto produto = await _contexto.Produtos.Include(p => p.Categoria).FirstOrDefaultAsync(p => p.ProdutoId == produtoId);
            return View(produto);
        }

        [HttpPost]
        public async Task<IActionResult> NovoProduto(Produto produto)
        {
            if(ModelState.IsValid)
            {
                await _contexto.Produtos.AddAsync(produto);
                await _contexto.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            ViewData["CategoriaId"] = new SelectList(await _contexto.Categorias.ToListAsync(), "CategoriaId", "Nome", produto.CategoriaId);
            return View(produto);
        }

        [HttpGet]
        public async Task<IActionResult> AtualizarProduto(int produtoId)
        {
            Produto produto = await _contexto.Produtos.FindAsync(produtoId);

            ViewData["CategoriaId"] = new SelectList(await _contexto.Categorias.ToListAsync(), "CategoriaId", "Nome", produto.CategoriaId);
            return View(produto);
        }

        [HttpPost]       
        public async Task<IActionResult> AtualizarProduto(Produto produto)
        {
            if(ModelState.IsValid)
            {
                _contexto.Produtos.Update(produto);
                await _contexto.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

             ViewData["CategoriaId"] = new SelectList(await _contexto.Categorias.ToListAsync(), "CategoriaId", "Nome", produto.CategoriaId);
            return View(produto);
        }

        [HttpPost]
        public async Task<IActionResult> ExcluirProduto(int produtoId)
        {
            Produto produto = await _contexto.Produtos.FindAsync(produtoId);
            _contexto.Produtos.Remove(produto);
            await _contexto.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

    }
}