using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetCoreTodo.Data;
using AspNetCoreTodo.Models;
using Microsoft.EntityFrameworkCore;

namespace AspNetCoreTodo.Services
{
    public class TodoItemService : ITodoItemService
    {
        private readonly ApplicationDbContext _context;
        public TodoItemService(ApplicationDbContext pContext)
        {
            _context = pContext;
        }
        public async Task<TodoItem[]> GetIncompleteItemsAsync()
        {
            return await _context.Items
            .Where(i => !i.IsDone)
            .ToArrayAsync();
        }
    }
}