
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
}
