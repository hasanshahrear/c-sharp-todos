using Microsoft.AspNetCore.Mvc;
using Tips.Database;
using Tips.Domain;
using Tips.Service;

namespace Tips.Controllers;

[Route("/api/[controller]")]
public class ToDoController : ControllerBase
{
    private readonly IToDoService _toDoService;

    public ToDoController(IToDoService toDoService)
    {
        _toDoService = toDoService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        try
        {
            return Ok(await _toDoService.GetAll());
        }
        catch (Exception e)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
        }
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        try
        {
            return Ok(await _toDoService.GetById(id));
        }
        catch (Exception e)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
        }
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody]ToDo toDo)
    {
        try
        {
            return Ok(await _toDoService.Create(toDo));
        }
        catch (Exception e)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
        }
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody]ToDo toDo)
    {
        try
        {
            return Ok(await _toDoService.Update(toDo));
        }
        catch (Exception e)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
        }
    }

    [HttpDelete]
    public async Task<IActionResult> Delete(int id)
    {
        try
        {
            return Ok(await _toDoService.Delete(id));
        }
        catch (Exception e)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
        }
    }
}