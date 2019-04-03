using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication4.Models.Entities
{
    public class Portao : Base
    {
        public int PortaoId { get; set; }
        public string Estado { get; set; }


        public string TipoEstado(string valor)
        {
            if (valor == "1")
            {
                return "Abrir Portao";
            }
            else
            {
                return "Fechar Portao";
            }

        }
        
    }
}