
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
}