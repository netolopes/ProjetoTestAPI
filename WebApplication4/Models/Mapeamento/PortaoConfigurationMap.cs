using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;
using WebApplication4.Models.Entities;

namespace WebApplication4.Models.Mapeamento
{
    public class PortaoConfigurationMap : EntityTypeConfiguration<Portao>
    {

        public PortaoConfigurationMap() {
         ToTable("Portao");

            // Id is the primary key
            HasKey(p => p.PortaoId);
            // Id auto increment no sql server (IDENTITY)
            Property(p => p.PortaoId)
                    .HasColumnName("PortaoId")
                    .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity)
                    .IsRequired();

            Property(e => e.Ip)
                .IsRequired()
                .HasColumnType("varchar")
                .HasMaxLength(100);

            Property(e => e.Mac)
              .IsRequired()
              .HasColumnType("varchar")
              .HasMaxLength(100);

            Property(e => e.Status)
              .IsRequired()
              .HasColumnType("varchar")
              .HasMaxLength(10);

            Property(e => e.Estado)
              .IsRequired()
              .HasColumnType("varchar")
              .HasMaxLength(10);

        }

    }
}