using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models;

namespace ViewComponents
{
    public class MovimentacoesViewComponent : ViewComponent
    {
        private readonly Contexto _contexto;

        public MovimentacoesViewComponent(Contexto contexto)
        {
            _contexto = contexto;
        }

        public async Task<IViewComponentResult> InvokeAsync(int produtoId)
        {
            return View(await _contexto.Movimentacoes.Where(m => m.ProdutoId == produtoId).ToListAsync());
        }
    }
}