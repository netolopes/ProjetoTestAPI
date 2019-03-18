using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication4.Models.M_M
{
    public class Usuario
    {
        //RELACIONAMENTO N TO N - USUARIO X CURSO

        public Usuario()
        {
            this.UsuarioCursos = new HashSet<UsuarioCurso>();
        }

      
        public  int UsuarioId { get; set; }
        public string Name { get; set; }

        //colocando o dessa forma, no ctrl  cm listagem de usuario e na index tem q fazer 
        //foreach dentro de outro foreach pra pegar os dados de  USUARIO e CURSO
        public virtual ICollection<UsuarioCurso> UsuarioCursos { get; set; }
        
    }
}