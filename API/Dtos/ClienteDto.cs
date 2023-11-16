
using Dominio.Entities;

namespace API.Dtos;

public class ClienteDto : BaseEntityInt
{
    public string Nombre_cliente { get; set; }
    public string Nombre_contacto { get; set; }
    public string Apellido_contacto { get; set; }
    public string Telefono { get; set; }
    public string Fax { get; set; }
    public string Linea_direccion1 { get; set; }
    public string Linea_direccion2 { get; set; }
    public string Ciudad { get; set; }
    public string Region { get; set; }
    public string Pais { get; set; }
    public string Codigo_postal { get; set; }
    public int Codigo_empleado_rep_ventas { get; set; }
    public decimal Limite_credito { get; set; }
}
