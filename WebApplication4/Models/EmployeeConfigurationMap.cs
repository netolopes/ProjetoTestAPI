using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace WebApplication4.Models
{
    public class EmployeeConfigurationMap : EntityTypeConfiguration<Employee>
    {
        public EmployeeConfigurationMap()
        {
            ToTable("Employees");
            HasKey(e => e.Id);

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
               .IsRequired()
               .HasColumnType("varchar")
               .HasMaxLength(150);

        }
    }
}