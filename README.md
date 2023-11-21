# ProyectoFinal
# Jardineria

Este proyecto proporciona una API que permite gestionar la administración de una Jardinearia

## Uso 🕹

Una vez que el proyecto esté en marcha, puedes acceder a los diferentes endpoints disponibles:

primero que todo, en los csv esta el administrador con el usuario:admin y la contraseña : 123
del cual nesecitaremos el token para el registro de usuarios ya que solo el administrador podra hacer todo con respecto al crud de los usuarios:

## 1. Generación del token:

       *Endpoint*: `http://localhost:5272/api/usuario/token`
       
       *Método*: `POST`
       
       *Payload*:
       
       `{
           "Nombre": "<nombre_de_usuario>",
           "password": "<password>"
       }`
una vez que tenemos el token del administrador, ya podremos hacer el registro de usuario ingresandolo en el auth:
## 2. Registro de Usuarios

      *Endpoint*: `http://localhost:5272/api/usuario/register`
      
      *Método*: `POST`
      
      *Payload*:
      
      json
      `{
          "Nombre": "<nombre_de_usuario>",
          "password": "<password>",
          "Email": "<Email>"
      }`

Una vez registrado el usuario tendrá que ingresar para recibir un token, este será ingresado al siguiente Endpoint que es el de Refresh Token para poder ingresar a los demas controladores.

## 3. Refresh Token:

      *Endpoint*: `http://localhost:5272/api/usuario/refresh-token`
      
      *Método*: `POST`
      
      *Payload*:
      
      `{
          "Nombre": "<nombre_de_usuario>",
          "password": "<password>"
      }`

Se dejan los mismos datos en el Body y luego se ingresa al "Auth", "Bearer", allí se ingresa el token obtenido en el anterior Endpoint.

      *Otros Endpoints*
      recordar que para todos los endpoints tenemos que tener el token de rol de administrador
      
      Obtener Todos los Usuarios: GET `http://localhost:5272/api/usuario`
      
      Obtener Usuario por ID: GET `http://localhost:5272/api/usuario/{id}`
      
      Actualizar Usuario: PUT `http://localhost:5272/api/usuario/{id}`
      
      Eliminar Usuario: DELETE `http://localhost:5272/api/usuario/{id}`
      

## Versionado de los Endpoints requeridos⌨️
Para consultar la versión 1.0 de todos se ingresa únicamente el Endpoint; para consultar la versión 1.1 se deben seguir los siguientes pasos: 

En el Thunder Client se va al apartado de "Headers" y se ingresa lo siguiente:

![image](https://github.com/SilviaJaimes/Proyecto-Veterinaria/assets/132016483/8044ee3d-76d9-4437-9f08-da8e5d7cff9a)

Para realizar la paginación se va al apartado de "Query" y se ingresa lo siguiente:

![image](https://github.com/SilviaJaimes/Proyecto-Veterinaria/assets/132016483/22683e46-037e-4f30-96b8-161df8622b40)


Cada Endpoint tiene su versión 1.0 y 1.1, al igual que están con y sin paginación.

En el caso de las Consultas cada tabla que tenga consultas tiene 2 EndPoints con su versión 1.0 y 1.1, al igual que están con y sin paginación.

Consultas:
## cliente

- Consulta 1 

		http://localhost:5272/api/cliente/consulta1?ver=1.1&pageIndex=2&pageSize=1

- Consulta 3 

		http://localhost:5272/api/cliente/consulta3?ver=1.1

## empleado

- Consulta 17

		http://localhost:5272/api/empleado/consulta17?ver=1.1

- Consulta 22

		http://localhost:5272/api/empleado/consulta22?ver=1.1

## oficina (GetAllAsync)

- Consulta 

		http://localhost:5272/api/oficina?ver=1.1

## pago

- Consulta 8

		http://localhost:5272/api/pago/consulta8?ver=1.1

- Consulta 9

		http://localhost:5272/api/pago/consulta9?ver=1.1

## pedido

- Consulta 2

		http://localhost:5272/api/pedido/consulta2?ver=1.1

- Consulta 4

		http://localhost:5272/api/pedido/consulta4?ver=1.1

## producto
- Consulta 10

		http://localhost:5272/api/producto/consulta10?ver=1.1

- Consulta 24

		http://localhost:5272/api/producto/consulta24?ver=1.1

## Detalle Pedido (GetAllAsync)

- Consulta 

		http://localhost:5272/api/detallepedido?ver=1.1
  
## Gama Producto (GetAllAsync)

- Consulta 

		http://localhost:5272/api/gamaproducto?ver=1.1



## Características 🌟

- Registro de usuarios.
- CRUD completo para cada entidad.
- Vista de las consultas requeridas.

## Desarrollo de los Endpoints requeridos⌨️

## 1. Devuelve un listado con el nombre de todos los clientes españoles.
		
		http://localhost:5272/api/cliente/consulta1

## 2. Devuelve un listado con los distintos estados por los que puede pasar un pedido.
		
		http://localhost:5272/api/pedido/consulta2

## 3. Devuelve un listado con el código de cliente de aquellos clientes que realizaron algún pago en 2008. Tenga en cuenta que deberá eliminar aquellos códigos de cliente que aparezcan repetidos. Resuelva la consulta:
		
		http://localhost:5272/api/cliente/consulta3

## 4. Devuelve un listado con el código de pedido, código de cliente, fecha esperada y fecha de entrega de los pedidos que no han sido entregados a tiempo.
		
		http://localhost:5272/api/pedido/consulta4

## 5. Devuelve un listado con el código de pedido, código de cliente, fecha esperada y fecha de entrega de los pedidos cuya fecha de entrega ha sido al menos dos días antes de la fecha esperada.
   - Utilizando la función ADDDATE de MySQL.
   - Utilizando la función DATEDIFF de MySQL.
   - ¿Sería posible resolver esta consulta utilizando el operador de suma + o resta -?
		
			http://localhost:5272/api/pedido/consulta5

## 6. Devuelve un listado de todos los pedidos que fueron rechazados en 2009.
		
		http://localhost:5272/api/pedido/consulta6

## 7. Devuelve un listado de todos los pedidos que han sido entregados en el mes de enero de cualquier año.
		
		http://localhost:5272/api/pedido/consulta7

## 8. Devuelve un listado con todos los pagos que se realizaron en el año 2008 mediante Paypal. Ordene el resultado de mayor a menor.
		
		http://localhost:5272/api/pago/consulta8

## 9. Devuelve un listado con todas las formas de pago que aparecen en la tabla pago. Tenga en cuenta que no deben aparecer formas de pago repetidas.
		
		http://localhost:5272/api/pago/consulta9

## 10. Devuelve un listado con todos los productos que pertenecen a la gama Ornamentales y que tienen más de 100 unidades en stock. El listado deberá estar ordenado por su precio de venta, mostrando en primer lugar los de mayor precio.
		
		http://localhost:5272/api/producto/consulta10

## 11. Devuelve un listado con todos los clientes que sean de la ciudad de Madrid y cuyo representante de ventas tenga el código de empleado 11 o 30.
		
		http://localhost:5272/api/cliente/consulta11

## 12. Obtén un listado con el nombre de cada cliente y el nombre y apellido de su representante de ventas.
		
		http://localhost:5272/api/cliente/consulta12

## 13. Muestra el nombre de los clientes que hayan realizado pagos junto con el nombre de sus representantes de ventas.
		
		http://localhost:5272/api/cliente/consulta13

## 14. Muestra el nombre de los clientes que no hayan realizado pagos junto con el nombre de sus representantes de ventas.
		
		http://localhost:5272/api/cliente/consulta14

## 15. Devuelve el nombre de los clientes que han hecho pagos y el nombre de sus representantes junto con la ciudad de la oficina a la que pertenece el representante.
		
		http://localhost:5272/api/cliente/consulta15

## 16. Devuelve el nombre de los clientes que no hayan hecho pagos y el nombre de sus representantes junto con la ciudad de la oficina a la que pertenece el representante.
		
		http://localhost:5272/api/cliente/consulta16

## 17. Devuelve un listado que muestre el nombre de cada empleado, el nombre de su jefe y el nombre del jefe de sus jefe.
		
		http://localhost:5272/api/empleado/consulta17

## 18. Devuelve el nombre de los clientes a los que no se les ha entregado a tiempo un pedido.
		
		http://localhost:5272/api/cliente/consulta18

## 19. Devuelve un listado de las diferentes gamas de producto que ha comprado cada cliente.
		
		http://localhost:5272/api/cliente/consulta19

## 20. Devuelve un listado que muestre solamente los clientes que no han realizado ningún pago.
		
		http://localhost:5272/api/cliente/consulta20

## 21. Devuelve un listado que muestre los clientes que no han realizado ningún pago y los que no han realizado ningún pedido.
		
		http://localhost:5272/api/cliente/consulta21

## 22. Devuelve un listado que muestre solamente los empleados que no tienen un cliente asociado junto con los datos de la oficina donde trabajan.
		
		http://localhost:5272/api/empleado/consulta22

## 23. Devuelve un listado que muestre los empleados que no tienen una oficina asociada y los que no tienen un cliente asociado.
		
		http://localhost:5272/api/empleado/consulta23

## 24. Devuelve un listado de los productos que nunca han aparecido en un pedido.
		
		http://localhost:5272/api/producto/consulta24

## 25. Devuelve un listado de los productos que nunca han aparecido en un pedido. El resultado debe mostrar el nombre, la descripción y la imagen del producto.
		
		http://localhost:5272/api/producto/consulta25

## 26. Devuelve las oficinas donde no trabajan ninguno de los empleados que hayan sido los representantes de ventas de algún cliente que haya realizado la compra de algún producto de la gama Frutales.
		
		http://localhost:5272/api/empleado/consulta26

## 27. Devuelve un listado con los clientes que han realizado algún pedido pero no han realizado ningún pago.
		
		http://localhost:5272/api/cliente/consulta27

## 28. Devuelve un listado con los datos de los empleados que no tienen clientes asociados y el nombre de su jefe asociado.
		
		http://localhost:5272/api/empleado/consulta28

## 29. ¿Cuántos empleados hay en la compañía?
		
		http://localhost:5272/api/empleado/consulta29

## 30. ¿Cuántos clientes tiene cada país?
		
		http://localhost:5272/api/cliente/consulta30

## 31. ¿Cuál fue el pago medio en 2009?
		
		http://localhost:5272/api/pago/consulta31

## 32. ¿Cuántos pedidos hay en cada estado? Ordena el resultado de forma descendente por el número de pedidos.
		
		http://localhost:5272/api/pedido/consulta32

## 33. ¿Cuántos clientes existen con domicilio en la ciudad de Madrid?
		
		http://localhost:5272/api/cliente/consulta33

## 34. ¿Calcula cuántos clientes tiene cada una de las ciudades que empiezan por M?
		
		http://localhost:5272/api/cliente/consulta34

## 35. Devuelve el nombre de los representantes de ventas y el número de clientes al que atiende cada uno.
		
		http://localhost:5272/api/empleado/consulta35

## 36. Calcula el número de clientes que no tiene asignado representante de ventas.
		
		http://localhost:5272/api/cliente/consulta36

## 37. Calcula la fecha del primer y último pago realizado por cada uno de los clientes. El listado deberá mostrar el nombre y los apellidos de cada cliente.
		
		http://localhost:5272/api/cliente/consulta37

## 38. Calcula el número de productos diferentes que hay en cada uno de los pedidos.
		
		http://localhost:5272/api/pedido/consulta38

## 39. Calcula la suma de la cantidad total de todos los productos que aparecen en cada uno de los pedidos.
		
		http://localhost:5272/api/pedido/consulta39

## 40. Devuelve un listado de los 20 productos más vendidos y el número total de unidades que se han vendido de cada uno. El listado deberá estar ordenado por el número total de unidades vendidas.
		
		http://localhost:5272/api/pedido/consulta40

## 41. La misma información que en la pregunta anterior, pero agrupada por código de producto.
		
		http://localhost:5272/api/pedido/consulta41

## 42. La misma información que en la pregunta anterior, pero agrupada por código de producto filtrada por los códigos que empiecen por OR.
		
		http://localhost:5272/api/pedido/consulta42

## 43. Lista las ventas totales de los productos que hayan facturado más de 3000 euros. Se mostrará el nombre, unidades vendidas, total facturado y total facturado con impuestos (21% IVA).
		
		http://localhost:5272/api/pedido/consulta43

## 44. Muestre la suma total de todos los pagos que se realizaron para cada uno de los años que aparecen en la tabla pagos.
		
		http://localhost:5272/api/pago/consulta44

## 45. Devuelve el nombre del cliente con mayor límite de crédito.
		
		http://localhost:5272/api/cliente/consulta45

## 46. Devuelve el nombre del producto que tenga el precio de venta más caro.
		
		http://localhost:5272/api/producto/consulta46

## 47. Devuelve el nombre del producto del que se han vendido más unidades. (Tenga en cuenta que tendrá que calcular cuál es el número total de unidades que se han vendido de cada producto a partir de los datos de la tabla detalle_pedido)
		
		http://localhost:5272/api/producto/consulta47

## 48. Los clientes cuyo límite de crédito sea mayor que los pagos que haya realizado. (Sin utilizar INNER JOIN).
		
		http://localhost:5272/api/cliente/consulta48

## 49. Devuelve el nombre del cliente con mayor límite de crédito.
		
		http://localhost:5272/api/cliente/consulta49

## 50. Devuelve el nombre del producto que tenga el precio de venta más caro.
		
		http://localhost:5272/api/producto/consulta50

## 51. Devuelve un listado que muestre solamente los clientes que no han realizado ningún pago.
		
		http://localhost:5272/api/cliente/consulta51

## 52. Devuelve un listado que muestre solamente los clientes que sí han realizado algún pago.
		
		http://localhost:5272/api/cliente/consulta52

## 53. Devuelve un listado de los productos que nunca han aparecido en un pedido.
		
		http://localhost:5272/api/producto/consulta53

## 54. Devuelve el nombre, apellidos, puesto y teléfono de la oficina de aquellos empleados que no sean representante de ventas de ningún cliente.
		
		http://localhost:5272/api/empleado/consulta54

## 55. Devuelve un listado que muestre solamente los clientes que no han realizado ningún pago.
		
		http://localhost:5272/api/cliente/consulta55

## 56. Devuelve un listado que muestre solamente los clientes que sí han realizado algún pago.
		
		http://localhost:5272/api/cliente/consulta56

## 57. Devuelve el listado de clientes indicando el nombre del cliente y cuántos pedidos ha realizado. Tenga en cuenta que pueden existir clientes que no han realizado ningún pedido.
		
		http://localhost:5272/api/cliente/consulta57

## 58. Devuelve el nombre de los clientes que hayan hecho pedidos en 2008 ordenados alfabéticamente de menor a mayor.
		
		http://localhost:5272/api/cliente/consulta58

## 59. Devuelve el nombre del cliente, el nombre y primer apellido de su representante de ventas y el número de teléfono de la oficina del representante de ventas, de aquellos clientes que no hayan realizado ningún pago.
		
		http://localhost:5272/api/cliente/consulta59

## 60. Devuelve el listado de clientes donde aparezca el nombre del cliente, el nombre y primer apellido de su representante de ventas y la ciudad donde está su oficina.
		
		http://localhost:5272/api/cliente/consulta60

## 61. Devuelve el nombre, apellidos, puesto y teléfono de la oficina de aquellos empleados que no sean representante de ventas de ningún cliente.
		
		http://localhost:5272/api/empleado/consulta61


## Desarrollo ⌨️
Este proyecto utiliza varias tecnologías y patrones, incluidos:

Entity Framework Core para la ORM.
Patrón Repository y Unit of Work para la gestión de datos.
AutoMapper para el mapeo entre entidades y DTOs.

## Data ✅

la data necesaria para probar la informacion se encuentra en el mismo Proyecto en el archivo llamado "Data.txt"

## Agradecimientos 🎁

A todas las librerías y herramientas utilizadas en este proyecto.
