using ApiThreeTier.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ApiThreeTier.Data.Mappings
{
    public class ProdutoMapping : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Nome)
                   .IsRequired()
                   .HasColumnType("varchar(200)");
            
            builder.Property(x => x.Descricao)
                   .IsRequired()
                   .HasColumnType("varchar(255)");

            builder.ToTable("Produtos");
        }
    }
}
