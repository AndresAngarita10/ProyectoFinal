
using Dominio.Entities;
using Dominio.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistencia;

namespace Aplicacion.Repository;

public class PedidoRepository : GenericRepoInt<Pedido>, IPedido
{
    protected readonly ApiContext _context;

    public PedidoRepository(ApiContext context) : base(context)
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
        .FirstOrDefaultAsync(p => p.Id == id);
    }

    //2. Devuelve un listado con los distintos estados por los que puede pasar un pedido.
    public async Task<IEnumerable<object>> DistintosEstadosPedido()
    {
        return await _context.Pedidos
                .GroupBy(c => c.Estado)
                .Select(grupo => new
                {
                    Estado = grupo.Key
                }).ToListAsync();
    }

    /* 4. Devuelve un listado con el código de pedido, código de cliente, fecha 
esperada y fecha de entrega de los pedidos que no han sido entregados a 
tiempo. */
    public async Task<IEnumerable<object>> ListadoPedidosNoEntregadosATiempo()
    {
        return await _context.Pedidos
            .Include(p => p.Cliente)
            .Where(p => p.Fecha_entrega > p.Fecha_esperada)
            .Select(pedido => new
            {
                codigo_Pedido = pedido.Id,
                codigo_cliente = pedido.Codigo_cliente,
                nombre_cliente = pedido.Cliente.Nombre_cliente,
                fecha_esperada = pedido.Fecha_esperada,
                fecha_entrega = pedido.Fecha_entrega
            }).ToListAsync();

    }

    /*  5. Devuelve un listado con el código de pedido, código de cliente, fecha 
 esperada y fecha de entrega de los pedidos cuya fecha de entrega ha sido al 
 menos dos días antes de la fecha esperada */
    public async Task<IEnumerable<object>> DosDiasAntesFechaEsperada()
    {
        return await _context.Pedidos
            .Include(p => p.Cliente)
            .Where(p => p.Fecha_entrega.HasValue && EF.Functions.DateDiffDay(p.Fecha_esperada, p.Fecha_entrega.Value) >= 2)
            .Select(pedido => new
            {
                codigo_pedido = pedido.Id,
                codigo_cliente = pedido.Codigo_cliente,
                nombre_cliente = pedido.Cliente.Nombre_cliente,
                fecha_esperada = pedido.Fecha_esperada,
                fecha_entrega = pedido.Fecha_entrega
            })
            .ToListAsync();
    }

    //6. Devuelve un listado de todos los pedidos que fueron rechazados en 2009.
    public async Task<IEnumerable<object>> PedidosRechazadosEn2009()
    {
        return await _context.Pedidos
           .Include(p => p.Cliente)
           .Where(p => p.Estado.ToLower().Equals("rechazado") && p.Fecha_entrega.Value.Year == 2009)
           .Select(pedido => new
             {
                 codigo_pedido = pedido.Id,
                 codigo_cliente = pedido.Codigo_cliente,
                 nombre_cliente = pedido.Cliente.Nombre_cliente,
                 fecha_esperada = pedido.Fecha_esperada,
                 fecha_entrega = pedido.Fecha_entrega,
                 estado = pedido.Estado
             })
           .ToListAsync();
    }

/*  7 Devuelve un listado de todos los pedidos que han sido entregados en el 
mes de enero de cualquier año. */
    public async Task<IEnumerable<object>> PedidosEntregadosEnEnero()
    {
        return await _context.Pedidos
          .Include(p => p.Cliente)
          .Where(p => p.Estado.ToLower().Equals("entregado") && p.Fecha_entrega.Value.Month == 1)
          .Select(pedido => new
             {
                 codigo_pedido = pedido.Id,
                 codigo_cliente = pedido.Codigo_cliente,
                 nombre_cliente = pedido.Cliente.Nombre_cliente,
                 fecha_esperada = pedido.Fecha_esperada,
                 fecha_entrega = pedido.Fecha_entrega,
                 estado = pedido.Estado
             })
          .ToListAsync();
    }


}