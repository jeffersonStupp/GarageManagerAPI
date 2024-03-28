using GarageManagerAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GarageManagerAPI.Data.Configs
{
    public class ProdutoConfig : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            builder.ToTable("PRODUTOS");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).UseIdentityColumn();
            builder.Property(p => p.Codigo).IsRequired();
            builder.Property(p => p.Descricao).IsRequired();
            builder.Property(p => p.Grupo).IsRequired();
            builder.Property(p => p.Tipo).IsRequired();
            builder.Property(p => p.Fabricante);
            builder.Property(p => p.Fornecedor);
            builder.Property(p => p.Preco).IsRequired().HasColumnType("money");
            builder.Property(p => p.Garantia);

        }
        
    }
}
