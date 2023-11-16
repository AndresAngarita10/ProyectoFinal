
using Dominio.Entities;

namespace API.Dtos;

public class ProductoDto : BaseEntityStr
{
    public string Nombre { get; set; }
    public string Dimensiones { get; set; }
    public string Proveedor { get; set; }
    public string Descripcion { get; set; }
    public short Cantidad_en_stock { get; set; }
    public decimal Precio_venta { get; set; }
    public decimal Precio_proveedor { get; set; }
    public string GamaIdFk { get; set; }
}