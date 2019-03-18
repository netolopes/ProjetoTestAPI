using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication4.Models._1_M
{
    public class Grade
    {

        //RELACIONAMENTO 1 TO N - STUDENT X GRADE
      
                public Grade()
                {
                    Students = new List<Student>();
                }
        
                public int GradeId { get; set; }
                public string GradeName { get; set; }
                //usar sempre esse padrao virtual e "s" no nome do array
                public virtual ICollection<Student> Students { get; set; }
             
    }
}