using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using craftersmine.LiteScript.Compiler.Core;
using System.Diagnostics;

namespace litescript_compiler_console
{
    class Program
    {
        static void Main(string[] args)
        {
            ProcessStartInfo psi = new ProcessStartInfo();
            psi.Arguments = @"/out:D:\test.exe /t:exe D:\generated.cs";
            psi.FileName = @"C:\Windows\Microsoft.NET\Framework\v4.0.30319\csc.exe";
            psi.RedirectStandardOutput = true;
            psi.UseShellExecute = false;
            Process proc = new Process();
            proc.StartInfo = psi;
            proc.Start();

            using (var output = proc.StandardOutput)
            {
                while (!output.EndOfStream)
                {
                    string ln = output.ReadLine();
                    if (ln.Contains("error") || ln.Contains("warning"))
                    {
                        Console.WriteLine(ln);
                    }
                }
            }

                Console.ReadKey();
        }
    }
}
