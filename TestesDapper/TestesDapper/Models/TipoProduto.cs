using System.ComponentModel;

namespace TestesDapper.Models
{
    [DisplayName("Tipo Produto: ")]
    public class TipoProduto
    {
        public int? Id { get; set; }

        public string Nome { get; set; }

        public string Descricao { get; set; }
    }
}