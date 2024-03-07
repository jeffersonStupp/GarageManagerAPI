using GarageManager.Models;

using GarageManager.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace GarageManager.Database.Configs
{
    public class ClienteConfig : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.ToTable("CLIENTES");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();
            builder.Property(x => x.Nome).IsRequired().HasMaxLength(200);
            builder.Property(x => x.DataNascimento).IsRequired();
            builder.Property(x => x.Cpf).IsRequired().HasMaxLength(14);
            builder.Property(x => x.Email).HasMaxLength(200);
            builder.Property(x => x.Celular).IsRequired();
            builder.Property(x => x.Telefone);
            builder.Property(x => x.Rua).IsRequired();
            builder.Property(x => x.Numero).HasMaxLength(10);
            builder.Property(x => x.Bairro).IsRequired();
            builder.Property(x => x.Cidade).IsRequired();
            builder.Property(x => x.Estado).IsRequired();
            builder.Property(x => x.Situacao).HasDefaultValue("normal");



    }
    }
}