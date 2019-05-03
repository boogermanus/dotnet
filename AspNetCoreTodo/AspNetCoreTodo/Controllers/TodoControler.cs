using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AspNetCoreTodo.Services;
using AspNetCoreTodo.Models;

namespace AspNetCoreTodo.Controllers
{
    public class TodoController : Controller
    {
        private readonly ITodoItemService _todoItemService;

        public TodoController(ITodoItemService pService)
        {
            _todoItemService = pService;
        }
        public async Task<IActionResult> Index() 
        {
            return View(new TodoViewModel
            {
                Items = await _todoItemService.GetIncompleteItemsAsync()
            });
        }
    }
}