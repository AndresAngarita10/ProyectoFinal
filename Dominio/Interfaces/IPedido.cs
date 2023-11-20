
using Dominio.Entities;

namespace Dominio.Interfaces;

public interface IPedido : IGenericRepoInt<Pedido>
{
    //2. Devuelve un listado con los distintos estados por los que puede pasar un pedido.
    public Task<IEnumerable<object>> DistintosEstadosPedido();
    /* 4. Devuelve un listado con el código de pedido, código de cliente, fecha 
esperada y fecha de entrega de los pedidos que no han sido entregados a 
tiempo. */
    public Task<IEnumerable<object>> ListadoPedidosNoEntregadosATiempo();
    /*  5. Devuelve un listado con el código de pedido, código de cliente, fecha 
 esperada y fecha de entrega de los pedidos cuya fecha de entrega ha sido al 
 menos dos días antes de la fecha esperada */
    public Task<IEnumerable<object>> DosDiasAntesFechaEsperada();
    //6. devuelve un listado de todos los pedidos que fueron rechazados en 2009.
    public Task<IEnumerable<object>> PedidosRechazadosEn2009();
    /*  7 Devuelve un listado de todos los pedidos que han sido entregados en el 
mes de enero de cualquier año. */
    public Task<IEnumerable<object>> PedidosEntregadosEnEnero();
    /* 32. ¿Cuántos pedidos hay en cada estado? Ordena el resultado de forma 
descendente por el número de pedidos. */
    public Task<IEnumerable<object>> NumeroPedidosCadaEstado32();
    /* 38. Calcula el número de productos diferentes que hay en cada uno de los 
pedidos. */
    public Task<IEnumerable<object>> NumeroProductosPedidos38();
     /* 39. Calcula la suma de la cantidad total de todos los productos que aparecen en 
cada uno de los pedidos. */
    public Task<IEnumerable<object>> CantidadTotalProductosPedidos39();
     /* 40. Devuelve un listado de los 20 productos más vendidos y el número total de 
unidades que se han vendido de cada uno. El listado deberá estar ordenado 
por el número total de unidades vendidas.
 */
    public Task<IEnumerable<object>> ProductosMasVendidos40();
    /* 41.. La misma información que en la pregunta anterior, pero agrupada por 
código de producto. */
    public Task<IEnumerable<object>> ProductosMasVendidosporCodigoProducto41();
    /* 42. La misma información que en la pregunta anterior, pero agrupada por 
código de producto filtrada por los códigos que empiecen por OR */
    public Task<IEnumerable<object>> ProductosMasVendidosporCodigoProductoYFiltrada42();
    /* 43. Lista las ventas totales de los productos que hayan facturado más de 3000 
euros. Se mostrará el nombre, unidades vendidas, total facturado y total 
facturado con impuestos (21% IVA). */
    public Task<IEnumerable<object>> ProductosMasVendidos43();
}
