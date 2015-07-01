﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace TestesDapper.Util
{
    public static class Util
    {
        public const string indicadorDeTruncamentoDeTexto = "...";

        public static string BuscaStringConexaoBanco()
        {
            return ConfigurationManager.ConnectionStrings["LojaVirtual"].ToString();
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

        private static string AdicionaIndicadorDeTruncamentoDeTexto(string texto)
        {
            return texto + indicadorDeTruncamentoDeTexto;
        }
    }
}