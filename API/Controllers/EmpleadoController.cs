
using API.Dtos;
using AutoMapper;
using Dominio.Entities;
using Dominio.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

public class EmpleadoController : BaseApiController
{
    private readonly IUnitOfWork unitofwork;
    private readonly  IMapper mapper;

    public EmpleadoController( IUnitOfWork unitofwork, IMapper mapper)
    {
        this.unitofwork = unitofwork;
        this.mapper = mapper;
    }
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<EmpleadoDto>>> Get()
    {
        var entidad = await unitofwork.Empleados.GetAllAsync();
        return mapper.Map<List<EmpleadoDto>>(entidad);
    }


    [HttpGet("consulta17")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<object>>> ListadoEmpleadoConJefes17()
    {
        var entidad = await unitofwork.Empleados.ListadoEmpleadoConJefes17();
        return mapper.Map<List<object>>(entidad);
    }
    
    [HttpGet("consulta22")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<object>>> ListadoEmpleadoSinCliente22()
    {
        var entidad = await unitofwork.Empleados.ListadoEmpleadoSinCliente22();
        return mapper.Map<List<object>>(entidad);
    }
    
    [HttpGet("consulta23")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<object>>> ListadoEmpleadoSinClienteNiOficina23()
    {
        var entidad = await unitofwork.Empleados.ListadoEmpleadoSinClienteNiOficina23();
        return mapper.Map<List<object>>(entidad);
    }

    [HttpGet("consulta26")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<object>>> ListadoEmpleadoSinOficinaConClienteGamaFrutales26()
    {
        var entidad = await unitofwork.Empleados.ListadoEmpleadoSinOficinaConClienteGamaFrutales26();
        return mapper.Map<List<object>>(entidad);
    }
    
    [HttpGet("consulta28")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<object>>> ListadoEmpleadoSinClienteYJefe28()
    {
        var entidad = await unitofwork.Empleados.ListadoEmpleadoSinClienteYJefe28();
        return mapper.Map<List<object>>(entidad);
    }
    
    [HttpGet("consulta29")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<int>> NumeroEmpleados29()
    {
        var entidad = await unitofwork.Empleados.NumeroEmpleados29();
        return Ok(entidad);
    }
    
    [HttpGet("consulta35")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<object>>> NombreRepVentasConNumClientes35()
    {
        var entidad = await unitofwork.Empleados.NombreRepVentasConNumClientes35();
        return mapper.Map<List<object>>(entidad);
    }
    
    [HttpGet("consulta54")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<object>>> EmpleadosSinClientes54()
    {
        var entidad = await unitofwork.Empleados.EmpleadosSinClientes54();
        return mapper.Map<List<object>>(entidad);
    }
    
    [HttpGet("consulta61")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<object>>> EmpleadosSinClientes61()
    {
        var entidad = await unitofwork.Empleados.EmpleadosSinClientes61();
        return mapper.Map<List<object>>(entidad);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]

    public async Task<ActionResult<EmpleadoDto>> Get(int id)
    {
        var entidad = await unitofwork.Empleados.GetByIdAsync(id);
        if (entidad == null){
            return NotFound();
        }
        return this.mapper.Map<EmpleadoDto>(entidad);
    }
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Empleado>> Post(EmpleadoDto entidadDto)
    {
        var entidad = this.mapper.Map<Empleado>(entidadDto);
        this.unitofwork.Empleados.Add(entidad);
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

    public async Task<ActionResult<EmpleadoDto>> Put(int id, [FromBody]EmpleadoDto entidadDto){
        if(entidadDto == null)
        {
            return NotFound();
        }
        var entidad = this.mapper.Map<Empleado>(entidadDto);
        unitofwork.Empleados.Update(entidad);
        await unitofwork.SaveAsync();
        return entidadDto;
    }
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id){
        var entidad = await unitofwork.Empleados.GetByIdAsync(id);
        if(entidad == null)
        {
            return NotFound();
        }
        unitofwork.Empleados.Remove(entidad);
        await unitofwork.SaveAsync();
        return NoContent();
    }
}
