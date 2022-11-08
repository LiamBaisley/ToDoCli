using CommandLine;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.IO;
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
        [Option('i', "index", HelpText = "The 1 based index of the Todo")]
        public int Index { get; set; }
        [Option('e', "All", HelpText = "Specifies that you would like to see all Todos instead of project specific Todos")]
        public bool ForAll { get; set; }

        public void Execute(TodoContext context)
        {
            if (ForAll && Index > 0)
            {
                Helpers.WithIndexForAllHandler(context, Index);
            }
            else if ((!ForAll && Index > 0) || (!ForAll && Index == 0))
            {
                var todos = Helpers.CheckDir(context);
                Helpers.CompleteLocalTodoHandler(todos, context, Index);
            }
            else if (ForAll)
            {
                List<Todo> allTodos = context.Todos.ToList();

                Helpers.InteractiveMenuHandler(allTodos, context);
            }
        }
    }
}
