using EmployeeApp.Application.Employees.Commands;
using EmployeeApp.Application.Employees.DTOs;
using EmployeeApp.Application.Employees.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeApp.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EmployeesController : ControllerBase
{
    private readonly IMediator _mediator;

    public EmployeesController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateEmployeeCommand command)
    {
        var result = await _mediator.Send(command);
        return Ok(result); // Or return CreatedAtAction if you add GetById later
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetEmployeeById(Guid id)
    {
        var result = await _mediator.Send(new GetEmployeeByIdQuery(id));
        if (!result.IsSuccess)
            return NotFound(result.Error);

        return Ok(result.Data);
    }

    [HttpGet]
    public async Task<ActionResult<List<EmployeeDto>>> Get()
    {
        var result = await _mediator.Send(new GetAllEmployeesQuery());
        return Ok(result);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(Guid id, UpdateEmployeeCommand command)
    {
        if (id != command.Id)
            return BadRequest("ID mismatch");

        await _mediator.Send(command);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        await _mediator.Send(new DeleteEmployeeCommand(id));
        return NoContent();
    }
}