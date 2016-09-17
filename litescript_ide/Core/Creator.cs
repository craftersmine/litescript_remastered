using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace craftersmine.LiteScript.Ide.Core
{
    public sealed class Creator
    {
        public enum CreationType
        {
            Project, Script
        }

        public enum CreationResult
        {
            Success, Error
        }
        public delegate void OnCreationProgressChanged(object sender, OnCreationProgressChangedEventArgs e);
        public delegate void OnCreationCompleted(object sender, OnCreationCompletedEventArgs e);

        public static event OnCreationProgressChanged OnCreationProgressChangedEvent;
        public static event OnCreationCompleted OnCreationCompletedEvent;

        public static void Create(CreationType ct, string parentDir, string name)
        {
            OnCreationProgressChangedEventArgs _ocpcea = new OnCreationProgressChangedEventArgs();
            OnCreationCompletedEventArgs _occea = new OnCreationCompletedEventArgs();
            _ocpcea.Progress = 0;
            _ocpcea.ProgressStyle = ProgressBarStyle.Continuous;
            OnCreationProgressChangedEvent(null, _ocpcea);
            switch(ct)
            {
                case CreationType.Project:
                    string _rootDirCtor = Path.Combine(parentDir, name);
                    Directory.CreateDirectory(_rootDirCtor);
                    _ocpcea.Progress = 25;
                    OnCreationProgressChangedEvent(null, _ocpcea);
                    string _buildDirCtor = Path.Combine(_rootDirCtor, "build");
                    Directory.CreateDirectory(_buildDirCtor);
                    _ocpcea.Progress = 50;
                    Nini.Ini.IniWriter iniw = new Nini.Ini.IniWriter(Path.Combine(_rootDirCtor, name + ".lsproj"));
                    iniw.WriteSection("PROJMETA", "This is a project metadata file. Used for load in LiteScript IDE");
                    iniw.WriteKey("project_root", _rootDirCtor);
                    iniw.WriteKey("project_name", name);
                    iniw.Close();
                    _ocpcea.Progress = 75;
                    OnCreationProgressChangedEvent(null, _ocpcea);
                    string _file = Path.Combine(_rootDirCtor, name + ".litescript");
                    string _fileContents = string.Format("Use System;\r\nUse System.IO;\r\n\r\nNamespace {0}\r\n#\r\n\tVisibility:Public StaticObj DefClass EntryPoint\r\n\t#\r\n\t\tVisibility:Public StaticObj Void Main(String[] CommandLineArguments)\r\n\t\t#\r\n\t\t\t\r\n\t\t$\r\n\t$\r\n$", name).Replace("#", "{").Replace("$", "}");
                    try
                    {
                        File.WriteAllText(_file, _fileContents);
                        _ocpcea.Progress = 100;
                        _occea.Result = CreationResult.Success;
                        OnCreationCompletedEvent(null, _occea);
                    }
                    catch
                    {
                        // LOCALE: Error: file cannot be written
                        MessageBox.Show("{ERROR_FILE_CANNOT_BE_WRITTEN}", "{ERROR}", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        _ocpcea.Progress = 100;
                        _occea.Result = CreationResult.Error;
                        OnCreationCompletedEvent(null, _occea);
                    }
                    break;
                case CreationType.Script:
                    string _rootDir = parentDir;
                    _ocpcea.ProgressStyle = ProgressBarStyle.Marquee;
                    OnCreationProgressChangedEvent(null, _ocpcea);
                    string _fileScript = Path.Combine(_rootDir, name + ".litescript");
                    string _fileContents1 = string.Format("Use System;\r\nUse System.IO;\r\n\r\nNamespace {0}\r\n#\r\n\tVisibility:Public StaticObj DefClass EntryPoint\r\n\t#\r\n\t\tVisibility:Public StaticObj Void Main(String[] CommandLineArguments)\r\n\t\t#\r\n\t\t\t\r\n\t\t$\r\n\t$\r\n$", name).Replace("#", "{").Replace("$", "}");
                    try
                    {
                        File.WriteAllText(_fileScript, _fileContents1);
                        _ocpcea.Progress = 100;
                        _occea.Result = CreationResult.Success;
                        OnCreationCompletedEvent(null, _occea);
                    }
                    catch
                    {
                        // LOCALE: Error: file cannot be written
                        MessageBox.Show("{ERROR_FILE_CANNOT_BE_WRITTEN}", "{ERROR}", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        _ocpcea.Progress = 100;
                        _occea.Result = CreationResult.Error;
                        OnCreationCompletedEvent(null, _occea);
                    }
                    break;
            }
        }
    }

    public sealed class OnCreationCompletedEventArgs
    {
        public Creator.CreationResult Result { get; set; }
    }

    public sealed class OnCreationProgressChangedEventArgs : EventArgs
    {
        public int Progress { get; set; }
        public ProgressBarStyle ProgressStyle { get; set; }
    }
}
