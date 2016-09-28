using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using craftersmine.LiteScript.Ide.Core.Data;

namespace craftersmine.LiteScript.Ide.Core
{
    public sealed class Builder
    {
        public enum BuildResult
        {
            Success, Error
        }

        public delegate void OnBuildRunningEventDelegate(object sender, OnBuildRunningEventArgs e);
        public delegate void OnBuildCompletedEventDelegate(object sender, OnBuildCompletedEventArgs e);

        public static event OnBuildRunningEventDelegate OnBuildRunningEvent;
        public static event OnBuildCompletedEventDelegate OnBuildCompletedEvent;

        public static void RunBuild(string scriptPath, bool runAfterCompile)
        {
            OnBuildCompletedEventArgs _obcea = new OnBuildCompletedEventArgs();
            OnBuildRunningEventArgs _obrea = new OnBuildRunningEventArgs();
            ProcessStartInfo _cplrsi = new ProcessStartInfo();
            _cplrsi.FileName = Application.StartupPath + "\\lscompiler.exe";
            _cplrsi.Arguments = string.Format("-f={0} -outt={1}", scriptPath, "exe");
            _cplrsi.RedirectStandardOutput = true;
            _cplrsi.UseShellExecute = false;
            Process _proc = new Process();
            _proc.StartInfo = _cplrsi;
            try
            {
                _proc.Start();

                using (var output = _proc.StandardOutput)
                {
                    while (!output.EndOfStream)
                    {
                        string innerln = output.ReadLine();
                        string ln = Encoding.UTF8.GetString(Encoding.Convert(Encoding.GetEncoding(866), Encoding.UTF8, output.CurrentEncoding.GetBytes(innerln)));
                        if (ln.Contains("error"))
                        {
                            _obcea.ErrorAndWarningList.Add(ln);
                            _obcea.Result = BuildResult.Error;
                        }
                        else if (ln.Contains("warning"))
                        {
                            _obcea.ErrorAndWarningList.Add(ln);
                        }
                        else if (ln.Contains("Got info to build an Console EXE File...") || ln.Contains("Got info to build an DLL Library File...") || ln.Contains("Got info to build an Windows EXE File... WARNING! This ability is experimental! Use at own risk"))
                        {
                            _obrea.Progress = 25;
                            OnBuildRunningEvent(null, _obrea);
                        }
                        else if (ln.Contains("Gathering info about CSharp keywords..."))
                        {
                            _obrea.Progress = 40;
                            OnBuildRunningEvent(null, _obrea);
                        }
                        else if (ln.Contains("Building a CSharp file..."))
                        {
                            _obrea.Progress = 50;
                            OnBuildRunningEvent(null, _obrea);
                        }
                        else if (ln.Contains("Running a CSharp compiler..."))
                        {
                            _obrea.Progress = 67;
                            OnBuildRunningEvent(null, _obrea);
                        }
                        else if (ln.Contains("Removing a CSharp file..."))
                        {
                            _obrea.Progress = 80;
                            OnBuildRunningEvent(null, _obrea);
                        }
                        else if (ln.Contains("BUILD SUCESSFUL!"))
                        {
                            _obrea.Progress = 99;
                            OnBuildRunningEvent(null, _obrea);
                            _obcea.Result = BuildResult.Success;
                            OnBuildCompletedEvent(null, _obcea);
                        }
                        else if (ln.Contains("BUILD FAILED!"))
                        {
                            _obrea.Progress = 99;
                            OnBuildRunningEvent(null, _obrea);
                            _obcea.Result = BuildResult.Error;
                            OnBuildCompletedEvent(null, _obcea);
                            runAfterCompile = false;
                        }
                        else if (ln.Contains("LiteScript Compiler (c) craftersmine - 2016"))
                        {
                            _obrea.Progress = 10;
                            OnBuildRunningEvent(null, _obrea);
                        }
                        else if (ln == "")
                        {
                            OnBuildRunningEvent(null, _obrea);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                _obcea.Result = BuildResult.Error;
                MessageBox.Show(StaticData.LocaleProv.GetValue("messages.errors.compiler-run-error"), StaticData.LocaleProv.GetValue("messages.titles.error"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                _obcea.ErrorAndWarningList.Add(StaticData.LocaleProv.GetValue("messages.errors.compiler-run-error"));
            }
            if (runAfterCompile)
                Process.Start(StaticData.CurrentProject.ProjRoot + "\\build\\" + StaticData.CurrentProject.ProjName + ".exe");
        }
    }

    public sealed class OnBuildCompletedEventArgs
    {
        public Builder.BuildResult Result { get; set; }
        public List<string> ErrorAndWarningList { get; set; } = new List<string>();
    }

    public sealed class OnBuildRunningEventArgs
    {
        public int Progress { get; set; }
        public ProgressBarStyle ProgressStyle { get; set; }
    }
}
