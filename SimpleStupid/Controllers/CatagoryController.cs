using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SimpleStupid.Data;
using SimpleStupid.Model;

namespace SimpleStupid.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly AppDbContext _context;
        public CategoryController(AppDbContext pContext)
        {
            _context = pContext;
        }

        [HttpGet]
        public async Task<List<Category>> Get()
        {
            return await _context.Catagories.ToListAsync();
        }
    }
}
