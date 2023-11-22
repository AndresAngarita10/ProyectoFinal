
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
    public async Task<(int totalRegistros, object registros)> DistintosEstadosPedido(int pageIndez, int pageSize, string search)
    {
        var query = (
            _context.Pedidos
                .GroupBy(c => c.Estado)
                .Select(grupo => new
                {
                    Estado = grupo.Key
                })
            );

        if (!string.IsNullOrEmpty(search))
        {
            query = query.Where(p => p.Estado.ToLower().Contains(search));
        }

        query = query.OrderBy(p => p.Estado);
        var totalRegistros = await query.CountAsync();
        var registros = await query
            .Skip((pageIndez - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();

        return (totalRegistros, registros);
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
    public async Task<(int totalRegistros, object registros)> ListadoPedidosNoEntregadosATiempo(int pageIndez, int pageSize, string search)
    {
        var query = (
            _context.Pedidos
            .Include(p => p.Cliente)
            .Where(p => p.Fecha_entrega > p.Fecha_esperada)
            .Select(pedido => new
            {
                codigo_Pedido = pedido.Id,
                codigo_cliente = pedido.Codigo_cliente,
                nombre_cliente = pedido.Cliente.Nombre_cliente,
                fecha_esperada = pedido.Fecha_esperada,
                fecha_entrega = pedido.Fecha_entrega
            })
            );

        if (!string.IsNullOrEmpty(search))
        {
            query = query.Where(p => p.nombre_cliente.ToLower().Contains(search));
        }

        query = query.OrderBy(p => p.nombre_cliente);
        var totalRegistros = await query.CountAsync();
        var registros = await query
            .Skip((pageIndez - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();

        return (totalRegistros, registros);
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

    /* 32. ¿Cuántos pedidos hay en cada estado? Ordena el resultado de forma 
descendente por el número de pedidos. */
    public async Task<IEnumerable<object>> NumeroPedidosCadaEstado32()
    {
        return await _context.Pedidos
        .GroupBy(p => p.Estado)
        .Select(pe => new
        {
            pe.Key,
            cantidad = pe.Count()
        }).ToListAsync();
    }

    /* 38. Calcula el número de productos diferentes que hay en cada uno de los 
pedidos. */
    public async Task<IEnumerable<object>> NumeroProductosPedidos38()
    {
        return await _context.DetallePedidos
            .GroupBy(detalle => detalle.Codigo_pedido)
            .Select(pedido => new
            {
                CodigoPedido = pedido.Key,
                NumeroProductosDiferentes = pedido.GroupBy(detalle => detalle.Codigo_producto).Count()
            })
            .ToListAsync();
    }

    /* 39. Calcula la suma de la cantidad total de todos los productos que aparecen en 
cada uno de los pedidos. */
    public async Task<IEnumerable<object>> CantidadTotalProductosPedidos39()
    {
        return await _context.DetallePedidos
           .GroupBy(detalle => detalle.Codigo_pedido)
           .Select(pedido => new
           {
               CodigoPedido = pedido.Key,
               CantidadTotalProductos = pedido.Sum(detalle => detalle.Cantidad)
           })
           .ToListAsync();
    }

    /* 40. Devuelve un listado de los 20 productos más vendidos y el número total de 
unidades que se han vendido de cada uno. El listado deberá estar ordenado 
por el número total de unidades vendidas.
 */
    public async Task<IEnumerable<object>> ProductosMasVendidos40()
    {
        return await _context.DetallePedidos
            .GroupBy(detalle => detalle.Codigo_producto)
            .Select(producto => new
            {
                CodigoProducto = producto.Key,
                NombreProducto = producto.First().Producto.Nombre,
                TotalUnidadesVendidas = producto.Sum(detalle => detalle.Cantidad)
            })
            .OrderByDescending(producto => producto.TotalUnidadesVendidas)
            .Take(20)
            .ToListAsync();
    }

    /* 41.. La misma información que en la pregunta anterior, pero agrupada por 
código de producto. */
    public async Task<IEnumerable<object>> ProductosMasVendidosporCodigoProducto41()
    {
        return await _context.DetallePedidos
            .GroupBy(detalle => detalle.Codigo_producto)
            .Select(producto => new
            {
                CodigoProducto = producto.Key,
                NombreProducto = producto.First().Producto.Nombre,
                TotalUnidadesVendidas = producto.Sum(detalle => detalle.Cantidad)
            })
            .OrderByDescending(producto => producto.TotalUnidadesVendidas)
            .Take(20)
            .ToListAsync();
    }

    /* 42. La misma información que en la pregunta anterior, pero agrupada por 
código de producto filtrada por los códigos que empiecen por OR */
    public async Task<IEnumerable<object>> ProductosMasVendidosporCodigoProductoYFiltrada42()
    {
        return await _context.DetallePedidos
            .Where(p => p.Producto.Id.StartsWith("OR"))
            .GroupBy(detalle => detalle.Codigo_producto)
            .Select(producto => new
            {
                CodigoProducto = producto.Key,
                NombreProducto = producto.First().Producto.Nombre,
                TotalUnidadesVendidas = producto.Sum(detalle => detalle.Cantidad)
            })
            .OrderByDescending(producto => producto.TotalUnidadesVendidas)
            .Take(20)
            .ToListAsync();
    }

    /* 43. Lista las ventas totales de los productos que hayan facturado más de 3000 
euros. Se mostrará el nombre, unidades vendidas, total facturado y total 
facturado con impuestos (21% IVA). */
    public async Task<IEnumerable<object>> ProductosMasVendidos43()
    {
        return await _context.DetallePedidos
           .GroupBy(detalle => detalle.Codigo_producto)
           .Where(producto => producto.Sum(detalle => detalle.Cantidad * detalle.Precio_unidad) > 3000)
           .Select(producto => new
           {
               CodigoProducto = producto.Key,
               NombreProducto = producto.First().Producto.Nombre,
               TotalUnidadesVendidas = producto.Sum(detalle => detalle.Cantidad),
               TotalFacturado = Convert.ToDouble(producto.Sum(detalle => detalle.Cantidad * detalle.Precio_unidad)),
               TotalFacturadoConImpuestos = Convert.ToDouble(producto.Sum(detalle => (Convert.ToDecimal(detalle.Cantidad) * detalle.Precio_unidad)) * Convert.ToDecimal(1.21))
           })
           .OrderByDescending(producto => producto.TotalFacturadoConImpuestos)
           .ToListAsync();
    }



}