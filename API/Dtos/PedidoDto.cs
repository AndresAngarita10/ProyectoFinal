
using Dominio.Entities;

namespace API.Dtos;

public class PedidoDto : BaseEntityInt
{
    public DateOnly Fecha_pedido { get; set; }
    public DateOnly Fecha_esperada { get; set; }
    public DateOnly Fecha_entrega { get; set; }
    public string Estado { get; set; }
    public string Comentarios { get; set; }
    public int Codigo_cliente { get; set; }
}

