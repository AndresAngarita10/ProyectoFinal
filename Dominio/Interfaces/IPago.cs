
using Dominio.Entities;

namespace Dominio.Interfaces;

public interface IPago : IGenericRepoStr<Pago>
{    
    //public abstract Task<(int totalRegistros, object registros)> ListadoConPagos2008YPaypal(int pageIndez, int pageSize, string search); // 8

    public abstract Task<(int totalRegistros, object registros)> ListadoConTodasLasFormasDePago(int pageIndez, int pageSize, string search); // 9

    /*  8. Devuelve un listado con todos los pagos que se realizaron en el 
    año 2008 mediante Paypal. Ordene el resultado de mayor a menor. */
    public Task<IEnumerable<object>> ListadoConPagos2008YPaypal();
     /*     9. Devuelve un listado con todas las formas de pago que aparecen en la 
    tabla pago. Tenga en cuenta que no deben aparecer formas de pago 
    repetidas. */
    public Task<IEnumerable<object>> ListadoConTodasLasFormasDePago();
    /* 31. ¿Cuál fue el pago medio en 2009? */
    public  Task<object> PagoMedioEn200931 ();
     /* 44. Muestre la suma total de todos los pagos que se realizaron para cada uno 
de los años que aparecen en la tabla pagos. */
    public Task<IEnumerable<object>> SumaTotalDeTodosLosPagosParaTodosLosAños44();
}
