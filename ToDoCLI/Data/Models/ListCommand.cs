using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommandLine;
using ToDoCLI.Data.Context;
using ToDoCLI.Models;

namespace ToDoCLI.Data.Models
{
    [Verb("list", HelpText = "Lists all the currently active Todos")]
    public class ListCommand : ICommand
    {
        [Option('e', "All", HelpText = "Lists all active todos. not just folder specific todos")]
        public bool ListAll { get; set; }
        public void Execute(TodoContext context)
        {
            if (ListAll)
            {
                var todos = context.Todos.ToList();
                Helpers.WriteTodos(todos);
            }
            else
            {
                var todos = Helpers.CheckDir(context);
                Helpers.ListLocalTodoHandler(todos, context);
            }
        }
    }
}
