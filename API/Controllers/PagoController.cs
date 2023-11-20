
using API.Dtos;
using AutoMapper;
using Dominio.Entities;
using Dominio.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

public class PagoController : BaseApiController
{
    private readonly IUnitOfWork unitofwork;
    private readonly  IMapper mapper;

    public PagoController( IUnitOfWork unitofwork, IMapper mapper)
    {
        this.unitofwork = unitofwork;
        this.mapper = mapper;
    }
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<PagoDto>>> Get()
    {
        var entidad = await unitofwork.Pagos.GetAllAsync();
        return mapper.Map<List<PagoDto>>(entidad);
    }
    
    [HttpGet("consulta8")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<object>>> ListadoConPagos2008YPaypal()
    {
        var entidad = await unitofwork.Pagos.ListadoConPagos2008YPaypal();
        return mapper.Map<List<object>>(entidad);
    }
    
    [HttpGet("consulta9")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<object>>> ListadoConTodasLasFormasDePago()
    {
        var entidad = await unitofwork.Pagos.ListadoConTodasLasFormasDePago();
        return mapper.Map<List<object>>(entidad);
    }

    [HttpGet("consulta31")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<object>>> PagoMedioEn200931()
    {
        var entidad = await unitofwork.Pagos.PagoMedioEn200931();
        return Ok(entidad);
    }
    
    [HttpGet("consulta44")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<object>>> SumaTotalDeTodosLosPagosParaTodosLosAños44()
    {
        var entidad = await unitofwork.Pagos.SumaTotalDeTodosLosPagosParaTodosLosAños44();
        return mapper.Map<List<object>>(entidad);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]

    public async Task<ActionResult<PagoDto>> Get(int id)
    {
        var entidad = await unitofwork.Pagos.GetByIdAsync(id);
        if (entidad == null){
            return NotFound();
        }
        return this.mapper.Map<PagoDto>(entidad);
    }
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Pago>> Post(PagoDto entidadDto)
    {
        var entidad = this.mapper.Map<Pago>(entidadDto);
        this.unitofwork.Pagos.Add(entidad);
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

    public async Task<ActionResult<PagoDto>> Put(int id, [FromBody]PagoDto entidadDto){
        if(entidadDto == null)
        {
            return NotFound();
        }
        var entidad = this.mapper.Map<Pago>(entidadDto);
        unitofwork.Pagos.Update(entidad);
        await unitofwork.SaveAsync();
        return entidadDto;
    }
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id){
        var entidad = await unitofwork.Pagos.GetByIdAsync(id);
        if(entidad == null)
        {
            return NotFound();
        }
        unitofwork.Pagos.Remove(entidad);
        await unitofwork.SaveAsync();
        return NoContent();
    }
}