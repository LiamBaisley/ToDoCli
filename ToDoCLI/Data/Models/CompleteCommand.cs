using CommandLine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoCLI.Data.Context;
using ToDoCLI.Models;

namespace ToDoCLI.Data.Models
{
    [Verb("complete", HelpText = "Lists Todo's so you can complete any that are finished.")]
    public class CompleteCommand : ICommand
    {
        public void Execute(TodoContext context)
        {

            List<Todo> allTodos = context.Todos.ToList();

            Helpers.WriteInitialMenu(allTodos);

            Helpers.KeyHandler(allTodos, context);
            
        }
    }
}
