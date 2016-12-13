using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using craftersmine.LiteScript.Compiler.Core;
using craftersmine.LiteScript.Compiler.Init;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;

namespace craftersmine.LiteScript.Compiler
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                bool _isErrorExists = false;
                Stopwatch _elapsedTimer = new Stopwatch();
                Console.Title = "LiteScript Compiler";
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("LiteScript Compiler (c) craftersmine - 2016");
                Console.WriteLine();
                Console.ResetColor();
                _elapsedTimer.Start();
                Dictionary<string, string> _runArgs = new Dictionary<string, string>();
                foreach (string arg in args)
                {
                    string[] _arg = arg.Split('=');
                    _runArgs.Add(_arg[0], _arg[1]);
                }

                string _outt = "";
                _runArgs.TryGetValue("-outt", out _outt);

                string _f = "";
                _runArgs.TryGetValue("-f", out _f);
                if (string.IsNullOrEmpty(_f) || string.IsNullOrWhiteSpace(_f))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(" BUILD FAILED! " + _elapsedTimer.Elapsed + " No source script file!");
                    Console.ResetColor();
                    Environment.Exit(0);
                }

                Console.Title += " - " + _f;

                _outt = _outt.ToLower();

                OutputType _outtype = OutputType.OnlyCompiledScript;

                switch (_outt)
                {
                    case "exe":
                        Console.WriteLine(" Got info to build an Console EXE File...");
                        break;
                    case "library":
                        Console.WriteLine(" Got info to build an DLL Library File...");
                        break;
                    case "winexe":
                        Console.WriteLine(" Got info to build an Windows EXE File... WARNING! This ability is experimental! Use at own risk");
                        break;
                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine(" BUILD FAILED! " + _elapsedTimer.Elapsed + " Incorrect output file type!");
                        Console.ResetColor();
                        Environment.Exit(0);
                        break;
                }

                CompilerCandidateFile ccf = new CompilerCandidateFile(_f, _outtype);
                CSFileBuilder _builder = new CSFileBuilder(ccf);
                Console.WriteLine(" Gathering info about CSharp keywords...");
                CommandRegistrator.RegisterAllCommands();
                Console.WriteLine(" Building a CSharp file...");
                _builder.RunCSBuild();

                Console.WriteLine(" Running a CSharp compiler...");
                ProcessStartInfo psi = new ProcessStartInfo();
                string csF = Path.GetDirectoryName(ccf.FilePath)
                            + "\\build\\" +
                            Path.GetFileName(ccf.FilePath)
                            .Replace("litescript", "cs");
                string exeF = csF.Replace("cs", "exe");
                psi.Arguments = string.Format(@"/out:{0} /t:{1} {2}", exeF, _outt, csF);
                var frameworkPath = RuntimeEnvironment.GetRuntimeDirectory();
                var cscPath = Path.Combine(frameworkPath, "csc.exe");
                psi.FileName = cscPath;
                psi.RedirectStandardOutput = true;
                psi.UseShellExecute = false;
                Process proc = new Process();
                proc.StartInfo = psi;
                Console.WriteLine();
                try
                {
                    proc.Start();

                    using (var output = proc.StandardOutput)
                    {
                        while (!output.EndOfStream)
                        {
                            string ln = output.ReadLine();
                            if (ln.Contains("error"))
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine(" " + ln);
                                _isErrorExists = true;
                                Console.ResetColor();
                            }
                            else if (ln.Contains("warning"))
                            {
                                Console.ForegroundColor = ConsoleColor.Yellow;
                                Console.WriteLine(" " + ln);
                                Console.ResetColor();
                            }
                        }
                    }
                }
                catch (Exception e)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(" BUILD FAILED! " + _elapsedTimer.Elapsed + " " + e.Message);
                    Console.ResetColor();
                    Environment.Exit(0);
                }
                Console.WriteLine();
                try
                {
                    proc.WaitForExit();
                    Console.WriteLine(" Removing a CSharp file...");
                    File.Delete(csF);
                }
                catch (Exception e)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(" BUILD FAILED! " + _elapsedTimer.Elapsed + " " + e.Message);
                    Console.ResetColor();
                    Environment.Exit(0);
                }
                _elapsedTimer.Stop();
                Console.WriteLine();
                if (!_isErrorExists)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("       BUILD SUCESSFUL! Elapsed time: " + _elapsedTimer.Elapsed);
                    Console.ResetColor();
                }
                else if (_isErrorExists)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("       BUILD FAILED! Elapsed time: " + _elapsedTimer.Elapsed);
                    Console.ResetColor();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("ERR:" + e.Message);
                Console.WriteLine("STC:" + e.StackTrace);
                Console.WriteLine("SRC:" + e.Source);
                Console.WriteLine("INE:" + e.InnerException);
                Console.ReadKey();
            }
        }
    }
}
