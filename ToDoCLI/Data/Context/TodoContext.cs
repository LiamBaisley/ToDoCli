using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoCLI.Models;

namespace ToDoCLI.Data.Context
{
    public class TodoContext: DbContext
    {
        public DbSet<Todo> Todos { get; set; }

        public TodoContext()
        {
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(@"Data Source=TodoDB.db;");
        }
    }
}
