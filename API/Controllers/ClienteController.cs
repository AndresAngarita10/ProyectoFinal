
using API.Dtos;
using API.Helpers.Errors;
using AutoMapper;
using Dominio.Entities;
using Dominio.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;
[ApiVersion("1.0")]
[ApiVersion("1.1")]
public class ClienteController : BaseApiController
{
    private readonly IUnitOfWork unitofwork;
    private readonly  IMapper mapper;

    public ClienteController( IUnitOfWork unitofwork, IMapper mapper)
    {
        this.unitofwork = unitofwork;
        this.mapper = mapper;
    }
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<ClienteDto>>> Get()
    {
        var entidad = await unitofwork.Clientes.GetAllAsync();
        return mapper.Map<List<ClienteDto>>(entidad);
    }
    
    [HttpGet("consulta1")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<object>>> ListadoClientesEspañones()
    {
        var entidad = await unitofwork.Clientes.ListadoClientesEspañones();
        return mapper.Map<List<object>>(entidad);
    }

    [HttpGet("consulta1")]
    [MapToApiVersion("1.1")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Pager<object>>> ListadoClientesEspañones([FromQuery] Params paisParams)
    {
        var entidad = await unitofwork.Clientes.ListadoClientesEspañones(paisParams.PageIndex, paisParams.PageSize, paisParams.Search);
        var listEntidad = mapper.Map<List<object>>(entidad.registros);
        return new Pager<object>(listEntidad, entidad.totalRegistros, paisParams.PageIndex, paisParams.PageSize, paisParams.Search);
    }
    
    [HttpGet("consulta3")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<object>>> ListadoClientesPagos2008()
    {
        var entidad = await unitofwork.Clientes.ListadoClientesPagos2008();
        return mapper.Map<List<object>>(entidad);
    }
    
    [HttpGet("consulta3")]
    [MapToApiVersion("1.1")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Pager<object>>> ListadoClientesPagos2008([FromQuery] Params paisParams)
    {
        var entidad = await unitofwork.Clientes.ListadoClientesPagos2008(paisParams.PageIndex, paisParams.PageSize, paisParams.Search);
        var listEntidad = mapper.Map<List<object>>(entidad.registros);
        return new Pager<object>(listEntidad, entidad.totalRegistros, paisParams.PageIndex, paisParams.PageSize, paisParams.Search);
    }
    
    [HttpGet("consulta11")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<object>>> ListadoClientesMadrid()
    {
        var entidad = await unitofwork.Clientes.ListadoClientesMadrid();
        return mapper.Map<List<object>>(entidad);
    }
    
    [HttpGet("consulta12")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<object>>> ListadoClientesRepVentas()
    {
        var entidad = await unitofwork.Clientes.ListadoClientesRepVentas();
        return mapper.Map<List<object>>(entidad);
    }
    
    [HttpGet("consulta13")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<object>>> ListadoClientesRepVentasPagos()
    {
        var entidad = await unitofwork.Clientes.ListadoClientesRepVentasPagos();
        return mapper.Map<List<object>>(entidad);
    }
    
    [HttpGet("consulta14")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<object>>> ListadoClientesRepVentasNoPagos()
    {
        var entidad = await unitofwork.Clientes.ListadoClientesRepVentasNoPagos();
        return mapper.Map<List<object>>(entidad);
    }
    
    [HttpGet("consulta15")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<object>>> ListadoClientesQueHanHechoPagos15()
    {
        var entidad = await unitofwork.Clientes.ListadoClientesQueHanHechoPagos15();
        return mapper.Map<List<object>>(entidad);
    }

    [HttpGet("consulta16")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<object>>> ListadoClientesQueNoHanHechoPagos16()
    {
        var entidad = await unitofwork.Clientes.ListadoClientesQueNoHanHechoPagos16();
        return mapper.Map<List<object>>(entidad);
    }
    
    [HttpGet("consulta18")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<object>>> ListadoClientesQueNoHanEntregadoPedidos18()
    {
        var entidad = await unitofwork.Clientes.ListadoClientesQueNoHanEntregadoPedidos18();
        return mapper.Map<List<object>>(entidad);
    }
    
    [HttpGet("consulta19")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<object>>> ListadoGamasCompradasPorCliente19()
    {
        var entidad = await unitofwork.Clientes.ListadoGamasCompradasPorCliente19();
        return mapper.Map<List<object>>(entidad);
    }
    
    [HttpGet("consulta20")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<object>>> ClientesSinPagos20()
    {
        var entidad = await unitofwork.Clientes.ClientesSinPagos20();
        return mapper.Map<List<object>>(entidad);
    }
    
    [HttpGet("consulta21")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<object>>> ClientesQueNoHanPagadoNiHanHechoPedido21()
    {
        var entidad = await unitofwork.Clientes.ClientesQueNoHanPagadoNiHanHechoPedido21();
        return mapper.Map<List<object>>(entidad);
    }
    
    [HttpGet("consulta27")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<object>>> ClientesConPedidoQueNoHanPagado27()
    {
        var entidad = await unitofwork.Clientes.ClientesConPedidoQueNoHanPagado27();
        return mapper.Map<List<object>>(entidad);
    }
    
    [HttpGet("consulta30")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<object>>> ClientesPorPais30()
    {
        var entidad = await unitofwork.Clientes.ClientesPorPais30();
        return mapper.Map<List<object>>(entidad);
    }
    
    [HttpGet("consulta33")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<object>>> ClientesConDomicilioEnMadrid33()
    {
        var entidad = await unitofwork.Clientes.ClientesConDomicilioEnMadrid33();
        return Ok(entidad);
    }
    
    [HttpGet("consulta34")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<object>>> ClientesPorCiudadesConMInicial34()
    {
        var entidad = await unitofwork.Clientes.ClientesPorCiudadesConMInicial34();
        return mapper.Map<List<object>>(entidad);
    }
    
    [HttpGet("consulta36")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<object>>> NumeroClientesSinRepresentanteVentas36()
    {
        var entidad = await unitofwork.Clientes.NumeroClientesSinRepresentanteVentas36();
        return Ok(entidad);
    }

    [HttpGet("consulta37")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<object>>> PrimerYUltimoPagoPorCliente37()
    {
        var entidad = await unitofwork.Clientes.PrimerYUltimoPagoPorCliente37();
        return mapper.Map<List<object>>(entidad);
    }
    
    [HttpGet("consulta45")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<object>>> ClienteConMayorLimiteCredito45()
    {
        var entidad = await unitofwork.Clientes.ClienteConMayorLimiteCredito45();
        return Ok(entidad);
    }
    
    [HttpGet("consulta48")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<object>>> ClienteConMayorLimiteCreditoALosPagos48()
    {
        var entidad = await unitofwork.Clientes.ClienteConMayorLimiteCreditoALosPagos48();
        return mapper.Map<List<object>>(entidad);
    }
    
    [HttpGet("consulta49")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<object>>> ClienteConMayorLimiteCredito49()
    {
        var entidad = await unitofwork.Clientes.ClienteConMayorLimiteCredito49();
        return Ok(entidad);
    }
    
    [HttpGet("consulta51")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<object>>> ClienteNoHanHechoPagos51()
    {
        var entidad = await unitofwork.Clientes.ClienteNoHanHechoPagos51();
        return mapper.Map<List<object>>(entidad);
    }
    
    [HttpGet("consulta52")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<object>>> ClienteSiHanHechoPagos52()
    {
        var entidad = await unitofwork.Clientes.ClienteSiHanHechoPagos52();
        return mapper.Map<List<object>>(entidad);
    }
    
    [HttpGet("consulta55")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<object>>> ClienteNoHanHechoPagos55()
    {
        var entidad = await unitofwork.Clientes.ClienteNoHanHechoPagos55();
        return mapper.Map<List<object>>(entidad);
    }
    
    [HttpGet("consulta56")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<object>>> ClienteSiHanHechoPagos56()
    {
        var entidad = await unitofwork.Clientes.ClienteSiHanHechoPagos56();
        return mapper.Map<List<object>>(entidad);
    }
    
    [HttpGet("consulta57")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<object>>> ClientesYPedidos57()
    {
        var entidad = await unitofwork.Clientes.ClientesYPedidos57();
        return mapper.Map<List<object>>(entidad);
    }
    
    [HttpGet("consulta58")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<object>>> ClientesYPedidosEn200858()
    {
        var entidad = await unitofwork.Clientes.ClientesYPedidosEn200858();
        return mapper.Map<List<object>>(entidad);
    }
    
    [HttpGet("consulta59")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<object>>> ClientesYPedidosConRepresentanteVentas59()
    {
        var entidad = await unitofwork.Clientes.ClientesYPedidosConRepresentanteVentas59();
        return mapper.Map<List<object>>(entidad);
    }
    
    [HttpGet("consulta60")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<object>>> ClientesYPedidosConRepresentanteVentas60()
    {
        var entidad = await unitofwork.Clientes.ClientesYPedidosConRepresentanteVentas60();
        return mapper.Map<List<object>>(entidad);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]

    public async Task<ActionResult<ClienteDto>> Get(int id)
    {
        var entidad = await unitofwork.Clientes.GetByIdAsync(id);
        if (entidad == null){
            return NotFound();
        }
        return this.mapper.Map<ClienteDto>(entidad);
    }
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Cliente>> Post(ClienteDto entidadDto)
    {
        var entidad = this.mapper.Map<Cliente>(entidadDto);
        this.unitofwork.Clientes.Add(entidad);
        await unitofwork.SaveAsync();
        if(entidad == null)
        {
            return BadRequest();
        }
        entidadDto.Id = entidad.Id;
        return CreatedAtAction(nameof(Post), new {id = entidadDto.Id}, entidadDto);
    }
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]

    public async Task<ActionResult<ClienteDto>> Put(int id, [FromBody]ClienteDto entidadDto){
        if(entidadDto == null)
        {
            return NotFound();
        }
        var entidad = this.mapper.Map<Cliente>(entidadDto);
        unitofwork.Clientes.Update(entidad);
        await unitofwork.SaveAsync();
        return entidadDto;
    }
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id){
        var entidad = await unitofwork.Clientes.GetByIdAsync(id);
        if(entidad == null)
        {
            return NotFound();
        }
        unitofwork.Clientes.Remove(entidad);
        await unitofwork.SaveAsync();
        return NoContent();
    }
}