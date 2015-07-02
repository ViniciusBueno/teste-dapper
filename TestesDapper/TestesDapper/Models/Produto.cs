using System.ComponentModel;

namespace TestesDapper.Models
{
    public class Produto : BaseModel
    {
        [DisplayName("Descrição: ")]
        public string Descricao { get; set; }

        [DisplayName("Valor: ")]
        public double? Valor { get; set; }

        public int IdTipoProduto { get; set; }

        public TipoProduto TipoProduto { get; set; }

        public Produto()
        {
            TipoProduto = new TipoProduto();
        }
    }
}