
using Dominio.Entities;
using Dominio.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistencia;

namespace Aplicacion.Repository;

public class GamaProductoRepository : GenericRepoStr<GamaProducto>, IGamaProducto
{
    protected readonly ApiContext _context;
    
    public GamaProductoRepository(ApiContext context) : base (context)
    {
        _context = context;
    }

    public override async Task<IEnumerable<GamaProducto>> GetAllAsync()
    {
        return await _context.GamaProductos
            .ToListAsync();
    }

    public override async Task<GamaProducto> GetByIdAsync(string id)
    {
        return await _context.GamaProductos
        .FirstOrDefaultAsync(p =>  p.Id.Equals(id));
    }
    
    public async Task<(int totalRegistros, object registros)> GetAllAsync(int pageIndez, int pageSize, string search) 
    {
        var query = (
             _context.GamaProductos.AsQueryable()
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