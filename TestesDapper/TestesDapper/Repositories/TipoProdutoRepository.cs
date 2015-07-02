using Dapper;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using TestesDapper.Models;

namespace TestesDapper.Repositories
{
    public class TipoProdutoRepository
    {
        SqlConnection con = TestesDapper.Util.Util.BuscaObjetoConexaoBanco();

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