using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace craftersmine.LiteScript.Compiler.Core
{
    public sealed class CSFileBuilder
    {
        public List<string>          CSFileContents { get; set; }         = new List<string>();
        public CompilerCandidateFile CandidateFile  { get; private set; }

        public CSFileBuilder(CompilerCandidateFile candidateFile)
        {
            CandidateFile = candidateFile;
        }

        //public 
    }
}
