using System.Collections.Generic;

namespace TestesDapper.Models.Filters
{
    public class ProdutoFilter
    {
        public Produto Produto { get; set; }

        public List<Produto> Produtos { get; set; }

        public List<TipoProduto> TipoProdutos { get; set; }

        public ProdutoFilter()
        {
            Produto = new Produto();
            Produtos = new List<Produto>();
            TipoProdutos = new List<TipoProduto>();
        }
    }
}