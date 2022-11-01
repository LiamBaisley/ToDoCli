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
    [Verb("add", HelpText = "Adds a new todo to the list of Todos")]
    public class AddCommand: ICommand
    {
        [Option('t', "Title", HelpText ="The title of the Todo")]
        public string Title { get; set; }
        public void Execute(TodoContext context)
        {
            if (Title is not null)
            {
                context.Todos.Add(new Todo() { Title = Title });
                context.SaveChanges();
                Console.WriteLine("Todo added successfully!");
            }
            else
            {
                Console.WriteLine("Please add a Todo title and then press enter:");
                Console.Write("Title -> ");
                Title = Console.ReadLine();
                context.Todos.Add(new Todo() { Title = Title });
                context.SaveChanges();
                Console.WriteLine("Todo added successfully!");
            }
        }
    }
}
