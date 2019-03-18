using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebApplication4.Models.M_M
{
    public class UsuarioCurso
    {
        [Key]
        public int UsuarioCursoId { get; set; }

       
        public int UsuarioId { get; set; }

       
        public int CursoId { get; set; }

        public virtual Usuario Usuario { get; set; }
        public virtual Curso Curso { get; set; }
    }
}