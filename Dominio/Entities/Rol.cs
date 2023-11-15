namespace Dominio.Entities;
public class Rol : BaseEntityInt
{
    public string Nombre { get; set; }

    public ICollection<Usuario> Usuarios { get; set; } = new HashSet<Usuario>();
    public ICollection<RolUsuario> RolUsuarios { get; set; }
}
