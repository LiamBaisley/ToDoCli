using System;
using System.Collections.Generic;
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

        public static void WriteHelpMessage()
        {

        }

        public static void KeyHandler(List<Todo> Todos, TodoContext context)
        {
            int index = 0;
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
                    Todos = Todos[index].Complete(Todos[index], context);
                    index = 0;
                    Helpers.WriteInitialMenu(Todos);
                }
            }
            while (keyInfo.Key != ConsoleKey.X);

            Console.ReadKey();

        }
    }

}
