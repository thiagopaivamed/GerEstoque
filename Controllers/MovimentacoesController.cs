using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace GerEstoque.Controllers
{
    public class MovimentacoesController : Controller
    {
        private readonly Contexto _contexto;

        public MovimentacoesController(Contexto contexto)
        {
            _contexto = contexto;
        }

        [HttpGet]
        public async Task<IActionResult> NovaMovimentacao(int produtoId)
        {
            Movimentacao movimentacao = new Movimentacao 
            { ProdutoId = produtoId };

            return View(movimentacao);
        }

        [HttpPost]        
        public async Task<IActionResult> NovaMovimentacao(Movimentacao movimentacao)
        {
            movimentacao.DataMovimentacao = DateTime.Now.ToString();

            if(ModelState.IsValid)
            {
                await _contexto.Movimentacoes.AddAsync(movimentacao);
                await _contexto.SaveChangesAsync();
                return RedirectToAction("DetalhesProduto", "Produtos", new { produtoId = movimentacao.ProdutoId });
            }

            return View(movimentacao);
        }

        [HttpGet]
        public async Task<IActionResult> AtualizarMovimentacao(int movimentacaoId)
        {
            Movimentacao movimentacao = await _contexto.Movimentacoes.FindAsync(movimentacaoId);
            return View(movimentacao);
        }

        [HttpPost]
        public async Task<IActionResult> AtualizarMovimentacao(Movimentacao movimentacao)
        {
            if(ModelState.IsValid)
            {
                _contexto.Movimentacoes.Update(movimentacao);
                await _contexto.SaveChangesAsync();
                return RedirectToAction("DetalhesProduto", "Produtos", new { produtoId = movimentacao.ProdutoId });
            }

            return View(movimentacao);
        }

        [HttpPost]
        public async Task<IActionResult> ExcluirMovimentacao(int movimentacaoId)
        {
            Movimentacao movimentacao = await _contexto.Movimentacoes.FindAsync(movimentacaoId);
            _contexto.Movimentacoes.Remove(movimentacao);
            await _contexto.SaveChangesAsync();
            return RedirectToAction("DetalhesProduto", "Produtos", new { produtoId = movimentacao.ProdutoId });
        }
    }
}