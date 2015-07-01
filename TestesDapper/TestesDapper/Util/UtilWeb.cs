using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestesDapper.Models;

namespace TestesDapper.Util
{
    public static class UtilWeb
    {
        public static List<SelectListItem> MontaLista(List<TipoProduto> elementos)
        {
            var listaItens = new List<SelectListItem>();

            foreach (var elemento in elementos)
            {
                listaItens.Add(new SelectListItem { Text = elemento.Nome, Value = elemento.Id.ToString() });
            }

            return listaItens;
        }
    }
}