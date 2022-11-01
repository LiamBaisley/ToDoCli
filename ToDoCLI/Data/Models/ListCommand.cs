using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommandLine;
using ToDoCLI.Data.Context;

namespace ToDoCLI.Data.Models
{
    [Verb("list", HelpText = "Lists all the currently active Todos")]
    public class ListCommand : ICommand
    {
        public void Execute(TodoContext context)
        {
            var todos = context.Todos.ToList();
            Helpers.WriteTodos(todos);
        }
    }
}
