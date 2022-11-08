using CommandLine;
using System;
using System.Collections.Generic;
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
        [Option('q', "All", HelpText = "Specifies that you would like to see all Todos instead of project specific Todos")]
        public bool ForAll { get; set; }
        public void Execute(TodoContext context)
        {
            if (Index > 0)
            {
                var todos = context.Todos.ToList();
                Todo todo = todos[Index - 1];
                context.Todos.Remove(todo);
                context.SaveChanges();
            }
            else
            {
                if (ForAll)
                {
                    List<Todo> allTodos = context.Todos.ToList();

                    Helpers.WriteInitialMenu(allTodos);

                    Helpers.KeyHandler(allTodos, context);
                }
                else
                {
                    var todos = CheckDir(context);
                    if (todos.Any())
                    {
                        Helpers.WriteInitialMenu(todos);

                        Helpers.KeyHandler(todos, context);
                    }
                    else
                    {
                        Console.WriteLine("No Todos for current project, here are all your active Todos");

                        Helpers.WriteInitialMenu(context.Todos.ToList());

                        Helpers.KeyHandler(context.Todos.ToList(), context);
                    }
                }
            }
        }

        private List<Todo> CheckDir(TodoContext context)
        {
            var todos = context.Todos.ToList();
            var todoList = new List<Todo>();
            var currentDir = Directory.GetCurrentDirectory();

            foreach (var todo in todos)
            {
                Console.WriteLine(todo.ProjectPath);
                if (
                    todo.ProjectPath is not null
                    && currentDir.Substring(0, todo.ProjectPath.Length - 1) == todo.ProjectPath.Substring(0, todo.ProjectPath.Length - 1)
                )
                {
                    todoList.Add(todo);
                }
            }

            return todoList;
        }
    }
}
