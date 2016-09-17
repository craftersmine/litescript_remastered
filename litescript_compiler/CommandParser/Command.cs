using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace craftersmine.LiteScript.Compiler.CommandParser
{
    public sealed class Command
    {
        public string   CSharpPattern   { get; set; }
        public string[] Arguments       { get; set; }
        public string   LSPattern       { get; set; }
        public string   RegexPattern    { get; private set; }

        public Command(string cSharpPattern, string lSPattern, string[] args)
        {
            CSharpPattern = cSharpPattern;
            LSPattern = lSPattern;
            Arguments = args;

            string regexPattern = null;
            for (int i = 0; i < args.Length; i++)
            {
                args[i] = "{" + args[i] + "}";
            }
            foreach (var arg in args)
            {
                regexPattern = LSPattern.Replace(arg, "(.*?)");
            }
            RegexPattern = regexPattern;
        }
    }
}
