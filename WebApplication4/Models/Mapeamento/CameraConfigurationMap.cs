using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;
using WebApplication4.Models.Entities;

namespace WebApplication4.Models.Mapeamento
{
    public class CameraConfigurationMap : EntityTypeConfiguration<Camera>
    {

        public CameraConfigurationMap()
        {
            ToTable("Camera");

            // Id is the primary key
            HasKey(p => p.CameraId);
            // Id auto increment no sql server (IDENTITY)
            Property(p => p.CameraId)
                    .HasColumnName("CameraId")
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


        }
    }
}