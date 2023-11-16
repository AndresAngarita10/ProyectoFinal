
using Dominio.Entities;

namespace API.Dtos;

public class DetallePedidoDto : BaseEntityStr
{
    public int Cantidad { get; set; }
    public decimal Precio_unidad { get; set; }
    public short Numero_linea { get; set; }
    public int Codigo_pedido { get; set; }
    public string Codigo_producto { get; set; }
}