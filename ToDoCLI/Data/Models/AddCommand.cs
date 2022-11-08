using CommandLine;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using CommandLine.Text;
using ToDoCLI.Data.Context;
using ToDoCLI.Models;

namespace ToDoCLI.Data.Models
{
    [Verb("add", HelpText = "Adds a new todo to the list of Todos")]
    public class AddCommand: ICommand
    {
        [Option('t', "Title", HelpText ="The title of the Todo")]
        public string Title { get; set; }

        [Option('q', "Project", HelpText = "Adds a todo for a specific project")]
        public bool ForProject { get; set; }
        public void Execute(TodoContext context)
        {
            if (Title is not null)
            {
                AddWithTitle(context);
            }
            else
            {
                AddWithoutTitle(context);
            }
        }

        private void AddWithTitle(TodoContext context)
        {
            if (!ForProject)
            {
                context.Todos.Add(new Todo() { Title = Title, ProjectPath = "nopath" });
                context.SaveChanges();
                Console.WriteLine("Todo added successfully!");
            }
            else
            {
                ForProjectHandler(context);
            }
        }

        private void AddWithoutTitle(TodoContext context)
        {
            if (!ForProject)
            {
                Console.WriteLine("Please add a Todo title and then press enter:");
                Console.Write("Title -> ");
                Title = Console.ReadLine();
                context.Todos.Add(new Todo() { Title = Title, ProjectPath = "nopath"});
                context.SaveChanges();
                Console.WriteLine("Todo added successfully!");
            }
            else
            {
                ForProjectHandler(context);
            }
        }

        private void ForProjectHandler(TodoContext context)
        {
            var directory = Directory.GetCurrentDirectory();
            var slash = @"\";
            var folders = directory.Split("\\");
            Helpers.WriteFolders(folders, folders[0]);
            var folder = Helpers.ProjectDirectorySelector(folders);
            string projectDir = "";
            for (int i = 0; i <= folder; i++)
            {
                projectDir += $"{folders[i]}{slash}";
            }

            context.Todos.Add(new Todo() { Title = Title, ProjectPath = projectDir });
            context.SaveChanges();
            Console.WriteLine("Project specific Todo added successfully");
        }
    }
}
