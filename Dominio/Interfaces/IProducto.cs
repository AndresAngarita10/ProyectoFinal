
using Dominio.Entities;

namespace Dominio.Interfaces;

public interface IProducto : IGenericRepoStr<Producto>
{
/*  10. Devuelve un listado con todos los productos que pertenecen a la 
gama Ornamentales y que tienen más de 100 unidades en stock. El listado 
deberá estar ordenado por su precio de venta, mostrando en primer lugar 
los de mayor precio. */
    public Task<IEnumerable<object>> ListProductosGammaOrnamentales ();
}
