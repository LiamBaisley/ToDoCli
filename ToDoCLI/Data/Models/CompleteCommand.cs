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
        [Option('i', "index", HelpText = "The 1 based index of the Todo")]
        public int Index { get; set; }
        public void Execute(TodoContext context)
        {
            if (Index > 0)
            {
                var todos = context.Todos.ToList();
                Todo todo = todos[Index - 1];
                Console.WriteLine(todo.Title + "This is the title");
                context.Todos.Remove(todo);
                context.SaveChanges();
            }
            else
            {
                List<Todo> allTodos = context.Todos.ToList();

                Helpers.WriteInitialMenu(allTodos);

                Helpers.KeyHandler(allTodos, context);
            }
        }
    }
}
