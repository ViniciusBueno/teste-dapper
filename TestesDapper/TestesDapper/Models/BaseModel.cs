using System.ComponentModel;

namespace TestesDapper.Models
{
    public abstract class BaseModel
    {
        public int? Id { get; set; }
        
        [DisplayName("Nome: ")]
        public string Nome { get; set; }
    }
}