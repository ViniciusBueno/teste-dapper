using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Dapper;
using System.Data.SqlClient;
using System.Configuration;
using TestesDapper.Models;
using System.Text;

namespace TestesDapper.Repositories
{
    public class TipoProdutoRepository
    {
        SqlConnection con = new SqlConnection(TestesDapper.Util.Util.BuscaStringConexaoBanco());

        public List<TipoProduto> Listar(TipoProduto tipoProduto)
        {
            var sqlCommand = new StringBuilder();
            sqlCommand.Append(" SELECT");
            sqlCommand.Append("     Id,");
            sqlCommand.Append("     Nome,");
            sqlCommand.Append("     Descricao");
            sqlCommand.Append(" FROM");
            sqlCommand.Append("     TipoProduto");

            var TipoProdutos = con.Query<TipoProduto>(sqlCommand.ToString());

            return TipoProdutos.ToList();
        }
    }
}