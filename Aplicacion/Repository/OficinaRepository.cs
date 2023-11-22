
using Dominio.Entities;
using Dominio.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistencia;

namespace Aplicacion.Repository;

public class OficinaRepository : GenericRepoStr<Oficina>, IOficina
{
    protected readonly ApiContext _context;

    public OficinaRepository(ApiContext context) : base(context)
    {
        _context = context;
    }

    public override async Task<IEnumerable<Oficina>> GetAllAsync()
    {
        return await _context.Oficinas
            .ToListAsync();
    }

    public override async Task<Oficina> GetByIdAsync(string id)
    {
        return await _context.Oficinas
        .FirstOrDefaultAsync(p => p.Id.Equals(id));
    }

    public async Task<(int totalRegistros, object registros)> GetAllAsync(int pageIndez, int pageSize, string search)
    {
        var query = (
             _context.Oficinas.AsQueryable()
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