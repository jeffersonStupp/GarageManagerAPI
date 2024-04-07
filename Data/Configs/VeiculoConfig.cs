using GarageManagerAPI.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace GarageManagerAPI.Data.Configs
{
    public class VeiculoConfig : IEntityTypeConfiguration<Veiculo>
    {
        public void Configure(EntityTypeBuilder<Veiculo> builder)
        {
            builder.ToTable("VEICULOS");
            builder.HasKey(v => v.Id);
            builder.Property(v => v.Id).UseIdentityColumn();
            builder.Property(v => v.Marca).IsRequired();
            builder.Property(v => v.Modelo).IsRequired();
            builder.Property(v => v.Ano).IsRequired();
            builder.Property(v => v.Placa).IsRequired();
            builder.Property(v => v.Cor).IsRequired();

            
            builder.HasOne(v => v.Cliente)
                   .WithMany(c => c.Veiculos)
                   .HasForeignKey(v => v.ClienteId)
                   .OnDelete(DeleteBehavior.Cascade); 
        }
    }
}