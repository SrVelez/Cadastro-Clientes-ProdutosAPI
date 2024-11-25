using CadastroEmpresasAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MySqlX.XDevAPI;

namespace CadastroEmpresasAPI.Context.Mappings
{
    public class ClienteMapping:IEntityTypeConfiguration<Cliente>
    {
        public void Configure(
              EntityTypeBuilder<Cliente> builder)
        {
            builder.ToTable("Cliente");

            builder.HasKey(c => c.Id);

            builder.Property(c => c.Name)
                .IsRequired(true)
                .HasColumnType("NVARCHAR")
                .HasMaxLength(80);

            builder.Property(c => c.CNPJ)
                .IsRequired(true)
                .HasColumnType("VARCHAR")
                .HasMaxLength(18);

            builder.Property(c => c.Email)
                .IsRequired(true)
                .HasColumnType("VARCHAR")
                .HasMaxLength(100);

            builder.Property(c => c.Phone)
               .IsRequired(true)
               .HasColumnType("VARCHAR")
               .HasMaxLength(14);

            builder.Property(c => c.Address)
               .IsRequired(true)
               .HasColumnType("VARCHAR")
               .HasMaxLength(150);

            builder.Property(c => c.CreatedDate)
               .IsRequired(true)
               .HasColumnType("DATE")
               .HasMaxLength(50);
        }
    }

}
