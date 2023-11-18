
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
}
