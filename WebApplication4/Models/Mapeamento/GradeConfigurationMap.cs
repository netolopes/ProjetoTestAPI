using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;
using WebApplication4.Models._1_M;

namespace WebApplication4.Models.Mapeamento
{
    public class GradeConfigurationMap : EntityTypeConfiguration<Grade>
    {
        public GradeConfigurationMap()
        {
            ToTable("Grade");

            // Id is the primary key
            HasKey(p => p.GradeId);
            // Id auto increment no sql server (IDENTITY)
            Property(p => p.GradeId)
                    .HasColumnName("GradeId")
                    .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity)
                    .IsRequired();

            Property(e => e.GradeName)
                .IsRequired()
                .HasColumnType("varchar")
                .HasMaxLength(150);

        }
    }
}