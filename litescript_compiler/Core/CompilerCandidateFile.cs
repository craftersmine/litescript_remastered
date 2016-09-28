using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace craftersmine.LiteScript.Compiler.Core
{
    public sealed class CompilerCandidateFile
    {
        public string     FilePath   { get; set; }
        public OutputType OutType    { get; set; }
        public string[]   ReadedFile { get; set; }
        public string     AllFile    { get; set; }

        public CompilerCandidateFile(string filePath, OutputType outType)
        {
            OutType = outType;
            FilePath = filePath;

            try
            {
                ReadedFile = File.ReadAllLines(FilePath);
                AllFile = File.ReadAllText(FilePath);
            }
            catch
            {
                string val = " Unable to load file {file} cause unknown error";
                Console.WriteLine(val.Replace("{file}", FilePath));
            }
        }
    }
}
