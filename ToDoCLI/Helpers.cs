using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ToDoCLI.Data.Context;
using ToDoCLI.Models;

namespace ToDoCLI
{
    public static class Helpers
    {
        public static int selectedIndex = 0;
        
        public static void WriteMenu(List<Todo> todos, Todo selectedTodo)
        {
            Console.Clear();

            foreach(Todo todo in todos)
            {
                if (todo == selectedTodo)
                {
                    Console.Write(">");
                }
                else
                {
                    Console.Write(" ");
                }
                Console.WriteLine(todo.Title);
            }

        }

        public static void WriteInitialMenu(List<Todo> todos)
        {
            Console.Clear();
            int index = 0;

            foreach (Todo todo in todos)
            {
                if (index == 0)
                {
                    Console.Write(">");
                    index++;
                }
                else
                {
                    Console.Write(" ");
                }
                Console.WriteLine(todo.Title);
            }
        }

        public static void WriteFolders(string[] folders, string selectedFolder)
        {
            Console.Clear();

            foreach (string folder in folders)
            {
                if (folder == selectedFolder)
                {
                    Console.Write(">");
                }
                else
                {
                    Console.Write(" ");
                }
                Console.WriteLine(folder);
            }
        }

        public static void WriteTodos(List<Todo> todos)
        {
            if (todos.Any())
            {
                Console.Clear();
                int counter = 0;
                foreach (var todo in todos)
                {
                    counter++;
                    Console.WriteLine($"{counter}  -   {todo.Title}");
                }
            }
            else
            {
                Console.WriteLine("Nothing to see here, looks like all your Todos are ToDone!!");
            }
        }



        public static void KeyHandler(List<Todo> Todos, TodoContext context)
        {
            int index = 0;
            bool cont = true;
            ConsoleKeyInfo keyInfo;
            do
            {
                keyInfo = Console.ReadKey();

                // Handle each key input (down arrow will write the menu again with a different selected item)
                if (keyInfo.Key == ConsoleKey.DownArrow)
                {
                    if (index + 1 < Todos.Count)
                    {
                        index++;
                        Helpers.WriteMenu(Todos, Todos[index]);
                    }
                }
                if (keyInfo.Key == ConsoleKey.UpArrow)
                {
                    if (index - 1 >= 0)
                    {
                        index--;
                        Helpers.WriteMenu(Todos, Todos[index]);
                    }
                }
                // Handle different action for the option
                if (keyInfo.Key == ConsoleKey.Enter)
                {
                    if (Todos.Count > 1)
                    { 
                        Todos[index].Complete(Todos[index], context);
                        index = 0;
                        Todos.Remove(Todos[index]);
                        Helpers.WriteInitialMenu(Todos);
                    }
                    else
                    {
                        Todos[index].Complete(Todos[index], context);
                        index = 0;
                        Todos.Remove(Todos[index]);
                        Console.WriteLine("No more todo's to complete!");
                        cont = false;
                    }
                }
            }
            while (keyInfo.Key != ConsoleKey.X && cont);

            Console.ReadKey();

        }

        public static int ProjectDirectorySelector(string[] folders)
        {
            int index = 0;
            ConsoleKeyInfo keyInfo;
            do
            {
                keyInfo = Console.ReadKey();

                if (keyInfo.Key == ConsoleKey.DownArrow)
                {
                    if (index + 1 < folders.Length)
                    {
                        index++;
                        Helpers.WriteFolders(folders, folders[index]);
                    }
                }
                if (keyInfo.Key == ConsoleKey.UpArrow)
                {
                    if (index - 1 >= 0)
                    {
                        index--;
                        Helpers.WriteFolders(folders, folders[index]);
                    }
                }
                // Handle different action for the option
                if (keyInfo.Key == ConsoleKey.Enter)
                {
                    return index;
                }
            } 
            while (keyInfo.Key != ConsoleKey.X);

            return -1;
        }

        public static List<Todo> CheckDir(TodoContext context)
        {
            var todos = context.Todos.ToList();
            var todoList = new List<Todo>();
            var currentDir = Directory.GetCurrentDirectory();

            foreach (var todo in todos)
            {
                if (
                    todo.ProjectPath != "noproject"
                    && currentDir.Substring(0, todo.ProjectPath.Length - 1) == todo.ProjectPath.Substring(0, todo.ProjectPath.Length - 1)
                )
                {
                    todoList.Add(todo);
                }
            }

            return todoList;
        }

        public static void CompleteLocalTodoHandler(List<Todo> todos, TodoContext context, int index)
        {
            if (todos.Any() && index > 0)
            {
                context.Todos.Remove(todos[index -1]);
                context.SaveChanges();
            }
            else if(todos.Any() && index == 0)
            {
                WriteInitialMenu(todos);
                KeyHandler(todos, context);
            }
            else
            {
                Console.WriteLine("No Todos for current project, here are all your active Todos");

                WriteInitialMenu(context.Todos.ToList());
            }
        }

        public static void ListLocalTodoHandler(List<Todo> todos, TodoContext context)
        {
            if (todos.Any())
            {
                WriteTodos(todos);
            }
            else
            {
                Console.WriteLine("No Todos for current project, here are all your active Todos");

                WriteTodos(context.Todos.ToList());
            }
        }

        public static void WithIndexForAllHandler(TodoContext context, int Index)
        {
            var todos = context.Todos.ToList();
            Todo todo = todos[Index - 1];
            context.Todos.Remove(todo);
            context.SaveChanges();
        }

        public static void InteractiveMenuHandler(List<Todo> todos, TodoContext context)
        {
            Helpers.WriteInitialMenu(todos);

            Helpers.KeyHandler(todos, context);
        }
    }

}
