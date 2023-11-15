
namespace Dominio.Entities;

public class GamaProducto : BaseEntityStr
{
    public string Descripcion_texto { get; set; }
    public string Descripcion_html { get; set; }
    public string Imagen { get; set; }
    public ICollection<Producto> Productos { get; set; }
}
