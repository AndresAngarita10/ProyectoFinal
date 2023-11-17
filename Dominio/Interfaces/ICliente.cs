
using Dominio.Entities;

namespace Dominio.Interfaces;
public interface ICliente : IGenericRepoInt<Cliente>
{
    
    public Task<IEnumerable<object>> ListadoClientesEspañones();//consulta 1. Devuelve un listado con el nombre de los todos los clientes españoles
    
    /* 3. Devuelve un listado con el código de cliente de aquellos clientes que 
    realizaron algún pago en 2008. Tenga en cuenta que deberá eliminar 
    aquellos códigos de cliente que aparezcan repetidos. Resuelva la consulta: */
    public Task<IEnumerable<object>> ListadoClientesPagos2008();
}
