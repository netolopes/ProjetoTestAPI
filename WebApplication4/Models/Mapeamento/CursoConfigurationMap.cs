using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;
using WebApplication4.Models.M_M;

namespace WebApplication4.Models.Mapeamento
{
    public class CursoConfigurationMap : EntityTypeConfiguration<Curso>
    {
        public CursoConfigurationMap()
        {
            ToTable("Curso");

            // Id is the primary key
            HasKey(p => p.CursoId);
            // Id auto increment no sql server (IDENTITY)
            Property(p => p.CursoId)
                    .HasColumnName("CursoId")
                    .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity)
                    .IsRequired();
        }
    }
}