using AutoMapper;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApplication4.Models;
using WebApplication4.Models._1_M;
using WebApplication4.Models.M_M;

namespace WebApplication4.Controllers
{
    public class UserAPIController : ApiController
    {
        //array de studentVM
        List<StudentViewModel> listaStudentVM = new List<StudentViewModel>();

        private IGenericRepository<Usuario> repository = null;
        private IGenericRepository<Student> repository_student = null;
        private IGenericRepository<Grade> repository_grade = null;
        private IGenericRepository<StudentViewModel> repository_svm = null;

        public UserAPIController()
        {
            this.repository = new GenericRepository<Usuario>();
            this.repository_student = new GenericRepository<Student>();
            this.repository_grade = new GenericRepository<Grade>();
            this.repository_svm = new GenericRepository<StudentViewModel>();

        }



        // GET:     
          //  public IList<Student> Get()
         public IEnumerable<StudentDTO> Get()
        {
            // return new string[] { "value1", "value2" };

            /*
             var books = from b in repository.SelectAll()
                         select new Usuario()
                         {
                             UsuarioId = b.UsuarioId,
                             Name = b.Name
                         };

                 return books;
            */


           
                 //ESQUEMA DE VIEWMODEL JUNTAR AS CLASSES E ADICIONAR OS VALORES CORRESPONDENTES NA VIEW MODEL
                  var   students = (from s in repository_student.SelectAll()
                                                 join g in repository_grade.SelectAll()
                                                 on s.GradeId equals g.GradeId 
                                                 select new StudentDTO
                                                 {
                                                     Id = s.Id,
                                                     Name = s.Name,
                                                     GradeId = s.GradeId
                                                 });

        return students.ToList().Select(Mapper.Map<StudentDTO>);
            

            /*
                 //adiciona dados na classe studentVM - automapper MANUAL
                 foreach (var item in students)
                 {
                     //cria o objeto de studentVM
                     StudentViewModel studentVM = new StudentViewModel();

                     studentVM.Name = item.Name;
                     studentVM.GradeName = item.Grade.GradeName;

                     //adiciona ao array de studentVm
                     listaStudentVM.Add(studentVM);
                 }

                 return listaStudentVM;
         */


        }
      

        // GET: api/UserAPI/5
        public string Get(int id)
        {
            return "value";
        }
        /*
      // POST: api/UserAPI
      public void Post([FromBody]string value)
      {
      }

      // PUT: api/UserAPI/5
      public void Put(int id, [FromBody]string value)
      {
      }

      // DELETE: api/UserAPI/5
      public void Delete(int id)
      {
      }
      */
    }
}
