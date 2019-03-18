using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebApplication4.Models._1_M
{
    public class Student
    {
        //RELACIONAMENTO 1 TO N  - STUDENT X GRADE

                public int Id { get; set; }
                public string Name { get; set; }
                public int GradeId { get; set; }
                //nao esquecer virtual para fazer o "grade.gradeName" funcionar!!!
                public virtual Grade Grade { get; set; }
        
    }
}