using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestesDapper.Models.Filters
{
    public class ProdutoFilter
    {
        public Produto Produto { get; set; }
        public List<Produto> Produtos { get; set; }

        public ProdutoFilter()
        {
            Produto = new Produto();
            Produtos = new List<Produto>();
        }
    }
}