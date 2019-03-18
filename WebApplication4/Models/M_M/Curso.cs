using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication4.Models.M_M
{
    public class Curso
    {
        public Curso()
        {
           this.UsuarioCursos = new HashSet<UsuarioCurso>();
        }
        
       
        public  int CursoId { get; set; }
        public string Descricao { get; set; }

        //colocando o dessa forma, no ctrl  cm listagem de curso e na index tem q fazer 
        //foreach dentro de outro foreach pra pegar os dados de USUARIO E CURSO
         public virtual ICollection<UsuarioCurso> UsuarioCursos { get; set; }

    }
}