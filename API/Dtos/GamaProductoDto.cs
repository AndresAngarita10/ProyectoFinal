
using Dominio.Entities;

namespace API.Dtos;

public class GamaProductoDto : BaseEntityStr
{
    public string Descripcion_texto { get; set; }
    public string Descripcion_html { get; set; }
    public string Imagen { get; set; }
}

