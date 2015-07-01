using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TestesDapper.Models;
using TestesDapper.Repositories;

namespace TestesDapper.Services
{
    public class TipoProdutoService
    {
        TipoProdutoRepository tipoProdutoRepository = new TipoProdutoRepository();

        public List<TipoProduto> Listar(TipoProduto tipoProduto)
        {
            return tipoProdutoRepository.Listar(tipoProduto);
        }
    }
}