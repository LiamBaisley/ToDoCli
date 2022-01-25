using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoCLI.Data.Context;

namespace ToDoCLI.Data
{
    public interface ICommand
    {
        void Execute(TodoContext context);
    }
}
