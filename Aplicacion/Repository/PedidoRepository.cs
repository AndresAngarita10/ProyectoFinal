
using Dominio.Entities;
using Dominio.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistencia;

namespace Aplicacion.Repository;

public class PedidoRepository : GenericRepoInt<Pedido>, IPedido
{
    protected readonly ApiContext _context;
    
    public PedidoRepository(ApiContext context) : base (context)
    {
        _context = context;
    }

    public override async Task<IEnumerable<Pedido>> GetAllAsync()
    {
        return await _context.Pedidos
            .ToListAsync();
    }

    public override async Task<Pedido> GetByIdAsync(int id)
    {
        return await _context.Pedidos
        .FirstOrDefaultAsync(p =>  p.Id == id);
    }
}