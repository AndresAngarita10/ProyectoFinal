
using Dominio.Entities;

namespace Dominio.Interfaces;

public interface IProducto : IGenericRepoStr<Producto>
{
/*  10. Devuelve un listado con todos los productos que pertenecen a la 
gama Ornamentales y que tienen más de 100 unidades en stock. El listado 
deberá estar ordenado por su precio de venta, mostrando en primer lugar 
los de mayor precio. */
    public Task<IEnumerable<object>> ListProductosGammaOrnamentales ();
    /* 24. Devuelve un listado de los productos que nunca han aparecido en un 
    pedido. */
    public Task<IEnumerable<object>> ProductosNuncaEnPedidos24();
      /* 25.  Devuelve un listado de los productos que nunca han aparecido en un 
pedido. El resultado debe mostrar el nombre, la descripción y la imagen del 
producto. */
    public Task<IEnumerable<object>> ProductosNuncaEnPedidosConNombreEImagen25();
}
