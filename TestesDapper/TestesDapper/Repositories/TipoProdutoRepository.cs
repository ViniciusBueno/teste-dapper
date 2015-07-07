using Dapper;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestesDapper.Models;

namespace TestesDapper.Repositories
{
    public class TipoProdutoRepository : BaseRepository
    {
        public List<TipoProduto> Listar(TipoProduto tipoProduto)
        {
            var sqlCommand = new StringBuilder();
            sqlCommand.Append(" SELECT");
            sqlCommand.Append("     Id,");
            sqlCommand.Append("     Nome,");
            sqlCommand.Append("     Descricao");
            sqlCommand.Append(" FROM");
            sqlCommand.Append("     TipoProduto");

            using (var connection = BuscaObjetoConexaoBanco())
            {
                var TipoProdutos = connection.Query<TipoProduto>(sqlCommand.ToString());

                return TipoProdutos.ToList();
            }
        }
    }
}