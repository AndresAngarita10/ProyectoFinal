
using Dominio.Entities;

namespace API.Dtos;

public class EmpleadoDto : BaseEntityInt
{
    public string Nombre { get; set; }
    public string Apellido1 { get; set; }
    public string Apellido2 { get; set; }
    public string Extension { get; set; }
    public string Email { get; set; }
    public string Codigo_oficina { get; set; }
    public int? Codigo_jefe { get; set; }
    public string Puesto { get; set; }
}

