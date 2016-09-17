using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace craftersmine.LiteScript.Compiler.CommandParser
{
    public sealed class Keyword
    {
        public string LiteScriptKeyword { get; set; }
        public string CSharpKeyword { get; set; }

        public Keyword(string csKwd, string lsKwd)
        {
            LiteScriptKeyword = lsKwd;
            CSharpKeyword = csKwd;
        }
    }
}
