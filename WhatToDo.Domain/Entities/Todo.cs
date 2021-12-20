namespace WhatToDo.Domain.Entities;

public class Todo : BaseEntity
{
    public string Description { get; set; }
    public bool IsCompleted { get; set; } = false;
    public DateTimeOffset CreatedAt { get; set; }=DateTimeOffset.Now;
    
    
}