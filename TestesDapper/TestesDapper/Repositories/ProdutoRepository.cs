using Dapper;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using TestesDapper.Models;

namespace TestesDapper.Repositories
{
    public class ProdutoRepository : BaseRepository
    {
        public List<Produto> Listar(Produto produto)
        {
            var sqlCommand = new StringBuilder();
            sqlCommand.Append(" SELECT");
            sqlCommand.Append("     Id,");
            sqlCommand.Append("     Nome,");
            sqlCommand.Append("     Descricao,");
            sqlCommand.Append("     Valor,");
            sqlCommand.Append("     IdTipoProduto");
            sqlCommand.Append(" FROM");
            sqlCommand.Append("     Produto");

            if (!string.IsNullOrEmpty(produto.Nome))
            {
                sqlCommand.Append(" WHERE");
                sqlCommand.Append("     Nome like '%' + @Nome + '%'");
            }

            sqlCommand.Append(" ORDER BY");
            sqlCommand.Append("     p.Nome");

            using (var connection = BuscaObjetoConexaoBanco())
            {
                var produtos = connection.Query<Produto>(sqlCommand.ToString(), produto);

                return produtos.ToList();
            }
        }

        public List<Produto> ListarComRelacionamentosDeFilhos(Produto produto)
        {

            var sqlCommand = new StringBuilder();
            sqlCommand.Append(" SELECT");
            sqlCommand.Append("     p.Id,");
            sqlCommand.Append("     p.Nome,");
            sqlCommand.Append("     p.Descricao,");
            sqlCommand.Append("     p.Valor,");
            sqlCommand.Append("     p.IdTipoProduto,");
            sqlCommand.Append("     tp.Id,");
            sqlCommand.Append("     tp.Nome,");
            sqlCommand.Append("     tp.Descricao");
            sqlCommand.Append(" FROM");
            sqlCommand.Append("     Produto p");
            sqlCommand.Append(" INNER JOIN");
            sqlCommand.Append("     TipoProduto tp ON tp.Id = p.IdTipoProduto");

            if (!string.IsNullOrEmpty(produto.Nome))
            {
                sqlCommand.Append(" WHERE");
                sqlCommand.Append("     p.Nome like '%' + @Nome + '%'");
            }

            sqlCommand.Append(" ORDER BY");
            sqlCommand.Append("     p.Nome");

            using (var connection = BuscaObjetoConexaoBanco())
            {
                // Se as chaves forem diferentes de Id, que é o valor default que o Dapper assume,
                // usar splitOn para informar a coluna.
                var produtos =
                    connection.Query<Produto, TipoProduto, Produto>(
                            sqlCommand.ToString(),
                            (p, tp) => { p.TipoProduto = tp; return p; },
                            splitOn: "IdTipoProduto",
                            param: produto);

                return produtos.ToList();
            }
        }

        public Produto Buscar(Produto produto)
        {
            var sqlCommand = new StringBuilder();
            sqlCommand.Append(" SELECT");
            sqlCommand.Append("     Id,");
            sqlCommand.Append("     Nome,");
            sqlCommand.Append("     Descricao,");
            sqlCommand.Append("     Valor,");
            sqlCommand.Append("     IdTipoProduto");
            sqlCommand.Append(" FROM");
            sqlCommand.Append("     Produto");
            sqlCommand.Append(" WHERE");
            sqlCommand.Append("     Id = @Id");

            using (var connection = BuscaObjetoConexaoBanco())
            {
                var produtoBuscado = connection.Query<Produto>(sqlCommand.ToString(), produto).FirstOrDefault();

                return produtoBuscado;
            }
        }

        public void Incluir(Produto produto)
        {
            var sqlCommand = new StringBuilder();
            sqlCommand.Append(" INSERT INTO");
            sqlCommand.Append("     Produto");
            sqlCommand.Append("     (");
            sqlCommand.Append("         Nome,");
            sqlCommand.Append("         Descricao,");
            sqlCommand.Append("         Valor,");
            sqlCommand.Append("         IdTipoProduto");
            sqlCommand.Append("     )");
            sqlCommand.Append(" VALUES");
            sqlCommand.Append("     (");
            sqlCommand.Append("         @Nome,");
            sqlCommand.Append("         @Descricao,");
            sqlCommand.Append("         @Valor,");
            sqlCommand.Append("         @IdTipoProduto");
            sqlCommand.Append("     )");

            using (var connection = BuscaObjetoConexaoBanco())
            {
                connection.Execute(sqlCommand.ToString(), produto);
            }
        }

        public void Editar(Produto produto)
        {
            var sqlCommand = new StringBuilder();
            sqlCommand.Append(" UPDATE");
            sqlCommand.Append("     Produto");
            sqlCommand.Append(" SET");
            sqlCommand.Append("     Nome = @Nome,");
            sqlCommand.Append("     Descricao = @Descricao,");
            sqlCommand.Append("     Valor = @Valor,");
            sqlCommand.Append("     IdTipoProduto = @IdTipoProduto");
            sqlCommand.Append(" WHERE");
            sqlCommand.Append("     Id = @Id");

            using (var connection = BuscaObjetoConexaoBanco())
            {
                connection.Execute(sqlCommand.ToString(), produto);
            }
        }

        public void Excluir(Produto produto)
        {
            var sqlCommand = new StringBuilder();
            sqlCommand.Append(" DELETE FROM");
            sqlCommand.Append("     Produto");
            sqlCommand.Append(" WHERE");
            sqlCommand.Append("     Id = @Id");

            using (var connection = BuscaObjetoConexaoBanco())
            {
                connection.Execute(sqlCommand.ToString(), produto);
            }
        }
    }
}