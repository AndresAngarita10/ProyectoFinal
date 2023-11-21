
using Dominio.Entities;
using Dominio.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistencia;

namespace Aplicacion.Repository;

public class DetallePedidoRepository : GenericRepoStr<DetallePedido>, IDetallePedido
{
    protected readonly ApiContext _context;
    
    public DetallePedidoRepository(ApiContext context) : base (context)
    {
        _context = context;
    }

    public override async Task<IEnumerable<DetallePedido>> GetAllAsync()
    {
        return await _context.DetallePedidos
            .ToListAsync();
    }

    public override async Task<DetallePedido> GetByIdAsync(string id)
    {
        return await _context.DetallePedidos
        .FirstOrDefaultAsync(p =>  p.Id.Equals(id));
    }
    
    public async Task<(int totalRegistros, object registros)> GetByIdAsync(int pageIndez, int pageSize, string search) 
    {
        var query = (
             _context.DetallePedidos.AsQueryable()
            );

        if (!string.IsNullOrEmpty(search))
        {
            query = query.Where(p => p.Id.Contains(search));
        }

        query = query.OrderBy(p => p.Id);
        var totalRegistros = await query.CountAsync();
        var registros = await query
            .Skip((pageIndez - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();

        return (totalRegistros, registros);
    }
}