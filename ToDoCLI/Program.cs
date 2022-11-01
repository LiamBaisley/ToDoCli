using CommandLine;
using System;
using System.Diagnostics.Contracts;
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
                Parser.Default.ParseArguments<AddCommand, CompleteCommand, ListCommand>(args).
                WithParsed<AddCommand>(options => options.Execute(context))
                .WithParsed<CompleteCommand>(options => options.Execute(context))
                .WithParsed<ListCommand>(options => options.Execute(context));
            }
        }
    }
}
