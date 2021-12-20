using Microsoft.EntityFrameworkCore;
using WhatToDo.Domain.Entities;
using WhatToDo.Domain.Repositories;
using WhatToDo.Infrastructure.Data;

namespace WhatToDo.Infrastructure.Repositories;

public class TodoRepository : ITodoRepository
{
    private readonly AppDbContext _context;

    public TodoRepository(AppDbContext context)
    {
        _context = context;
    }
    public async Task<IEnumerable<Todo>> GetAllAsync()
    {
        var todos = await _context.Todos.ToListAsync();
        return todos;
    }

    public async Task<Todo> GetByIdAsync(Guid id)
    {
        var todo = await _context.Todos.FirstOrDefaultAsync(t => t.Id == id);
        return todo;
    }

    public async Task<Todo> CreateAsync(Todo entity)
    {
        await _context.Todos.AddAsync(entity);
        await _context.SaveChangesAsync();
        return entity;
    }

    public async Task<Todo> UpdateAsync(Guid id, Todo entity)
    {
        throw new NotImplementedException();
    }

    public async Task DeleteAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<Todo>> GetByCompletionAsync(bool isCompleted)
    {
        throw new NotImplementedException();
    }
}