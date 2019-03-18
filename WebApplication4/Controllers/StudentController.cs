using System.Linq;
using System.Web.Mvc;
using WebApplication4.Models;
using WebApplication4.Models._1_M;
using System.Data;
using System.Data.Entity;
using System.Collections.Generic;

namespace WebApplication4.Controllers
{
    public class StudentController : Controller
    {

        private IGenericRepository<Student> repository = null;
        private IGenericRepository<Grade> repository_grade = null;
        public StudentController()
        {
            this.repository = new GenericRepository<Student>();
            this.repository_grade = new GenericRepository<Grade>();
           
        }

        public ActionResult Index()
        {
      
                //MODELO 1
                var students = repository.SelectAll();

                        //MODELO 2
                        /*
                var   students = (from s in repository.SelectAll()
                                            join g in repository_grade.SelectAll()
                                            on s.GradeId equals g.GradeId 
                                            select new Student()
                                            {
                                                Id = s.Id,
                                                Name = s.Name,
                                                Grade = s.Grade
                                            }).ToList();

                        */


            return View(students);
        }



        // GET: Employee/Create
        public ActionResult Create()
        {
            ViewBag.GradeId = new SelectList(repository_grade.SelectAll(), "GradeId", "GradeName");
            return View();
        }

        // POST: Employee/Create
        [HttpPost]
        public ActionResult Create(Student students)
        {
            if (ModelState.IsValid)
            {
                repository.Insert(students);
                repository.Save();

                return RedirectToAction("Index");
            }
            return View(students);
        }


    }
}