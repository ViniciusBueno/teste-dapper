using System.Collections.Generic;
using TestesDapper.Models;
using TestesDapper.Repositories;

namespace TestesDapper.Services
{
    public class ProdutoService
    {
        ProdutoRepository produtoRepository = new ProdutoRepository();

        //public List<Produto> Listar(Produto produto)
        //{
        //    return produtoRepository.Listar(produto);
        //}

        public List<Produto> ListarComRelacionamentosDeFilhos(Produto produto)
        {
            return produtoRepository.ListarComRelacionamentosDeFilhos(produto);
        }

        public Produto Buscar(Produto produto)
        {
            return produtoRepository.Buscar(produto);
        }

        public void Incluir(Produto produto)
        {
            produtoRepository.Incluir(produto);
        }

        public void Editar(Produto produto)
        {
            produtoRepository.Editar(produto);
        }

        public void Excluir(Produto produto)
        {
            produtoRepository.Excluir(produto);
        }
    }
}