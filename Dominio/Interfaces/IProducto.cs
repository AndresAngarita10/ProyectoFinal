
using Dominio.Entities;

namespace Dominio.Interfaces;

public interface IProducto : IGenericRepoStr<Producto>
{
    public abstract Task<(int totalRegistros, object registros)> ListProductosGammaOrnamentales(int pageIndez, int pageSize, string search); // 

    public abstract Task<(int totalRegistros, object registros)> ProductosNuncaEnPedidos24(int pageIndez, int pageSize, string search); // 

/*  10. Devuelve un listado con todos los productos que pertenecen a la 
gama Ornamentales y que tienen más de 100 unidades en stock. El listado 
deberá estar ordenado por su precio de venta, mostrando en primer lugar 
los de mayor precio. */
    public Task<IEnumerable<object>> ListProductosGammaOrnamentales();
    /* 24. Devuelve un listado de los productos que nunca han aparecido en un 
    pedido. */
    public Task<IEnumerable<object>> ProductosNuncaEnPedidos24();
    /* 25.  Devuelve un listado de los productos que nunca han aparecido en un 
pedido. El resultado debe mostrar el nombre, la descripción y la imagen del 
producto. */
    public Task<IEnumerable<object>> ProductosNuncaEnPedidosConNombreEImagen25();
    /* 46. Devuelve el nombre del producto que tenga el precio de venta más caro */
    public Task<Producto> ProductoPrecioVentaMAsCaro46();
    /* 47. Devuelve el nombre del producto del que se han vendido más unidades. 
    (Tenga en cuenta que tendrá que calcular cuál es el número total de 
    unidades que se han vendido de cada producto a partir de los datos de la 
    tabla detalle_pedido)
    */
    public Task<object> ProductoMasVendidos47();
    /* 50. Devuelve el nombre del producto que tenga el precio de venta más caro.
 */
    public Task<Producto> ProductoPrecioVentaMasCaro50();
    /* 53. Devuelve un listado de los productos que nunca han aparecido en un 
    pedido */
    public Task<IEnumerable<object>> ProductosNuncaEnPedidos53();
}
