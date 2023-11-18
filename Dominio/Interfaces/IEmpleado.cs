
using Dominio.Entities;

namespace Dominio.Interfaces;

public interface IEmpleado : IGenericRepoInt<Empleado>
{
    /* 17. Devuelve un listado que muestre el nombre de cada empleados, el nombre 
    de su jefe y el nombre del jefe de sus jefe. */
    public Task<IEnumerable<object>> ListadoEmpleadoConJefes17();
    /*    22. Devuelve un listado que muestre solamente los empleados que no tienen un 
cliente asociado junto con los datos de la oficina donde trabajan. */
    public Task<IEnumerable<object>> ListadoEmpleadoSinCliente22();
       /* 23. Devuelve un listado que muestre los empleados que no tienen una oficina 
asociada y los que no tienen un cliente asociado. */
    public Task<IEnumerable<object>> ListadoEmpleadoSinClienteNiOficina23();
    /* 26. Devuelve las oficinas donde no trabajan ninguno de los empleados que 
hayan sido los representantes de ventas de algún cliente que haya realizado 
la compra de algún producto de la gama Frutales. */
    public Task<IEnumerable<object>> ListadoEmpleadoSinOficinaConClienteGamaFrutales26();
}
