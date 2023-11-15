
namespace Dominio.Entities;

public class Pago : BaseEntityInt
{
    public string Forma_pago { get; set; }
    public DateOnly Fecha_pago { get; set; }
    public decimal Total { get; set; }
    public int Codigo_cliente { get; set; }
    public Cliente Cliente { get; set; }
}
