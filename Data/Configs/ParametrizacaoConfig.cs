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





            builder.HasData(new List<Parametrizacao>()

            { new Parametrizacao()
            {
                Id=1,HomologacaoDireta=false,IdadeMinimaCadastro=0,IdadeMaximaCadastro = 100,
            }



            }


                );


        }
    }
}
