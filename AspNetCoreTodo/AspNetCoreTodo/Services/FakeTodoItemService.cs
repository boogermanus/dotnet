using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AspNetCoreTodo.Models;

namespace AspNetCoreTodo.Services
{
    public class FakeTodoItemService : ITodoItemService
    {
        public Task<TodoItem[]> GetIncompleteItemsAsync()
        {
            return Task.FromResult(
                new [] {
                    new TodoItem
                    {
                        Title = "Learn ASP.NET Core",
                        DueAt = DateTimeOffset.Now.AddDays(2)
                    },
                    new TodoItem
                    {
                        Title = "Build some awesome apps",
                        DueAt = DateTimeOffset.Now.AddDays(7)
                    }
                }
            );
        }
    }
}