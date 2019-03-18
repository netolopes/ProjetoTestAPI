using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace WebApplication4.Models
{
    public class EmployeeConfigurationMap : EntityTypeConfiguration<Employee>
    {
        public EmployeeConfigurationMap()
        {
            ToTable("dbo.Employees");
         
            // Id is the primary key
            HasKey(p => p.Id);
            // Id auto increment no sql server (IDENTITY)
            Property(p => p.Id).
                    HasColumnName("Id").
                    HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity).
                    IsRequired();



            Property(e => e.Name)
                .IsRequired()
                .HasColumnType("varchar")
                .HasMaxLength(150);

            Property(e => e.FatherName)
                .IsRequired()
                .HasColumnType("varchar")
                .HasMaxLength(150);

            Property(e => e.MotherName)
                 .IsRequired()
                 .HasColumnType("varchar")
                 .HasMaxLength(150);

            Property(e => e.Designation)
                .IsRequired()
                .HasColumnType("varchar")
                .HasMaxLength(150);

            Property(e => e.Dept)
                .IsRequired()
                .HasColumnType("varchar")
                .HasMaxLength(150);

            Property(e => e.Teste)
               .HasColumnType("varchar")
               .HasMaxLength(150);

        }
    }
}