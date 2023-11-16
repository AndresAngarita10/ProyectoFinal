
using Dominio.Entities;

namespace API.Dtos;

public class OficinaDto : BaseEntityStr
{
    public string Ciudad { get; set; }
    public string Pais { get; set; }
    public string Region { get; set; }
    public string Codigo_postal { get; set; }
    public string Telefono { get; set; }
    public string Linea_direccion1 { get; set; }
    public string Linea_direccion2 { get; set; }
}

