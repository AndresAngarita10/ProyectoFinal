
namespace Dominio.Entities;

public class Pedido : BaseEntityInt
{
    public DateOnly Fecha_pedido { get; set; }
    public DateOnly Fecha_esperada { get; set; }
    public DateOnly Fecha_entrega { get; set; }
    public string Estado { get; set; }
    public string Comentarios { get; set; }
    public int Codigo_cliente { get; set; }
    public Cliente Cliente { get; set; }
    public ICollection<DetallePedido> DetallePedidos { get; set; }
}
