using WhatToDo.Domain.Entities;

namespace WhatToDo.Domain.Repositories;

public interface ITodoRepository : IGenericRepository<Todo>
{
    Task<IEnumerable<Todo>> GetByCompletionAsync(bool isCompleted);
}