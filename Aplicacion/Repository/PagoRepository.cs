
using Dominio.Entities;
using Dominio.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistencia;

namespace Aplicacion.Repository;

public class PagoRepository : GenericRepoStr<Pago>, IPago
{
    protected readonly ApiContext _context;

    public PagoRepository(ApiContext context) : base(context)
    {
        _context = context;
    }

    public override async Task<IEnumerable<Pago>> GetAllAsync()
    {
        return await _context.Pagos
            .ToListAsync();
    }

    public override async Task<Pago> GetByIdAsync(int id)
    {
        return await _context.Pagos
        .FirstOrDefaultAsync(p => p.Id.Equals(id));
    }
    /*  8. Devuelve un listado con todos los pagos que se realizaron en el 
 año 2008 mediante Paypal. Ordene el resultado de mayor a menor. */
    public async Task<IEnumerable<object>> ListadoConPagos2008YPaypal()
    {
        return await _context.Pagos
            .Where(p => p.Fecha_pago.Year == 2008 && p.Forma_pago.ToLower().Equals("paypal"))
            .Select(pago => new
            {
                pago.Id,
                pago.Fecha_pago,
                pago.Forma_pago
            })
            .ToListAsync();
    }
    public async Task<(int totalRegistros, object registros)> ListadoConPagos2008YPaypal(int pageIndez, int pageSize, string search) 
    {
        var query = (
            _context.Pagos
            .Where(p => p.Fecha_pago.Year == 2008 && p.Forma_pago.ToLower().Equals("paypal"))
            .Select(pago => new
            {
                pago.Id,
                pago.Fecha_pago,
                pago.Forma_pago
            })
            );

        if (!string.IsNullOrEmpty(search))
        {
            query = query.Where(p => p.Id.ToLower().Contains(search));
        }

        query = query.OrderBy(p => p.Id);
        var totalRegistros = await query.CountAsync();
        var registros = await query
            .Skip((pageIndez - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();

        return (totalRegistros, registros);
    }

    public async Task<(int totalRegistros, object registros)> ListadoConPagos2008YPaypal(int pageIndez, int pageSize, string search) // 17
    {
        var query = (
             _context.Pagos
            .Where(p => p.Fecha_pago.Year == 2008 && p.Forma_pago.ToLower().Equals("paypal"))
            .Select(pago => new
            {
                pago.Id,
                pago.Fecha_pago,
                pago.Forma_pago
            })
            );

        if (!string.IsNullOrEmpty(search))
        {
            query = query.Where(p => p.Id.ToLower().Contains(search));
        }

        query = query.OrderBy(p => p.Id);
        var totalRegistros = await query.CountAsync();
        var registros = await query
            .Skip((pageIndez - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();

        return (totalRegistros, registros);
    }

    /*     9. Devuelve un listado con todas las formas de pago que aparecen en la 
    tabla pago. Tenga en cuenta que no deben aparecer formas de pago 
    repetidas. */
    public async Task<IEnumerable<object>> ListadoConTodasLasFormasDePago()
    {
        return await _context.Pagos
            .GroupBy(p => p.Forma_pago)
            .Select(pago => new
            {
                pago.Key
            })
            .ToListAsync();
    }
<<<<<<< HEAD
    public async Task<(int totalRegistros, object registros)> ListadoConTodasLasFormasDePago(int pageIndez, int pageSize, string search) 
=======
    public async Task<(int totalRegistros, object registros)> ListadoConTodasLasFormasDePago(int pageIndez, int pageSize, string search) // 17
>>>>>>> 8538d34da283e7ef8d7ec7294af94aee6f1d892a
    {
        var query = (
            _context.Pagos
            .GroupBy(p => p.Forma_pago)
            .Select(pago => new
            {
                pago.Key
            })
            );

        if (!string.IsNullOrEmpty(search))
        {
            query = query.Where(p => p.Key.ToLower().Contains(search));
        }

        query = query.OrderBy(p => p.Key);
        var totalRegistros = await query.CountAsync();
        var registros = await query
            .Skip((pageIndez - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();

        return (totalRegistros, registros);
    }

    /* 31. ¿Cuál fue el pago medio en 2009? */
    public async Task<object> PagoMedioEn200931()
    {
        var pagoMedio = await _context.Pagos
            .Where(p => p.Fecha_pago.Year == 2009)
            .AverageAsync(p => p.Total);
        return new
        {
            PagoMedio = pagoMedio
        };
    }

    /* 44. Muestre la suma total de todos los pagos que se realizaron para cada uno 
de los años que aparecen en la tabla pagos. */
    public async Task<IEnumerable<object>> SumaTotalDeTodosLosPagosParaTodosLosAños44()
    {
        return await _context.Pagos
           .GroupBy(p => p.Fecha_pago.Year)
           .Select(pago => new
           {
               año = pago.Key,
               SumaTotal = pago.Sum(p => p.Total)
           })
           .ToListAsync();
    }

}