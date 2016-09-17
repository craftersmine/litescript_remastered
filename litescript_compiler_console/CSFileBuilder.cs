using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using craftersmine.LiteScript.Compiler.CommandParser;
using System.Text.RegularExpressions;
using System.IO;

namespace craftersmine.LiteScript.Compiler.Core
{
    public sealed class CSFileBuilder
    {
        public List<string>          CSFileContents { get; set; }
        public CompilerCandidateFile CandidateFile  { get; private set; }

        public CSFileBuilder(CompilerCandidateFile candidateFile)
        {
            CandidateFile = candidateFile;
            CSFileContents = new List<string>();
        }

        public void RunCSBuild()
        {
            foreach (Keyword kwd in CommandRegistry.Keywords)
            {
                CandidateFile.AllFile = CandidateFile.AllFile.Replace(kwd.LiteScriptKeyword, kwd.CSharpKeyword);
            }
            CandidateFile.AllFile = CandidateFile.AllFile.Replace("#", "//");
            try
            {
                string pathCtor = Path.GetDirectoryName(CandidateFile.FilePath) + "build\\";
                Directory.CreateDirectory(pathCtor);
                File.WriteAllText(
                    pathCtor + 
                        Path.GetFileName(CandidateFile.FilePath)
                        .Replace("lscript", "cs"),
                    CandidateFile.AllFile);
            }
            catch
            {
                Console.WriteLine("ERROR_FILE_CANNOT_BE_WRITTEN!");
            }
        }
    }
}
