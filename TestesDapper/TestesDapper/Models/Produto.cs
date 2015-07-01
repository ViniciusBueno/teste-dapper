using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TestesDapper.Models
{
    public class Produto
    {
        public int? Id { get; set; }

        [DisplayName("Nome: ")]
        public string Nome { get; set; }

        [DisplayName("Descrição: ")]
        public string Descricao { get; set; }

        [DisplayName("Valor: ")]
        public double Valor { get; set; }
    }
}