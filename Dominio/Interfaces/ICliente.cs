
using Dominio.Entities;

namespace Dominio.Interfaces;
public interface ICliente : IGenericRepoInt<Cliente>
{

    public Task<IEnumerable<object>> ListadoClientesEspañones();//consulta 1. Devuelve un listado con el nombre de los todos los clientes españoles

    /* 3. Devuelve un listado con el código de cliente de aquellos clientes que 
    realizaron algún pago en 2008. Tenga en cuenta que deberá eliminar 
    aquellos códigos de cliente que aparezcan repetidos. Resuelva la consulta: */
    public Task<IEnumerable<object>> ListadoClientesPagos2008();
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
    public Task<IEnumerable<object>> ClientesQueNoHanPagadoNiHanHechoPedido21 ();
}
