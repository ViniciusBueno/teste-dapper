using System.Configuration;
using System.Data.SqlClient;

namespace TestesDapper.Util
{
    public static class Util
    {
        public const string indicadorDeTruncamentoDeTexto = "...";
        public const string stringDeConexaoComBancoDeDados = "LojaVirtual";

        public static SqlConnection BuscaObjetoConexaoBanco()
        {
            return new SqlConnection(BuscaStringConexaoBanco());
        }

        public static string TruncaTexto(string texto, int ultimaPosicaoParaMostrada = 50)
        {
            if (texto.Length < 51)
            {
                return texto;
            }

            var textoTruncado = texto.Substring(0, ultimaPosicaoParaMostrada);

            return AdicionaIndicadorDeTruncamentoDeTexto(textoTruncado);
        }

        #region "Métodos privados"

        private static string BuscaStringConexaoBanco()
        {
            return ConfigurationManager.ConnectionStrings[stringDeConexaoComBancoDeDados].ToString();
        }

        private static string AdicionaIndicadorDeTruncamentoDeTexto(string texto)
        {
            return texto + indicadorDeTruncamentoDeTexto;
        }

        #endregion
    }
}