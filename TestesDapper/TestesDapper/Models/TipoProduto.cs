using System.ComponentModel;

namespace TestesDapper.Models
{
    [DisplayName("Tipo Produto: ")]
    public class TipoProduto : BaseModel
    {
        public string Descricao { get; set; }
    }
}