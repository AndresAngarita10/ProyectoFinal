
namespace Dominio.Entities;

public class DetallePedido
{
    public int Cantidad { get; set; }
    public decimal Precio_unidad { get; set; }
    public short Numero_linea { get; set; }
    public int Codigo_pedido { get; set; }
    public Pedido Pedido { get; set; }
    public string Codigo_producto { get; set; }
    public Producto Producto { get; set; }
}
