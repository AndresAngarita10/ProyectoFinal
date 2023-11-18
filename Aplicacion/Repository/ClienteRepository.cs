
using Dominio.Entities;
using Dominio.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistencia;

namespace Aplicacion.Repository;

public class ClienteRepository : GenericRepoInt<Cliente>, ICliente
{
    protected readonly ApiContext _context;

    public ClienteRepository(ApiContext context) : base(context)
    {
        _context = context;
    }

    public override async Task<IEnumerable<Cliente>> GetAllAsync()
    {
        return await _context.Clientes
            .ToListAsync();
    }

    public override async Task<Cliente> GetByIdAsync(int id)
    {
        return await _context.Clientes
        .FirstOrDefaultAsync(p => p.Id == id);
    }

    //consulta 1. Devuelve un listado con el nombre de los todos los clientes españoles
    public async Task<IEnumerable<object>> ListadoClientesEspañones()
    {
        return await _context.Clientes
                .Where(p => p.Pais.ToLower() == "spain")
                .Select(cliente => new
                {
                    cliente.Nombre_cliente,
                    cliente.Pais
                })
                .ToListAsync();
    }

    /* 3. Devuelve un listado con el código de cliente de aquellos clientes que 
    realizaron algún pago en 2008. Tenga en cuenta que deberá eliminar 
    aquellos códigos de cliente que aparezcan repetidos. Resuelva la consulta: */
    public async Task<IEnumerable<object>> ListadoClientesPagos2008()
    {
        return await _context.Pagos
            .Include(p => p.Cliente)
            .Where(p => p.Fecha_pago.Year == 2008)
            .Select(cliente => new
            {
                Codigo = cliente.Codigo_cliente,
                Nombre = cliente.Cliente.Nombre_cliente
            })
            .ToListAsync();
    }

    /*  11. Devuelve un listado con todos los clientes que sean de la ciudad de Madrid y 
 cuyo representante de ventas tenga el código de empleado 11 o 30. */
    public async Task<IEnumerable<object>> ListadoClientesMadrid()
    {
        return await _context.Clientes
            .Include(p => p.Empleado)
           .Where(p => p.Ciudad.ToLower().Equals("madrid") && (p.Codigo_empleado_rep_ventas == 11 || p.Codigo_empleado_rep_ventas == 30))
           .Select(cliente => new
           {
               cliente.Nombre_cliente,
               cliente.Ciudad,
               cliente.Codigo_empleado_rep_ventas,
               cliente.Empleado.Nombre
           })
           .ToListAsync();
    }

    /* 12. Obtén un listado con el nombre de cada cliente y el nombre y apellido de su 
     representante de ventas. */
    public async Task<IEnumerable<object>> ListadoClientesRepVentas()
    {
        return await _context.Clientes
            .Include(p => p.Empleado)
            .Select(cliente => new
            {
                cliente.Nombre_cliente,
                cliente.Ciudad,
                cliente.Codigo_empleado_rep_ventas,
                cliente.Empleado.Nombre,
                cliente.Empleado.Apellido1
            })
            .ToListAsync();
    }

    /*     13. Muestra el nombre de los clientes que hayan realizado pagos junto con el 
    nombre de sus representantes de ventas. */
    public async Task<IEnumerable<object>> ListadoClientesRepVentasPagos()
    {
        return await _context.Pagos
           .Include(p => p.Cliente)
           .Include(p => p.Cliente.Empleado)
           .Select(cliente => new
           {
               cliente.Cliente.Nombre_cliente,
               cliente.Cliente.Ciudad,
               cliente.Cliente.Codigo_empleado_rep_ventas,
               cliente.Cliente.Empleado.Nombre,
               cliente.Cliente.Empleado.Apellido1
           })
           .ToListAsync();
    }
    /*     14. Muestra el nombre de los clientes que no hayan realizado pagos junto con 
    el nombre de sus representantes de ventas. */
    public async Task<IEnumerable<object>> ListadoClientesRepVentasNoPagos()
    {
        return await _context.Clientes
            .Include(c => c.Empleado)
            .Where(c => !c.Pagos.Any())
            .Select(cliente => new
            {
                cliente.Id,
                cliente.Nombre_cliente,
                cliente.Ciudad,
                cliente.Codigo_empleado_rep_ventas,
                Empleado = new
                {
                    cliente.Empleado.Nombre,
                    cliente.Empleado.Apellido1
                }
            })
            .ToListAsync();
    }

    /* 15. Devuelve el nombre de los clientes que han hecho pagos y el nombre de sus 
representantes junto con la ciudad de la oficina a la que pertenece el 
representante. */
    public async Task<IEnumerable<object>> ListadoClientesQueHanHechoPagos15()
    {
        return await _context.Clientes
            .Include(c => c.Empleado)
            .Where(c => c.Pagos.Any())
            .Select(cliente => new
            {
                cliente.Id,
                cliente.Nombre_cliente,
                cliente.Ciudad,
                cliente.Codigo_empleado_rep_ventas,
                Empleado = new
                {
                    cliente.Empleado.Nombre,
                    cliente.Empleado.Apellido1,
                    ciudad_oficina = cliente.Empleado.Oficina.Ciudad
                }
            })
            .ToListAsync();
    }


    /*  16. Devuelve el nombre de los clientes que no hayan hecho pagos y el nombre 
 de sus representantes junto con la ciudad de la oficina a la que pertenece el 
 representante. */
    public async Task<IEnumerable<object>> ListadoClientesQueNoHanHechoPagos16()
    {
        return await _context.Clientes
            .Include(c => c.Empleado)
            .Where(c => !c.Pagos.Any())
            .Select(cliente => new
            {
                cliente.Id,
                cliente.Nombre_cliente,
                cliente.Ciudad,
                cliente.Codigo_empleado_rep_ventas,
                Empleado = new
                {
                    cliente.Empleado.Nombre,
                    cliente.Empleado.Apellido1,
                    ciudad_oficina = cliente.Empleado.Oficina.Ciudad
                }
            })
            .ToListAsync();
    }

    /* 18. Devuelve el nombre de los clientes a los que no se les ha entregado a 
    tiempo un pedido. */
    public async Task<IEnumerable<object>> ListadoClientesQueNoHanEntregadoPedidos18()
    {
        return await _context.Pedidos
           .Include(c => c.Cliente)
           .Where(c => c.Fecha_entrega > c.Fecha_esperada)
           .Select(Pedido => new
           {
               Pedido.Id,
               Pedido.Cliente.Nombre_cliente,
               Pedido.Fecha_entrega,
               Pedido.Fecha_esperada
           })
           .ToListAsync();
    }

    /* 19. Devuelve un listado de las diferentes gamas de producto que ha comprado 
cada cliente. */
    public async Task<IEnumerable<object>> ListadoGamasCompradasPorCliente19()
    {
        return await _context.Clientes
        .Include(c => c.Pedidos)
        .Where(c => c.Pedidos.Any(p => p.Estado.ToLower().Equals("entregado")))
        .Select(c => new
        {
            cliente = new
            {
                c.Id,
                c.Nombre_cliente
            },
            gamas_compradas = c.Pedidos
                .Where(p => p.Estado.ToLower() == "entregado")
                .SelectMany(p => p.DetallePedidos)
                .Select(p => p.Producto)
                .Select(p => p.GamaProducto)
                .GroupBy(p => p.Id)
                .Select(gama => new
                {
                    Gama = gama.Key
                })

        }).ToListAsync()
        ;
    }

  /* 20.  Devuelve un listado que muestre solamente los clientes que no han
    realizado ningún pago. */
    public async Task<IEnumerable<Cliente>> ClientesSinPagos20()
    {
        var clientesSinPagos = await _context.Clientes
            .GroupJoin(_context.Pagos, // La tabla con la que hacemos el JOIN
                cliente => cliente.Id,    // La clave primaria de la tabla izquierda (Clientes)
                pago => pago.Codigo_cliente,   // La clave foránea de la tabla derecha (Pagos)
                (cliente, pagos) => new { Cliente = cliente, Pagos = pagos }) // Proyección de resultados
            .Where(c => !c.Pagos.Any()) // Filtrar solo aquellos clientes sin pagos
            .Select(c => c.Cliente)     // Seleccionar solo la información del cliente
            .ToListAsync();

        return clientesSinPagos;
    }

   /*  21. Devuelve un listado que muestre los clientes que no han realizado ningún 
pago y los que no han realizado ningún pedido. */
    public async Task<IEnumerable<object>> ClientesQueNoHanPagadoNiHanHechoPedido21 ()
    {
        return await _context.Clientes
        .Include(p => p.Pagos)
        .Include(p => p.Pedidos)
        .Where(p => !p.Pagos.Any())
        .Where(p => !p.Pedidos.Any())
        .Select(p => new 
        {
            p.Nombre_cliente
        })
        .ToListAsync();
    }


}