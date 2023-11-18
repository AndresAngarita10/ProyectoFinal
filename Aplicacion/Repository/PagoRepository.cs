
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
}