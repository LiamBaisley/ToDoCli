using CommandLine;
using System;
using ToDoCLI.Data;
using ToDoCLI.Data.Context;
using ToDoCLI.Data.Models;

namespace ToDoCLI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using(TodoContext context = new TodoContext())
            {
                //context.Todos.Add(new Models.Todo() { Title = "this is a todo" });
                //context.Todos.Add(new Models.Todo() { Title = "this is another todo" });
                //context.Todos.Add(new Models.Todo() { Title = "this is the todo" });
                //context.SaveChanges();

                Parser.Default.ParseArguments<AddCommand, CompleteCommand>(args).
                WithParsed<AddCommand>(options => options.Execute(context))
                .WithParsed<CompleteCommand>(options => options.Execute(context));
            }
        }
    }
}
