using CommandLine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoCLI.Data.Context;

namespace ToDoCLI.Data.Models
{
    [Verb("add", HelpText = "Adds a new todo to the list of Todos")]
    public class AddCommand: ICommand
    {
        [Option('t', "Title", HelpText ="The title of the Todo")]
        public string Title { get; set; }
        public void Execute(TodoContext context)
        {
            context.Todos.Add(new ToDoCLI.Models.Todo() { Title = Title });
            context.SaveChanges();
            Console.WriteLine("Todo added successfully!");
        }
    }
}
