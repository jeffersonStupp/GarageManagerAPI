using GarageManager.Models;
using GarageManagerAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GarageManagerAPI.Data.Configs
{
    public class ParametrizacaoConfig : IEntityTypeConfiguration<Parametrizacao>
    {
        public void Configure(EntityTypeBuilder<Parametrizacao> builder)
        {
            builder.ToTable("PARAMETRIZACAO");
            builder.HasKey(p => p.Id);
            builder.Property(p=>p.HomologacaoDireta).IsRequired();
            builder.Property(p=>p.IdadeMaximaCadastro).IsRequired();
            builder.Property(p=>p.IdadeMinimaCadastro).IsRequired();
            builder.Property(p => p.MargemPecas).IsRequired();
            builder.Property(p => p.DescontoPagamentoVista).IsRequired();
            builder.Property(p => p.MaoDeObra).IsRequired().HasColumnType("money");





            builder.HasData(new List<Parametrizacao>()

            { new Parametrizacao()
            {
                Id=1,HomologacaoDireta=false,
                IdadeMinimaCadastro=0,
                IdadeMaximaCadastro = 100,
                DescontoPagamentoVista=0,
                MargemPecas=0,
                MaoDeObra=0,

            }



            }


                );


        }
    }
}
