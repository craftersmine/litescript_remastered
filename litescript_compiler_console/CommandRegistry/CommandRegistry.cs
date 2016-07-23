using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace craftersmine.LiteScript.Compiler.CommandParser
{
    public sealed class CommandRegistry
    {
        public static List<Command> Commands { get; set; } = new List<Command>();

        public static void RegisterCommand(Command cmd)
        {
            Commands.Add(cmd);
        }
    }
}
