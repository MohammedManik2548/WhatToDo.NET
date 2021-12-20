using Microsoft.EntityFrameworkCore;
using WhatToDo.Domain.Entities;

namespace WhatToDo.Infrastructure.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<Todo> Todos { get; set; }
}