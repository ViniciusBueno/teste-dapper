using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TestesDapper.Models;
using TestesDapper.Repositories;

namespace TestesDapper.Services
{
    public class ProdutoService
    {
        ProdutoRepository produtoRepository;

        public ProdutoService()
        {
            produtoRepository = new ProdutoRepository();
        }

        public List<Produto> Listar(Produto produto)
        {
            return produtoRepository.Listar(produto);
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