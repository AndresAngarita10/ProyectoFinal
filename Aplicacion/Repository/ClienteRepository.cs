
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
    public async Task<(int totalRegistros, object registros)> ListadoClientesEspañones(int pageIndez, int pageSize, string search) // 1
    {
        var query = (
             _context.Clientes
                .Where(p => p.Pais.ToLower() == "spain")
                .Select(cliente => new
                {
                    cliente.Nombre_cliente,
                    cliente.Pais
                })
            );

        if (!string.IsNullOrEmpty(search))
        {
            query = query.Where(p => p.Nombre_cliente.ToLower().Contains(search));
        }

        query = query.OrderBy(p => p.Nombre_cliente);
        var totalRegistros = await query.CountAsync();
        var registros = await query
            .Skip((pageIndez - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();

        return (totalRegistros, registros);
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

    public async Task<(int totalRegistros, object registros)> ListadoClientesPagos2008(int pageIndez, int pageSize, string search) // 3
    {
        var query = (
             _context.Pagos
            .Include(p => p.Cliente)
            .Where(p => p.Fecha_pago.Year == 2008)
            .Select(cliente => new
            {
                Codigo = cliente.Codigo_cliente,
                Nombre = cliente.Cliente.Nombre_cliente
            })
            );

        if (!string.IsNullOrEmpty(search))
        {
            query = query.Where(p => p.Nombre.ToLower().Contains(search));
        }

        query = query.OrderBy(p => p.Nombre);
        var totalRegistros = await query.CountAsync();
        var registros = await query
            .Skip((pageIndez - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();

        return (totalRegistros, registros);
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
    public async Task<IEnumerable<object>> ClientesQueNoHanPagadoNiHanHechoPedido21()
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

    /*  27. Devuelve un listado con los clientes que han realizado algún pedido pero no 
 han realizado ningún pago. */
    public async Task<IEnumerable<Cliente>> ClientesConPedidoQueNoHanPagado27()
    {
        return await _context.Clientes
        .Where(c => c.Pedidos.Any())
        .Where(c => !c.Pagos.Any())
        .ToListAsync();
    }

    /*  30. ¿Cuántos clientes tiene cada país? */
    public async Task<object> ClientesPorPais30()
    {
        return await _context.Clientes
        .GroupBy(c => c.Pais)
        .Select(cl => new
        {
            cl.Key,
            Cantidad = cl.Count()
        }).ToListAsync();
    }

    /* 33. ¿Cuántos clientes existen con domicilio en la ciudad de Madrid? */
    public async Task<object> ClientesConDomicilioEnMadrid33()
    {
        return await _context.Clientes
        .GroupBy(c => c.Ciudad)
        .Where(c => c.Key.Equals("Madrid"))
        .Select(cli => new
        {
            Ciudad = cli.Key,
            Cantidad = cli.Count()
        }).FirstOrDefaultAsync();
    }

    /* 34. ¿Calcula cuántos clientes tiene cada una de las ciudades que empiezan por M? */
    public async Task<IEnumerable<object>> ClientesPorCiudadesConMInicial34()
    {
        return await _context.Clientes
        .GroupBy(c => c.Ciudad)
        .Where(c => c.Key.ToLower().StartsWith("m"))
        .Select(cli => new
        {
            Ciudad = cli.Key,
            Cantidad = cli.Count()
        }).ToListAsync();
    }

    /* 36. Calcula el número de clientes que no tiene asignado representante de 
 ventas. */
    public async Task<object> NumeroClientesSinRepresentanteVentas36()
    {
        var NClientes = await _context.Clientes
        .Where(cl => cl.Codigo_empleado_rep_ventas == null)
       .CountAsync();
        return new
        {
            clientes_sin_representante = NClientes
        };
    }

    /* 37.. Calcula la fecha del primer y último pago realizado por cada uno de los 
clientes. El listado deberá mostrar el nombre y los apellidos de cada cliente. */
    public async Task<IEnumerable<object>> PrimerYUltimoPagoPorCliente37()
    {
        var resultados = await _context.Clientes
            .Select(cliente => new
            {
                CodigoCliente = cliente.Id,
                Nombre = cliente.Nombre_cliente,
                PrimerPago = cliente.Pagos.OrderBy(p => p.Fecha_pago).First(),
                UltimoPago = cliente.Pagos.OrderByDescending(p => p.Fecha_pago).First()
            })
            .ToListAsync();

        return resultados;
    }

    /* 45. Devuelve el nombre del cliente con mayor límite de crédito. */
    public async Task<object> ClienteConMayorLimiteCredito45()
    {
        return await _context.Clientes
       .OrderByDescending(c => c.Limite_credito)
       .Select(c => new
       {
           nombre = c.Nombre_cliente
       })
       .FirstOrDefaultAsync();
    }

    /* 48. Los clientes cuyo límite de crédito sea mayor que los pagos que haya 
realizado. (Sin utilizar INNER JOIN). */
    public async Task<IEnumerable<object>> ClienteConMayorLimiteCreditoALosPagos48()
    {
        return await _context.Clientes
        .Where(c => c.Pagos.Any())
        .Where(p => p.Pagos.Sum(p => p.Total) < p.Limite_credito)
        .Select(c => new
        {
            nombre = c.Nombre_cliente,
            pagos = c.Pagos.Sum(p => p.Total),
            limite_creidot = c.Limite_credito
        })
        .ToListAsync();
    }

    /* 49. Devuelve el nombre del cliente con mayor límite de crédito. */
    public async Task<object> ClienteConMayorLimiteCredito49()
    {
        return await _context.Clientes
      .OrderByDescending(c => c.Limite_credito)
      .Select(c => new
      {
          nombre = c.Nombre_cliente,
          limite_credito = c.Limite_credito
      })
      .FirstOrDefaultAsync();
    }

    /* 51. Devuelve un listado que muestre solamente los clientes que no han 
    realizado ningún pago.
    */
    public async Task<IEnumerable<Cliente>> ClienteNoHanHechoPagos51()
    {
        return await _context.Clientes
       .Where(c => !c.Pagos.Any())
       .OrderBy(c => c.Limite_credito)
       .ToListAsync();

    }

    /* 52. Devuelve un listado que muestre solamente los clientes que sí han realizado 
algún pago. */
    public async Task<IEnumerable<Cliente>> ClienteSiHanHechoPagos52()
    {
        return await _context.Clientes
       .Where(c => c.Pagos.Any())
       .OrderBy(c => c.Limite_credito)
       .ToListAsync();
    }

    /* 55. Devuelve un listado que muestre solamente los clientes que no han 
    realizado ningún pago. */
    public async Task<IEnumerable<Cliente>> ClienteNoHanHechoPagos55()
    {
        return await _context.Clientes
        .Where(c => !c.Pagos.Any())
        .OrderBy(c => c.Limite_credito)
        .ToListAsync();
    }

    /* 56. Devuelve un listado que muestre solamente los clientes que sí han realizado 
    algún pago. */
    public async Task<IEnumerable<Cliente>> ClienteSiHanHechoPagos56()
    {
        return await _context.Clientes
       .Where(c => c.Pagos.Any())
       .OrderBy(c => c.Limite_credito)
       .ToListAsync();
    }

    /* 57. Devuelve el listado de clientes indicando el nombre del cliente y cuántos 
    pedidos ha realizado. Tenga en cuenta que pueden existir clientes que no 
    han realizado ningún pedido. */
    public async Task<IEnumerable<object>> ClientesYPedidos57()
    {
        return await _context.Clientes
        .Include(c => c.Pedidos)
        .Select(c => new
        {
            c.Nombre_cliente,
            pedido = c.Pedidos.Count()
        }).ToListAsync();
    }

    /* 58. Devuelve el nombre de los clientes que hayan hecho pedidos en 2008 
    ordenados alfabéticamente de menor a mayor */
    public async Task<IEnumerable<object>> ClientesYPedidosEn200858()
    {
        return await _context.Clientes
       .Where(c => c.Pedidos.Any(p => p.Fecha_pedido.Year == 2008))
       .Select(c => new 
       {
        c.Nombre_cliente
       })
       .OrderBy(c => c.Nombre_cliente)
       .ToListAsync();
    }

    /* 59. Devuelve el nombre del cliente, el nombre y primer apellido de su 
    representante de ventas y el número de teléfono de la oficina del 
    representante de ventas, de aquellos clientes que no hayan realizado ningún 
    pago */
    public async Task<IEnumerable<object>> ClientesYPedidosConRepresentanteVentas59()
    {
        return await _context.Clientes
      .Where(c => !c.Pagos.Any())
      //.Where(c => c.Codigo_empleado_rep_ventas!= null)
      .Select(c => new
      {
          c.Nombre_cliente,
          Representante_nombre = c.Empleado.Nombre,
          Representante_apellido = c.Codigo_empleado_rep_ventas,
          Oficina = c.Empleado.Oficina.Id
      })
      .ToListAsync();
    }

    /* 60. Devuelve el listado de clientes donde aparezca el nombre del cliente, el 
    nombre y primer apellido de su representante de ventas y la ciudad donde 
    está su oficina. */
    public async Task<IEnumerable<object>> ClientesYPedidosConRepresentanteVentas60()
    {
        return await _context.Clientes
        .Where(c => c.Codigo_empleado_rep_ventas != null)
        .Select(c => new
        {
            c.Nombre_cliente,
            Representante_nombre = c.Empleado.Nombre,
            Representante_apellido = c.Empleado.Apellido1,
            Oficina = c.Empleado.Oficina.Id,
            Ciudad = c.Empleado.Oficina.Ciudad
        })
        .ToListAsync();
    }

}