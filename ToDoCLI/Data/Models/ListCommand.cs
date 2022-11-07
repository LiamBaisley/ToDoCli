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
                var todos = CheckDir(context);
                if (todos.Any())
                {
                    Helpers.WriteTodos(todos);
                }
                else
                {
                    Console.WriteLine("No Todos for current project, here are all your active Todos");
                    //Helpers.WriteTodos(context.Todos.ToList());
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
                if (
                    todo.ProjectPath is not null 
                    && currentDir.Substring(0, todo.ProjectPath.Length-1) == todo.ProjectPath.Substring(0, todo.ProjectPath.Length - 1)
                    )
                {
                    todoList.Add(todo);
                }
            }

            return todoList;
        }
    }
}
