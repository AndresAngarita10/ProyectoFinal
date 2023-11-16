
using Dominio.Entities;

namespace API.Dtos;

public class PagoDto : BaseEntityStr
{
    public string Forma_pago { get; set; }
    public DateOnly Fecha_pago { get; set; }
    public decimal Total { get; set; }
    public int Codigo_cliente { get; set; }
}

