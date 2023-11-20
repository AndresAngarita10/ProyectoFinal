
using Dominio.Entities;
using Dominio.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistencia;

namespace Aplicacion.Repository;

public class ProductoRepository : GenericRepoStr<Producto>, IProducto
{
    protected readonly ApiContext _context;

    public ProductoRepository(ApiContext context) : base(context)
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
        .FirstOrDefaultAsync(p => p.Id.Equals(id));
    }

    /*  10. Devuelve un listado con todos los productos que pertenecen a la 
 gama Ornamentales y que tienen más de 100 unidades en stock. El listado 
 deberá estar ordenado por su precio de venta, mostrando en primer lugar 
 los de mayor precio. */
    public async Task<IEnumerable<object>> ListProductosGammaOrnamentales()
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

    /* 24. Devuelve un listado de los productos que nunca han aparecido en un 
    pedido. */
    public async Task<IEnumerable<object>> ProductosNuncaEnPedidos24()
    {
        return await _context.Productos
        .Include(p => p.DetallePedidos)
        .Where(p => !p.DetallePedidos.Any())
        .Select(prod => new
        {
            prod.Id,
            prod.Nombre
        }).ToListAsync();
    }

    /* 25.  Devuelve un listado de los productos que nunca han aparecido en un 
pedido. El resultado debe mostrar el nombre, la descripción y la imagen del 
producto. */
    public async Task<IEnumerable<object>> ProductosNuncaEnPedidosConNombreEImagen25()
    {
        return await _context.Productos
        .Include(p => p.DetallePedidos)
        .Where(p => !p.DetallePedidos.Any())
        .Select(prod => new
        {
            prod.Id,
            prod.Nombre,
            prod.Descripcion,
            prod.GamaProducto.Imagen
        }).ToListAsync();
    }

    /* 46. Devuelve el nombre del producto que tenga el precio de venta más caro */
    public async Task<object> ProductoPrecioVentaMAsCaro46()
    {
        return await _context.Productos
        .OrderByDescending(p => p.Precio_venta)
        .FirstOrDefaultAsync();
    }

    /* 47. Devuelve el nombre del producto del que se han vendido más unidades. 
    (Tenga en cuenta que tendrá que calcular cuál es el número total de 
    unidades que se han vendido de cada producto a partir de los datos de la 
    tabla detalle_pedido)
    */
    public async Task<object> ProductoMasVendidos47()
    {
        return await _context.Productos
       .Include(p => p.DetallePedidos)
       .OrderByDescending(p => p.DetallePedidos.Count())
       .Select(p => new 
       {
            nombre = p.Nombre
       })
       .FirstOrDefaultAsync();
    }

    /* 50. Devuelve el nombre del producto que tenga el precio de venta más caro.
 */
    public async Task<object> ProductoPrecioVentaMasCaro50()
    {
        return await _context.Productos
        .OrderByDescending(p => p.Precio_venta)
        .FirstOrDefaultAsync();
    }

    /* 53. Devuelve un listado de los productos que nunca han aparecido en un 
    pedido */
    public async Task<IEnumerable<object>> ProductosNuncaEnPedidos53()
    {
        return await _context.Productos
      .Where(p =>!p.DetallePedidos.Any())
      .Select(prod => new
        {
            prod.Id,
            prod.Nombre
        }).ToListAsync();
    }
}