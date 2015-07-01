using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TestesDapper.Models;
using Dapper;
using System.Data.SqlClient;
using System.Configuration;
using System.Text;

namespace TestesDapper.Repositories
{
    public class ProdutoRepository
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["LojaVirtualDB"].ToString());

        public List<Produto> Listar(Produto produto)
        {
            var sqlCommand = new StringBuilder();
            sqlCommand.Append(" SELECT");
            sqlCommand.Append("     Id,");
            sqlCommand.Append("     Nome,");
            sqlCommand.Append("     Descricao,");
            sqlCommand.Append("     Valor");
            sqlCommand.Append(" FROM");
            sqlCommand.Append("     Produto");

            if (!string.IsNullOrEmpty(produto.Nome))
            {
                sqlCommand.Append(" WHERE");
                sqlCommand.Append("     Nome like '%' + @Nome + '%'");
            }

            var produtos = con.Query<Produto>(sqlCommand.ToString(), produto);

            return produtos.ToList();
        }

        public Produto Buscar(Produto produto)
        {
            var sqlCommand = new StringBuilder();
            sqlCommand.Append(" SELECT");
            sqlCommand.Append("     Id,");
            sqlCommand.Append("     Nome,");
            sqlCommand.Append("     Descricao,");
            sqlCommand.Append("     Valor");
            sqlCommand.Append(" FROM");
            sqlCommand.Append("     Produto");
            sqlCommand.Append(" WHERE");
            sqlCommand.Append("     Id = @Id");

            var produtoBuscado = con.Query<Produto>(sqlCommand.ToString(), produto).FirstOrDefault();

            return produtoBuscado;
        }

        public void Incluir(Produto produto)
        {
            var sqlCommand = new StringBuilder();
            sqlCommand.Append(" INSERT INTO");
            sqlCommand.Append("     Produto (Nome, Descricao, Valor)");
            sqlCommand.Append(" VALUES");
            sqlCommand.Append("     (@Nome, @Descricao, @Valor)");

            con.Execute(sqlCommand.ToString(), produto);
        }

        public void Editar(Produto produto)
        {
            var sqlCommand = new StringBuilder();
            sqlCommand.Append(" UPDATE");
            sqlCommand.Append("     Produto");
            sqlCommand.Append(" SET");
            sqlCommand.Append("     Nome = @Nome,");
            sqlCommand.Append("     Descricao = @Descricao,");
            sqlCommand.Append("     Valor = @Valor");
            sqlCommand.Append(" WHERE");
            sqlCommand.Append("     Id = @Id");

            con.Execute(sqlCommand.ToString(), produto);
        }

        public void Excluir(Produto produto)
        {
            var sqlCommand = new StringBuilder();
            sqlCommand.Append(" DELETE FROM");
            sqlCommand.Append("     Produto");
            sqlCommand.Append(" WHERE");
            sqlCommand.Append("     Id = @Id");

            con.Execute(sqlCommand.ToString(), produto);
        }
    }
}