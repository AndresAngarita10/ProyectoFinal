
using Dominio.Entities;

namespace Dominio.Interfaces;
public interface ICliente : IGenericRepoInt<Cliente>
{

    public Task<IEnumerable<object>> ListadoClientesEspañones();//consulta 1. Devuelve un listado con el nombre de los todos los clientes españoles
    public abstract Task<(int totalRegistros,object registros)> ListadoClientesEspañones(int pageIndez, int pageSize, string search) ;// 1

    /* 3. Devuelve un listado con el código de cliente de aquellos clientes que 
    realizaron algún pago en 2008. Tenga en cuenta que deberá eliminar 
    aquellos códigos de cliente que aparezcan repetidos. Resuelva la consulta: */
    public Task<IEnumerable<object>> ListadoClientesPagos2008();
    public abstract Task<(int totalRegistros, object registros)> ListadoClientesPagos2008(int pageIndez, int pageSize, string search); // 3

    /*  11. Devuelve un listado con todos los clientes que sean de la ciudad de Madrid y 
cuyo representante de ventas tenga el código de empleado 11 o 30. */
    public Task<IEnumerable<object>> ListadoClientesMadrid();
    /* 12. Obtén un listado con el nombre de cada cliente y el nombre y apellido de su 
    representante de ventas. */
    public Task<IEnumerable<object>> ListadoClientesRepVentas();
    /*     13. Muestra el nombre de los clientes que hayan realizado pagos junto con el 
nombre de sus representantes de ventas. */
    public Task<IEnumerable<object>> ListadoClientesRepVentasPagos();
    /*     14. Muestra el nombre de los clientes que no hayan realizado pagos junto con 
el nombre de sus representantes de ventas. */
    public Task<IEnumerable<object>> ListadoClientesRepVentasNoPagos();
    /* 15. Devuelve el nombre de los clientes que han hecho pagos y el nombre de sus 
representantes junto con la ciudad de la oficina a la que pertenece el 
representante. */
    public Task<IEnumerable<object>> ListadoClientesQueHanHechoPagos15();
    /*  16. Devuelve el nombre de los clientes que no hayan hecho pagos y el nombre 
de sus representantes junto con la ciudad de la oficina a la que pertenece el 
representante. */
    public Task<IEnumerable<object>> ListadoClientesQueNoHanHechoPagos16();
    /* 18. Devuelve el nombre de los clientes a los que no se les ha entregado a 
tiempo un pedido. */
    public Task<IEnumerable<object>> ListadoClientesQueNoHanEntregadoPedidos18();
    /* 19. Devuelve un listado de las diferentes gamas de producto que ha comprado 
cada cliente. */
    public Task<IEnumerable<object>> ListadoGamasCompradasPorCliente19();
    /* 20.  Devuelve un listado que muestre solamente los clientes que no han
   realizado ningún pago. */
    public Task<IEnumerable<Cliente>> ClientesSinPagos20();
    /*  21. Devuelve un listado que muestre los clientes que no han realizado ningún 
pago y los que no han realizado ningún pedido. */
    public Task<IEnumerable<object>> ClientesQueNoHanPagadoNiHanHechoPedido21();
    /*  27. Devuelve un listado con los clientes que han realizado algún pedido pero no 
han realizado ningún pago. */
    public Task<IEnumerable<Cliente>> ClientesConPedidoQueNoHanPagado27();
    /*  30. ¿Cuántos clientes tiene cada país? */
    public Task<object> ClientesPorPais30();
    /* 33. ¿Cuántos clientes existen con domicilio en la ciudad de Madrid? */
    public Task<object> ClientesConDomicilioEnMadrid33();
    /* 34. ¿Calcula cuántos clientes tiene cada una de las ciudades que empiezan por M? */
    public Task<IEnumerable<object>> ClientesPorCiudadesConMInicial34();
    /* 36. Calcula el número de clientes que no tiene asignado representante de 
 ventas. */
    public Task<object> NumeroClientesSinRepresentanteVentas36();
    /* 37.. Calcula la fecha del primer y último pago realizado por cada uno de los 
clientes. El listado deberá mostrar el nombre y los apellidos de cada cliente. */
    public Task<IEnumerable<object>> PrimerYUltimoPagoPorCliente37();
    /* 45. Devuelve el nombre del cliente con mayor límite de crédito. */
    public Task<object> ClienteConMayorLimiteCredito45 ();
    
    /* 48. Los clientes cuyo límite de crédito sea mayor que los pagos que haya 
realizado. (Sin utilizar INNER JOIN). */
    public Task<IEnumerable<object>> ClienteConMayorLimiteCreditoALosPagos48();
    /* 49. Devuelve el nombre del cliente con mayor límite de crédito. */
    public Task<object> ClienteConMayorLimiteCredito49();
     /* 51. Devuelve un listado que muestre solamente los clientes que no han 
    realizado ningún pago.
    */
    public Task<IEnumerable<Cliente>> ClienteNoHanHechoPagos51();
    /* 52. Devuelve un listado que muestre solamente los clientes que sí han realizado 
algún pago. */
    public Task<IEnumerable<Cliente>> ClienteSiHanHechoPagos52();
    /* 55. Devuelve un listado que muestre solamente los clientes que no han 
    realizado ningún pago. */
    public Task<IEnumerable<Cliente>> ClienteNoHanHechoPagos55();
    /* 56. Devuelve un listado que muestre solamente los clientes que sí han realizado 
    algún pago. */
    public Task<IEnumerable<Cliente>> ClienteSiHanHechoPagos56();
    /* 57. Devuelve el listado de clientes indicando el nombre del cliente y cuántos 
    pedidos ha realizado. Tenga en cuenta que pueden existir clientes que no 
    han realizado ningún pedido. */
    public Task<IEnumerable<object>> ClientesYPedidos57();
    /* 58. Devuelve el nombre de los clientes que hayan hecho pedidos en 2008 
    ordenados alfabéticamente de menor a mayor */
    public Task<IEnumerable<object>> ClientesYPedidosEn200858();
    
    /* 59. Devuelve el nombre del cliente, el nombre y primer apellido de su 
    representante de ventas y el número de teléfono de la oficina del 
    representante de ventas, de aquellos clientes que no hayan realizado ningún 
    pago */
    public Task<IEnumerable<object>> ClientesYPedidosConRepresentanteVentas59();
    
    /* 60. Devuelve el listado de clientes donde aparezca el nombre del cliente, el 
    nombre y primer apellido de su representante de ventas y la ciudad donde 
    está su oficina. */
    public Task<IEnumerable<object>> ClientesYPedidosConRepresentanteVentas60();
}
