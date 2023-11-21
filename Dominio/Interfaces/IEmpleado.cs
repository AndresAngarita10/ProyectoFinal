
using Dominio.Entities;

namespace Dominio.Interfaces;

public interface IEmpleado : IGenericRepoInt<Empleado>
{
    public abstract Task<(int totalRegistros, object registros)> ListadoEmpleadoConJefes17(int pageIndez, int pageSize, string search); // 17
    public abstract Task<(int totalRegistros, object registros)> ListadoEmpleadoSinCliente22(int pageIndez, int pageSize, string search); // 22

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
    /* 28 . Devuelve un listado con los datos de los empleados que no tienen clientes 
asociados y el nombre de su jefe asociado. */
    public Task<IEnumerable<object>> ListadoEmpleadoSinClienteYJefe28();
    /*  29. ¿Cuántos empleados hay en la compañía? */
    public Task<int> NumeroEmpleados29();
    /* 35. Devuelve el nombre de los representantes de ventas y el número de clientes 
al que atiende cada uno. */
    public Task<IEnumerable<object>> NombreRepVentasConNumClientes35();

    /* 54. Devuelve el nombre, apellidos, puesto y teléfono de la oficina de aquellos 
    empleados que no sean representante de ventas de ningún cliente.
    */
    public Task<IEnumerable<object>> EmpleadosSinClientes54();

    /* 61. Devuelve el nombre, apellidos, puesto y teléfono de la oficina de aquellos 
    empleados que no sean representante de ventas de ningún cliente. */
    public Task<IEnumerable<object>> EmpleadosSinClientes61();
}
