using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;
using WebApplication4.Models.M_M;

namespace WebApplication4.Models.Mapeamento
{
    public class UsuarioConfigurationMap : EntityTypeConfiguration<Usuario>
    {
        public UsuarioConfigurationMap()
        {
            ToTable("Usuario");

            // Id is the primary key
            HasKey(p => p.UsuarioId);
            // Id auto increment no sql server (IDENTITY)
            Property(p => p.UsuarioId)
                    .HasColumnName("UsuarioId")
                    .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity)
                    .IsRequired();

            Property(e => e.Name)
                .IsRequired()
                .HasColumnType("varchar")
                .HasMaxLength(150);
/*
            HasMany<Curso>(s => s.Cursos) // virtual Icollection da classe curso
                .WithMany(c => c.Usuarios) // virtual Icollection da classe usuario
                .Map(cs =>
                {
                    cs.MapLeftKey("UsuarioId"); //chave estrangeira de usuario
                    cs.MapRightKey("CursoId"); //chave estrangeira de curso
                    cs.ToTable("UsuarioCurso"); //tabela no banco q une as 2 tabelas"!!!!!!!
                });

    */

        }
    }
}