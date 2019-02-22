using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

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
       

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            //MAPEAMENTO DA TABELA, TB PODE SER FEITO EM UMA CLASSE SEPARADA OU PELO CODE FIRST
            //PODE SER FEITO AQUI ALGUM MAPEAMENTO Q SIRVA PRA TODOS
            
         //modelBuilder.Entity<Employee>()
        //.ToTable("Employees")
        //.HasKey(r => r.Id);
        
            //CHAMA A CLASSE DO MAPEAMENTO DA ENTIDADE
            modelBuilder.Configurations.Add(new EmployeeConfigurationMap());
        }


    }
}
