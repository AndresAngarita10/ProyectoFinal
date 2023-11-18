
using Dominio.Entities;
using Dominio.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistencia;

namespace Aplicacion.Repository;

public class ProductoRepository : GenericRepoStr<Producto>, IProducto
{
    protected readonly ApiContext _context;
    
    public ProductoRepository(ApiContext context) : base (context)
    {
        _context = context;
    }

    public override async Task<IEnumerable<Producto>> GetAllAsync()
    {
        return await _context.Productos
            .ToListAsync();
    }

    public override async Task<Producto> GetByIdAsync(string id)
    {
        return await _context.Productos
        .FirstOrDefaultAsync(p =>  p.Id.Equals(id));
    }

   /*  10. Devuelve un listado con todos los productos que pertenecen a la 
gama Ornamentales y que tienen más de 100 unidades en stock. El listado 
deberá estar ordenado por su precio de venta, mostrando en primer lugar 
los de mayor precio. */
    public async Task<IEnumerable<object>> ListProductosGammaOrnamentales ()
    {
        return await _context.Productos
          .Where(p => p.GamaIdFk.ToLower().Equals("ornamentales"))
          .Where(p => p.Cantidad_en_stock > 100)
          .OrderByDescending(p => p.Precio_venta)
          .Select(prod => new 
          {
            prod.Id,
            prod.Nombre,
            prod.Precio_venta,
            prod.Cantidad_en_stock,
            prod.GamaIdFk,
          })
          .ToListAsync();
    }
}