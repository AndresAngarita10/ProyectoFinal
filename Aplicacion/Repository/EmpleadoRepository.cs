
using Dominio.Entities;
using Dominio.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistencia;

namespace Aplicacion.Repository;

public class EmpleadoRepository : GenericRepoInt<Empleado>, IEmpleado
{
    protected readonly ApiContext _context;

    public EmpleadoRepository(ApiContext context) : base(context)
    {
        _context = context;
    }

    public override async Task<IEnumerable<Empleado>> GetAllAsync()
    {
        return await _context.Empleados
            .ToListAsync();
    }

    public override async Task<Empleado> GetByIdAsync(int id)
    {
        return await _context.Empleados
        .FirstOrDefaultAsync(p => p.Id == id);
    }

    /* 17. Devuelve un listado que muestre el nombre de cada empleados, el nombre 
de su jefe y el nombre del jefe de sus jefe. */
    public async Task<IEnumerable<object>> ListadoEmpleadoConJefes17()
    {
        var empleados = await _context.Empleados
            .Include(e => e.Jefe)
            .Where(e => e.Codigo_jefe != null && e.Jefe != null && e.Jefe.Jefe != null)
            .Select(empleado => new
            {
                empleado.Id,
                empleado.Nombre,
                jefe = new
                {
                    empleado.Jefe.Id,
                    empleado.Jefe.Nombre,
                    jefe = new
                    {
                        empleado.Jefe.Jefe.Id,
                        empleado.Jefe.Jefe.Nombre
                    }
                }
            }).ToListAsync();

        return empleados;
    }

    public async Task<(int totalRegistros, object registros)> ListadoEmpleadoConJefes17(int pageIndez, int pageSize, string search) // 17
    {
        var query = (
             _context.Empleados
            .Include(e => e.Jefe)
            .Where(e => e.Codigo_jefe != null && e.Jefe != null && e.Jefe.Jefe != null)
            .Select(empleado => new
            {
                empleado.Id,
                empleado.Nombre,
                jefe = new
                {
                    empleado.Jefe.Id,
                    empleado.Jefe.Nombre,
                    jefe = new
                    {
                        empleado.Jefe.Jefe.Id,
                        empleado.Jefe.Jefe.Nombre
                    }
                }
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

    /*    22. Devuelve un listado que muestre solamente los empleados que no tienen un 
   cliente asociado junto con los datos de la oficina donde trabajan. */
    public async Task<IEnumerable<object>> ListadoEmpleadoSinCliente22()
    {
        var empleados = await _context.Empleados
           .Include(e => e.Clientes)
           .Where(e => !e.Clientes.Any())
           .Select(empleado => new
           {
               empleado.Id,
               empleado.Nombre,
               empleado.Clientes,
               oficina = new
               {
                   empleado.Oficina.Id,
               }
           }).ToListAsync();

        return empleados;
    }

    public async Task<(int totalRegistros, object registros)> ListadoEmpleadoSinCliente22(int pageIndez, int pageSize, string search) // 22
    {
        var query = (
            _context.Empleados
            .Include(e => e.Clientes)
            .Where(e => !e.Clientes.Any())
            .Select(empleado => new
            {
                empleado.Id,
                empleado.Nombre,
                empleado.Clientes,
                oficina = new
                {
                    empleado.Oficina.Id,
                }
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

    /* 23. Devuelve un listado que muestre los empleados que no tienen una oficina 
asociada y los que no tienen un cliente asociado. */
    public async Task<IEnumerable<object>> ListadoEmpleadoSinClienteNiOficina23()
    {
        var empleados = await _context.Empleados
           .Include(e => e.Clientes)
           .Where(e => !e.Clientes.Any())
           .Where(e => e.Codigo_oficina == null)
           .Select(empleado => new
           {
               empleado.Id,
               empleado.Nombre,
               empleado.Clientes,
               oficina = new
               {
                   empleado.Oficina.Id,
               }
           }).ToListAsync();

        return empleados;
    }

    /* 26. Devuelve las oficinas donde no trabajan ninguno de los empleados que 
hayan sido los representantes de ventas de algún cliente que haya realizado 
la compra de algún producto de la gama Frutales. */
    public async Task<IEnumerable<object>> ListadoEmpleadoSinOficinaConClienteGamaFrutales26()
    {
        var oficinas = await _context.Empleados
           .Where(e => e.Clientes.Any())
           .Where(e => e.Codigo_oficina == null)
           .Where(e => e.Clientes.Any(c => c.Pedidos.Any(p => p.DetallePedidos.Any(d => d.Producto.GamaProducto.Id.Equals("Frutales")))))
           .Select(empleado => new
           {
               oficina = new
               {
                   empleado.Oficina.Id,
               }
           }).ToListAsync();

        return oficinas;
    }

    /* 28 . Devuelve un listado con los datos de los empleados que no tienen clientes 
 asociados y el nombre de su jefe asociado. */
    public async Task<IEnumerable<object>> ListadoEmpleadoSinClienteYJefe28()
    {
        return await _context.Empleados
        .Where(e => !e.Clientes.Any())
        .Select(em => new
        {
            em.Id,
            em.Nombre,
            em.Apellido1,
            em.Apellido2,
            nombre_jefe = em.Jefe.Nombre
        }).ToListAsync();
    }

    /*  29. ¿Cuántos empleados hay en la compañía? */
    public async Task<int> NumeroEmpleados29()
    {
        var numeroEmpleados = await _context.Empleados
            .Select(e => e.Nombre)
            .CountAsync();
        Console.WriteLine($"Número de empleados: {numeroEmpleados}");
        return numeroEmpleados;
    }

    /* 35. Devuelve el nombre de los representantes de ventas y el número de clientes 
al que atiende cada uno. */
    public async Task<IEnumerable<object>> NombreRepVentasConNumClientes35()
    {
        return await _context.Empleados
          .Where(e => e.Clientes.Any())
          .Select(e => new
          {
              nombre_rep_ventas = e.Nombre,
              numero_clientes = e.Clientes.Count
          })
          .ToListAsync();
    }

    /* 54. Devuelve el nombre, apellidos, puesto y teléfono de la oficina de aquellos 
    empleados que no sean representante de ventas de ningún cliente.
    */
    public async Task<IEnumerable<object>> EmpleadosSinClientes54()
    {
        return await _context.Empleados
          .Where(e => !e.Clientes.Any())
          .Where(e => e.Puesto != "Representante Ventas")
          .Select(e => new
          {
              nombre = e.Nombre,
              apellido1 = e.Apellido1,
              apellido2 = e.Apellido2,
              puesto = e.Puesto,
              extension = e.Extension,
              oficina = e.Oficina.Id
          })
          .ToListAsync();
    }

    /* 61. Devuelve el nombre, apellidos, puesto y teléfono de la oficina de aquellos 
    empleados que no sean representante de ventas de ningún cliente. */
    public async Task<IEnumerable<object>> EmpleadosSinClientes61()
    {
        return await _context.Empleados
         .Where(e => !e.Clientes.Any())
         .Select(e => new
         {
             nombre = e.Nombre,
             apellido1 = e.Apellido1,
             apellido2 = e.Apellido2,
             puesto = e.Puesto,
             telefono_oficina = e.Oficina.Telefono,
             oficina = e.Oficina.Id,
             ciudad_oficina = e.Oficina.Ciudad
         })
         .ToListAsync();
    }

}
