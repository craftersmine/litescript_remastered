using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace craftersmine.LiteScript.Compiler.CommandParser
{
    public sealed class Command
    {
        public string   CSharpPattern   { get; set; }
        public byte     CompiledByte    { get; set; }
        public string[] Arguments       { get; set; }

        public Command(string cSharpPattern, byte compiledByte, string[] args)
        {
            CSharpPattern = cSharpPattern;
            CompiledByte = compiledByte;
            Arguments = args;
        }
    }
}
