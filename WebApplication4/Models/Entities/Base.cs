using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication4.Models.Entities
{
    public  class Base
    {
        public string Ip { get; set; }
        public string Mac { get; set; }

        public string Status { get; set; }

        
        public string LigaDesliga(string valor)
        {
            if (valor == "1")
            {
                return "Ligado";
            }
            else
            {
                return "Desligado";
            }
        }
       
      
       
    }
}