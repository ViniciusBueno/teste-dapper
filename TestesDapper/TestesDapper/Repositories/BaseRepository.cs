using System.Configuration;
using System.Data.SqlClient;

namespace TestesDapper.Repositories
{
    public abstract class BaseRepository
    {
        public static SqlConnection BuscaObjetoConexaoBanco()
        {
            return new SqlConnection(BuscaStringConexaoBanco());
        }

        private static string BuscaStringConexaoBanco()
        {
            return ConfigurationManager.ConnectionStrings["LojaVirtual"].ToString();
        }
    }
}