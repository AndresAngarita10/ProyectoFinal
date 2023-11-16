
using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configuration;

public class ProductoConfiguration : IEntityTypeConfiguration<Producto>
{
    public void Configure(EntityTypeBuilder<Producto> builder)
    {
        builder.ToTable("producto");

        builder.HasKey(d => d.Id);
        builder.Property(d => d.Id)
        .HasColumnName("codigo_producto")
        .IsRequired();

        builder.Property(d => d.Nombre)
        .HasColumnName("nombre")
        .HasColumnType("varchar")
        .IsRequired()
        .HasMaxLength(250);

        builder.Property(d => d.Dimensiones)
        .HasColumnName("dimensiones")
        .HasColumnType("varchar")
        .HasMaxLength(250);

        builder.Property(d => d.Proveedor)
        .HasColumnName("proveedor")
        .HasColumnType("varchar")
        .HasMaxLength(250);

        builder.Property(d => d.Descripcion)
        .HasColumnName("descripcion")
        .HasColumnType("text")
        .HasMaxLength(250);

        builder.Property(d => d.Cantidad_en_stock)
        .HasColumnName("cantidad_en_stock")
        .HasColumnType("smallint")
        .HasAnnotation("MySql:ColumnType", "SMALLINT(6)")
        .IsRequired();

        builder.Property(d => d.Precio_venta)
        .HasColumnName("precio_venta")
        .HasColumnType("decimal(15,2)")
        .IsRequired();

        builder.Property(d => d.Precio_proveedor)
        .HasColumnName("precio_proveedor")
        .HasColumnType("decimal(15,2)");

        builder.HasOne(d => d.GamaProducto)
        .WithMany(d => d.Productos)
        .HasForeignKey(d => d.GamaIdFk);
    }
}