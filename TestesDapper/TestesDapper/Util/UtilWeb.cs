using System.Collections.Generic;
using System.Web.Mvc;
using TestesDapper.Models;

namespace TestesDapper.Util
{
    public static class UtilWeb
    {
        public static List<SelectListItem> MontaLista(List<BaseModel> elementos)
        {
            SelectListItem selectListItem;

            var listaItens = new List<SelectListItem>();

            foreach (var elemento in elementos)
            {
                selectListItem = new SelectListItem
                {
                    Text = elemento.Nome,
                    Value = elemento.Id.ToString()
                };

                listaItens.Add(selectListItem);
            }

            return listaItens;
        }
    }
}