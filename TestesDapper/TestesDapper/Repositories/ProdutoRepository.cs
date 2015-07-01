﻿using System;
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
        SqlConnection con = new SqlConnection(TestesDapper.Util.Util.BuscaStringConexaoBanco());

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

            var produtos = con.Query<Produto>(sqlCommand.ToString(), produto);

            return produtos.ToList();
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
            sqlCommand.Append("     tp.Id");
            sqlCommand.Append("     tp.Nome");
            sqlCommand.Append("     tp.Descricao");
            sqlCommand.Append(" FROM");
            sqlCommand.Append("     Produto p");
            sqlCommand.Append(" INNER JOIN");
            sqlCommand.Append("     TipoProduto tp on tp.Id = p.IdTipoProduto");

            // Se as chaves forem diferentes de Id, que é o valor default que o Dapper assume,
            // usar splitOn para informar a coluna.
            var produtos =
                con.Query<Produto, TipoProduto, Produto>(
                        sqlCommand.ToString(),
                        (p, tp) => { p.TipoProduto = tp; return p; },
                        splitOn: "IdTipoProduto");

            return produtos.ToList();
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

            var produtoBuscado = con.Query<Produto>(sqlCommand.ToString(), produto).FirstOrDefault();

            return produtoBuscado;
        }

        public void Incluir(Produto produto)
        {
            var sqlCommand = new StringBuilder();
            sqlCommand.Append(" INSERT INTO");
            sqlCommand.Append("     Produto (Nome, Descricao, Valor, IdTipoProduto)");
            sqlCommand.Append(" VALUES");
            sqlCommand.Append("     (@Nome, @Descricao, @Valor, @IdTipoProduto)");

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
            sqlCommand.Append("     Valor = @Valor,");
            sqlCommand.Append("     IdTipoProduto = @IdTipoProduto");
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