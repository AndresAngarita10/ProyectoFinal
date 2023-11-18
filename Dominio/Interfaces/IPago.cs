
using Dominio.Entities;

namespace Dominio.Interfaces;

public interface IPago : IGenericRepoStr<Pago>
{
    /*  8. Devuelve un listado con todos los pagos que se realizaron en el 
    año 2008 mediante Paypal. Ordene el resultado de mayor a menor. */
    public Task<IEnumerable<object>> ListadoConPagos2008YPaypal();
     /*     9. Devuelve un listado con todas las formas de pago que aparecen en la 
    tabla pago. Tenga en cuenta que no deben aparecer formas de pago 
    repetidas. */
    public Task<IEnumerable<object>> ListadoConTodasLasFormasDePago();
}
