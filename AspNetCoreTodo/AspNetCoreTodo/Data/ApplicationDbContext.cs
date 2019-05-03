using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using AspNetCoreTodo.Models;

namespace AspNetCoreTodo.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<TodoItem> Items { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }
    }
}
