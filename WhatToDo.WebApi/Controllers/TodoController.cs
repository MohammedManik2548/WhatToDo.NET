using Microsoft.AspNetCore.Mvc;
using WhatToDo.Domain.Entities;
using WhatToDo.Domain.Repositories;

namespace WhatToDo.WebApi.Controllers;

public class TodoController : BaseApiController
{
    private readonly ITodoRepository _todoRepository;

    public TodoController(ITodoRepository todoRepository)
    {
        _todoRepository = todoRepository;
    }
     
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Todo>>> GetAllAsync()
    {
        var todos = await _todoRepository.GetAllAsync();
        return Ok(todos);
    }

    [HttpGet("{id}",Name = "GetById")]
    public async Task<ActionResult<Todo>> GetByIdAsync(Guid id)
    {
        var todo = await _todoRepository.GetByIdAsync(id);
        if (todo == null)
        {
            return NotFound();
        }

        return Ok(todo);
    }
    
    [HttpPost]
    public async Task<IActionResult> CreateAsync(Todo newTodo)
    {
        var todo = await _todoRepository.CreateAsync(newTodo);
        return CreatedAtAction("GetById",new {id = todo.Id},todo);
    }
}