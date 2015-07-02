using System.Web.Mvc;
using TestesDapper.Models;
using TestesDapper.Models.Filters;
using TestesDapper.Services;

namespace TestesDapper.Controllers
{
    public class ProdutoController : Controller
    {
        ProdutoService produtoService = new ProdutoService();
        TipoProdutoService tipoProdutoService = new TipoProdutoService();

        public ActionResult Listar()
        {
            var produtoFilter = new ProdutoFilter();

            var produtos = produtoService.ListarComRelacionamentosDeFilhos(produtoFilter.Produto);

            produtoFilter.Produtos = produtos;

            return View(produtoFilter);
        }

        [HttpPost]
        public ActionResult Listar(ProdutoFilter produtoFilter)
        {
            var produtos = produtoService.ListarComRelacionamentosDeFilhos(produtoFilter.Produto);

            produtoFilter.Produtos = produtos;

            return View(produtoFilter);
        }

        public ActionResult Incluir()
        {
            var produtoFilter = new ProdutoFilter
            {
                TipoProdutos = tipoProdutoService.Listar(new TipoProduto())
            };

            return View("Editar", produtoFilter);
        }

        [HttpPost]
        public ActionResult Incluir(ProdutoFilter produtoFilter)
        {
            produtoService.Incluir(produtoFilter.Produto);

            return RedirectToAction("Listar");
        }

        public ActionResult Editar(int id)
        {
            var produto = new Produto
            {
                Id = id
            };

            var produtoFilter = new ProdutoFilter
            {
                Produto = produtoService.Buscar(produto),
                TipoProdutos = tipoProdutoService.Listar(new TipoProduto())
            };

            return View(produtoFilter);
        }

        [HttpPost]
        public ActionResult Editar(ProdutoFilter produtoFilter)
        {
            produtoService.Editar(produtoFilter.Produto);

            return RedirectToAction("Listar");
        }

        public ActionResult Excluir(int id)
        {
            var produto = new Produto
            {
                Id = id
            };

            produtoService.Excluir(produto);

            return RedirectToAction("Listar");
        }
    }
}
