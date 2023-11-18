
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
        return await _context.Pagos
          .Include(p => p.Cliente)
          .Include(p => p.Cliente.Empleado)
          .Where(p =>!p.Cliente.Pagos.Any())
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

}