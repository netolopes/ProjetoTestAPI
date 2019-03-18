using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;
using WebApplication4.Models._1_M;

namespace WebApplication4.Models.Mapeamento
{
    public class StudentConfigurationMap : EntityTypeConfiguration<Student>
    {
        public StudentConfigurationMap()
        {
            ToTable("Student");

            // Id is the primary key
            HasKey(p => p.Id);
            // Id auto increment no sql server (IDENTITY)
            Property(p => p.Id)
                    .HasColumnName("Id")
                    .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity)
                    .IsRequired();

            Property(e => e.Name)
                .IsRequired()
                .HasColumnType("varchar")
                .HasMaxLength(150);

            // configures one-to-many relationship
             HasRequired<Grade>(s => s.Grade)
            .WithMany(g => g.Students)
            .HasForeignKey<int>(s => s.GradeId);

        }
    }
}