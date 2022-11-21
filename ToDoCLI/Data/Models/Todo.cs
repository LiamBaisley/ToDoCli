﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoCLI.Data.Context;

namespace ToDoCLI.Models
{
    [Table("Todos")]
    public class Todo: BaseClass
    {
        public string Title { get; set; }

        public string ProjectPath { get; set; }

        public List<Todo> Complete(List<Todo> todos,int index, TodoContext context)
        {
            context.Todos.Remove(todos[index]);
            context.SaveChanges();
            return todos;
        }

        public void Add(Todo todo, TodoContext context)
        {
             context.Todos.Add(todo);
             context.SaveChanges();
        }
    }
}
