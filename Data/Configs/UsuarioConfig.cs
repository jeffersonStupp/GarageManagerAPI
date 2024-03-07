using GarageManager.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace GarageManager.Database.Configs
{
    public class UsuarioConfig : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.ToTable("USUARIOS");

            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).UseIdentityColumn();

            
            builder.Property(x => x.NomeUsuario)
                .IsRequired()
                .HasMaxLength(150);

            builder.Property(x => x.Email)
                .IsRequired()
                .HasMaxLength(150);

            builder.Property(x => x.Senha)
                .IsRequired()
                .HasMaxLength(150);

            builder.Property(x => x.Ativo)
                .HasDefaultValue(true)
                .IsRequired();

            builder.Property(x => x.Tipo)
                .HasDefaultValue("usuario")
                .HasMaxLength(30)
                .IsRequired();

            builder.HasData(new List<Usuario>()
        {
            new Usuario() { Id = 1, NomeUsuario = "usuario", Email = "usuario@email.com", Senha = "usuario", Tipo = "usuario" },
            new Usuario() { Id = 2, NomeUsuario = "Jefferson", Email = "jeffersonstupp@hotmail.com", Senha = "0411vm", Tipo = "administrador" }
        });
        }
    }
}