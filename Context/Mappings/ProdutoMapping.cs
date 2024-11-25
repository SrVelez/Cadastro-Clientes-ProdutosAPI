using CadastroEmpresasAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CadastroEmpresasAPI.Context.Mappings
{
    public class ProdutoMapping:IEntityTypeConfiguration<Produto>
    {

        public void Configure(
        EntityTypeBuilder<Produto> builder)
        {
            builder.ToTable("Produto");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.ProjectName)
                .IsRequired(true)
                .HasColumnType("NVARCHAR")
                .HasMaxLength(80);
             
            builder.Property(p => p.Description)
               .IsRequired(false)
               .HasColumnType("TEXT")
               .HasMaxLength(200);

            builder.Property(p =>p.StartDate)
                .IsRequired(false)
                .HasColumnType("DATE")
                .HasMaxLength(255);

            builder.Property(p => p.EndDate)
                .IsRequired(false)
                .HasColumnType("DATE")
                .HasMaxLength(160);
        }
    }
}
