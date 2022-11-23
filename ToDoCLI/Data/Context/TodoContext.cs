using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;
using Microsoft.DotNet.PlatformAbstractions;
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
            string path = ApplicationEnvironment.ApplicationBasePath;
            optionsBuilder.UseSqlite($@"Data Source={path}/TodoDB.db;");
        }
    }
}
