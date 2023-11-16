
using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configuration;

public class DetallePedidoConfiguration : IEntityTypeConfiguration<DetallePedido>
{
    public void Configure(EntityTypeBuilder<DetallePedido> builder)
    {
        builder.ToTable("detallepedido");
        //builder.HasKey(d => d.Id = new { d.Codigo_pedido, d.Codigo_producto });
        builder.HasKey(d => new { d.Codigo_pedido, d.Codigo_producto }); // Definir clave primaria compuesta
        //builder.HasNoKey();

        builder.Property(d => d.Cantidad)
        .HasColumnName("cantidad")
        .HasColumnType("int")
        .IsRequired()
        .HasMaxLength(3);

        builder.Property(d => d.Precio_unidad)
        .HasColumnName("precio_unidad")
        .HasColumnType("decimal(15,2)")
        .IsRequired();
        
        builder.Property(d => d.Numero_linea)
        .HasColumnName("numero_linea")
        .HasColumnType("smallint")
        .HasAnnotation("MySql:ColumnType", "SMALLINT(6)")
        .IsRequired();

        builder.HasOne(d => d.Pedido)
        .WithMany(d => d.DetallePedidos)
        .HasForeignKey(d => d.Codigo_pedido);

        builder.HasOne(d => d.Producto)
        .WithMany(d => d.DetallePedidos)
        .HasForeignKey(d => d.Codigo_producto);
    }
}