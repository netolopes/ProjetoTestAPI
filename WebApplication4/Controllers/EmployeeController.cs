using System;
using System.Drawing;
using System.Linq;
using System.Web.Mvc;
using WebApplication4.Models;
using Rotativa;
using PagedList;
using Rotativa.Options;
using System.Collections.Generic;

namespace WebApplication4.Controllers
{
    public class EmployeeController : Controller
    {
        private IGenericRepository<Employee> repository = null;
        public EmployeeController()
        {
            this.repository = new GenericRepository<Employee>();
        }


        // INSTALAR O PLUGIN DA PAGINACAO "PAGEDLIST" PELO NUGGET!!!
        public ActionResult Index(string sortOrder, string currentFilter, string searchString, int? page)
        {
            //sem paginacao
            //   var employee = repository.SelectAll().ToList();
            //  return View(employee);

            //com paginacao
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.FatherNameSortParm = sortOrder == "father_name_asc" ? "father_name_desc" : "father_name_asc";
            ViewBag.MotherNameSortParm = sortOrder == "mother_name_asc" ? "mother_name_desc" : "mother_name_asc";

            //Pagination
            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;



            var employees = from s in repository.SelectAll().ToList()
            select s;


            //Search
            if (!String.IsNullOrEmpty(searchString))
            {
                employees = employees.Where(s => s.Name.Contains(searchString)
                                       || s.FatherName.Contains(searchString));
            }

            //Sorter
            switch (sortOrder)
            {
                case "name_desc":
                    employees = employees.OrderByDescending(s => s.Name);
                    break;
                case "father_name_asc":
                    employees = employees.OrderBy(s => s.FatherName);
                    break;
                case "father_name_desc":
                    employees = employees.OrderByDescending(s => s.FatherName);
                    break;
                case "mother_name_asc":
                    employees = employees.OrderBy(s => s.MotherName);
                    break;
                case "mother_name_desc":
                    employees = employees.OrderByDescending(s => s.MotherName);
                    break;
                default:
                    employees = employees.OrderBy(s => s.Name);
                    break;
            }

            int pageSize = 3;
            int pageNumber = (page ?? 1);
            return View(employees.ToPagedList(pageNumber, pageSize));
           
        }
        //******************************************************************************************

        //GERAR RELATORIOS  -- INSTALAR PLUGIN ROTATIVA v1.6.0 PELO NUGGET!
        //MODELO 1 - IMPRIME A PAGINA DA VIEW DIRETO
        public ActionResult RelatorioEmployees(int? pagina, Boolean? pdf)
        {
            var listaEmployees = repository.SelectAll().ToList();
            if (pdf != true)
            {
                int numeroRegistros = 3;
                int numeroPagina = (pagina ?? 1);
                return View(listaEmployees.ToPagedList(numeroPagina, numeroRegistros));
            }
            else
            {
                int pagNumero = 1;
                
             
                                var relatorioPDF = new ViewAsPdf
                                {
                                    ViewName = "Index",
                                    FileName = "ExamReport.pdf",
                                    PageSize = Rotativa.Options.Size.A4,
                                    PageOrientation = Orientation.Portrait,
                                    
                                    Model = listaEmployees.ToPagedList(pagNumero, listaEmployees.Count)
                                   

                                 };
                                return relatorioPDF;
                       

            }
        }


        //MODELO 2 - PDF HEADER E FOOTER
        public ActionResult RelatorioPdf()
        {

            //exemplo passando parametros
         //    public ActionResult RelatorioPdf(DateTime dataInicial, DateTime dataFinal)
         //   var vendas = db.PedidoCabecalhos.Where(i => i.DataPedido >= dataInicial && i.DataPedido <= dataFinal).OrderBy(p => p.PedidoCabId).ToList<PedidoCabecalho>();
         //   ViewBag.dataInicial = dataInicial;
         //   ViewBag.dataFinal = dataFinal;



            //array de dados
            var employees = repository.SelectAll().ToList();

            string header = Server.MapPath("~/Views/Employee/PrintHeader.html");//Path of PrintHeader.html File
            string footer = Server.MapPath("~/Views/Employee/PrintFooter.html");//Path of PrintFooter.html File

            string customSwitches = string.Format("--header-html  \"{0}\" " +
                                  "--header-spacing \"0\" " +
                                  "--footer-html \"{1}\" " +
                                  "--footer-spacing \"10\" " +
                                  "--footer-font-size \"10\" " +
                                  "--header-font-size \"10\" ", header, footer);

            return new Rotativa.ViewAsPdf("Relatorio", employees)
            {
                FileName = "PdfFileName.pdf",
                PageSize = Rotativa.Options.Size.A4,
                PageOrientation = Orientation.Portrait,
                CustomSwitches = customSwitches,
                PageMargins = new Rotativa.Options.Margins(30, 10, 30, 10)
            };

        }



        //******************************************************************************************
        // GET: Employee/Details/5
        public ActionResult Details(int id)
        {
            var employee = repository.SelectByID(id);
            return View(employee);
        }

        // GET: Employee/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Employee/Create
        [HttpPost]
        public ActionResult Create(Employee employee)
        {
            if (ModelState.IsValid)
            {
                repository.Insert(employee);
                repository.Save();

                return RedirectToAction("Index");
            }
            return View(employee);
        }

        // GET: Employee/Edit/5
        public ActionResult Edit(int id)
        {
            var employee = repository.SelectByID(id);
            return View(employee);
        }

        // POST: Employee/Edit/5
        [HttpPost]
        public ActionResult Edit(Employee employee)
        {
            try
            {
                repository.Update(employee);
                repository.Save();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Employee/Delete/5
        public ActionResult Delete(int id)
        {
            var employee = repository.SelectByID(id);
            return View(employee);
        }

        // POST: Employee/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                repository.Delete(id);
                repository.Save();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}