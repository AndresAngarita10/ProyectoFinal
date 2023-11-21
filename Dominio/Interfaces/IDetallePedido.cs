
using Dominio.Entities;

namespace Dominio.Interfaces;

public interface IDetallePedido : IGenericRepoStr<DetallePedido>
{
    public abstract Task<(int totalRegistros, object registros)> GetByIdAsync(int pageIndez, int pageSize, string search) ;
}
