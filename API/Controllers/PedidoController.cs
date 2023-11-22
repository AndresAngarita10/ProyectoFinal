
using API.Dtos;
using API.Helpers.Errors;
using AutoMapper;
using Dominio.Entities;
using Dominio.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;
[ApiVersion("1.0")]
[ApiVersion("1.1")]

public class PedidoController : BaseApiController
{
    private readonly IUnitOfWork unitofwork;
    private readonly  IMapper mapper;

    public PedidoController( IUnitOfWork unitofwork, IMapper mapper)
    {
        this.unitofwork = unitofwork;
        this.mapper = mapper;
    }
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<PedidoDto>>> Get()
    {
        var entidad = await unitofwork.Pedidos.GetAllAsync();
        return mapper.Map<List<PedidoDto>>(entidad);
    }

    
    [HttpGet("consulta2")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<object>>> DistintosEstadosPedido()
    {
        var entidad = await unitofwork.Pedidos.DistintosEstadosPedido();
        return mapper.Map<List<object>>(entidad);
    }
    [HttpGet("consulta2")]
    [MapToApiVersion("1.1")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Pager<object>>> DistintosEstadosPedido([FromQuery] Params paisParams)
    {
        var entidad = await unitofwork.Pedidos.DistintosEstadosPedido(paisParams.PageIndex, paisParams.PageSize, paisParams.Search);
        var listEntidad = mapper.Map<List<object>>(entidad.registros);
        return new Pager<object>(listEntidad, entidad.totalRegistros, paisParams.PageIndex, paisParams.PageSize, paisParams.Search);
    }
    
    [HttpGet("consulta4")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<object>>> ListadoPedidosNoEntregadosATiempo()
    {
        var entidad = await unitofwork.Pedidos.ListadoPedidosNoEntregadosATiempo();
        return mapper.Map<List<object>>(entidad);
    }
    [HttpGet("consulta4")]
    [MapToApiVersion("1.1")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Pager<object>>> ListadoPedidosNoEntregadosATiempo([FromQuery] Params paisParams)
    {
        var entidad = await unitofwork.Pedidos.ListadoPedidosNoEntregadosATiempo(paisParams.PageIndex, paisParams.PageSize, paisParams.Search);
        var listEntidad = mapper.Map<List<object>>(entidad.registros);
        return new Pager<object>(listEntidad, entidad.totalRegistros, paisParams.PageIndex, paisParams.PageSize, paisParams.Search);
    }
    
    [HttpGet("consulta5")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<object>>> DosDiasAntesFechaEsperada()
    {
        var entidad = await unitofwork.Pedidos.DosDiasAntesFechaEsperada();
        return mapper.Map<List<object>>(entidad);
    }
    
    [HttpGet("consulta6")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<object>>> PedidosRechazadosEn2009()
    {
        var entidad = await unitofwork.Pedidos.PedidosRechazadosEn2009();
        return mapper.Map<List<object>>(entidad);
    }
    
    [HttpGet("consulta7")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<object>>> PedidosEntregadosEnEnero()
    {
        var entidad = await unitofwork.Pedidos.PedidosEntregadosEnEnero();
        return mapper.Map<List<object>>(entidad);
    }
    
    [HttpGet("consulta32")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<object>>> NumeroPedidosCadaEstado32()
    {
        var entidad = await unitofwork.Pedidos.NumeroPedidosCadaEstado32();
        return mapper.Map<List<object>>(entidad);
    }
    
    [HttpGet("consulta38")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<object>>> NumeroProductosPedidos38()
    {
        var entidad = await unitofwork.Pedidos.NumeroProductosPedidos38();
        return mapper.Map<List<object>>(entidad);
    }
    
    [HttpGet("consulta39")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<object>>> CantidadTotalProductosPedidos39()
    {
        var entidad = await unitofwork.Pedidos.CantidadTotalProductosPedidos39();
        return mapper.Map<List<object>>(entidad);
    }
    
    [HttpGet("consulta40")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<object>>> ProductosMasVendidos40()
    {
        var entidad = await unitofwork.Pedidos.ProductosMasVendidos40();
        return mapper.Map<List<object>>(entidad);
    }
    
    [HttpGet("consulta41")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<object>>> ProductosMasVendidosporCodigoProducto41()
    {
        var entidad = await unitofwork.Pedidos.ProductosMasVendidosporCodigoProducto41();
        return mapper.Map<List<object>>(entidad);
    }
    
    [HttpGet("consulta42")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<object>>> ProductosMasVendidosporCodigoProductoYFiltrada42()
    {
        var entidad = await unitofwork.Pedidos.ProductosMasVendidosporCodigoProductoYFiltrada42();
        return mapper.Map<List<object>>(entidad);
    }
    
    [HttpGet("consulta43")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<object>>> ProductosMasVendidos43()
    {
        var entidad = await unitofwork.Pedidos.ProductosMasVendidos43();
        return mapper.Map<List<object>>(entidad);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]

    public async Task<ActionResult<PedidoDto>> Get(int id)
    {
        var entidad = await unitofwork.Pedidos.GetByIdAsync(id);
        if (entidad == null){
            return NotFound();
        }
        return this.mapper.Map<PedidoDto>(entidad);
    }
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Pedido>> Post(PedidoDto entidadDto)
    {
        var entidad = this.mapper.Map<Pedido>(entidadDto);
        this.unitofwork.Pedidos.Add(entidad);
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

    public async Task<ActionResult<PedidoDto>> Put(int id, [FromBody]PedidoDto entidadDto){
        if(entidadDto == null)
        {
            return NotFound();
        }
        var entidad = this.mapper.Map<Pedido>(entidadDto);
        unitofwork.Pedidos.Update(entidad);
        await unitofwork.SaveAsync();
        return entidadDto;
    }
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id){
        var entidad = await unitofwork.Pedidos.GetByIdAsync(id);
        if(entidad == null)
        {
            return NotFound();
        }
        unitofwork.Pedidos.Remove(entidad);
        await unitofwork.SaveAsync();
        return NoContent();
    }
}