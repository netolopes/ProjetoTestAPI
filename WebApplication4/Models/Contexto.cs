using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;
using WebApplication4.Models._1_M;
using WebApplication4.Models.M_M;
using WebApplication4.Models.Mapeamento;

namespace WebApplication4.Models
{
    public class Contexto : DbContext
    {
        public Contexto()
            : base("name=DefaultConnection")
        {
            //ESSE PARAMETRO DESABILITA AS MIGRATIONS, USE ISTO PARA FAZER UM PROJETO A PARTIR DE UM BANCO DE DADOS EXISTENTE!
            Database.SetInitializer<Contexto>(null);
        }
        //cria a tabela no banco como: "Employees" ao executar o projeto sem necessitar de migrations!
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Grade> Grades { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Curso> Cursos { get; set; }
        public DbSet<UsuarioCurso> UsuarioCurso { get; set; }
        

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
            //   base.OnModelCreating(modelBuilder);

            //MAPEAMENTO DA TABELA, TB PODE SER FEITO EM UMA CLASSE SEPARADA OU PELO CODE FIRST
            //PODE SER FEITO AQUI ALGUM MAPEAMENTO Q SIRVA PRA TODOS
           

          //CHAMA A CLASSE DO MAPEAMENTO DA ENTIDADE
            modelBuilder.Configurations.Add(new EmployeeConfigurationMap());
            modelBuilder.Configurations.Add(new StudentConfigurationMap());
            modelBuilder.Configurations.Add(new GradeConfigurationMap());
            modelBuilder.Configurations.Add(new UsuarioConfigurationMap());
            modelBuilder.Configurations.Add(new CursoConfigurationMap());
           // modelBuilder.Configurations.Add(new UsuarioCursoConfigurationMap());

        }


    }
}
