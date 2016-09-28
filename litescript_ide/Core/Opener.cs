using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
using Nini.Ini;
using craftersmine.LiteScript.Ide.Core.Data;

namespace craftersmine.LiteScript.Ide.Core
{
    public sealed class Opener
    {
        public enum OpenResult
        {
            Success, Error
        }

        public delegate void OnOpeningFileDelegate(object sender, OnOpeningFileEventArgs e);
        public delegate void OnOpenedFileDelegate(object sender, OnOpenedFileEventArgs e);

        public static event OnOpeningFileDelegate OnOpeningFileEvent;
        public static event OnOpenedFileDelegate OnOpenedFileEvent;

        public static void OpenProject(string projFile)
        {
            OnOpeningFileEventArgs _oofea = new OnOpeningFileEventArgs();
            OnOpenedFileEventArgs _oodfea = new OnOpenedFileEventArgs();
            try
            {
                _oofea.ProgressStyle = ProgressBarStyle.Continuous;
                OnOpeningFileEvent(null, _oofea);
                IniDocument _projF = new IniDocument(projFile);
                _oofea.Progress = 25;
                OnOpeningFileEvent(null, _oofea);
                string _projname = _projF.Sections["PROJMETA"].GetValue("project_name");
                string _projroot = _projF.Sections["PROJMETA"].GetValue("project_root");
                _oofea.Progress = 35;
                OnOpeningFileEvent(null, _oofea);
                string _filenameCtor = _projname + ".litescript";
                string _fileCtor = Path.Combine(_projroot, _filenameCtor);
                Project _proj = new Project();
                _oofea.Progress = 50;
                OnOpeningFileEvent(null, _oofea);
                _proj.ProjName = _projname;
                _proj.ProjRoot = _projroot;
                _oofea.Progress = 75;
                OnOpeningFileEvent(null, _oofea);
                string _fContents = File.ReadAllText(_fileCtor);
                _proj.FileContents = _fContents;
                _oodfea.Result = OpenResult.Success;
                _oodfea.ProjectFile = _proj;
                OnOpenedFileEvent(null, _oodfea);
            }
            catch
            {
                _oodfea.Result = OpenResult.Error;
                OnOpenedFileEvent(null, _oodfea);
                MessageBox.Show(StaticData.LocaleProv.GetValue("messages.errors.io-file-load-error"), StaticData.LocaleProv.GetValue("messages.titles.error"), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static string OpenScript(string scriptFile)
        {
            OnOpeningFileEventArgs _oofea = new OnOpeningFileEventArgs();
            _oofea.ProgressStyle = ProgressBarStyle.Marquee;
            OnOpenedFileEventArgs _oodfea = new OnOpenedFileEventArgs();
            OnOpeningFileEvent(null, _oofea);
            try
            {
                string _file = File.ReadAllText(scriptFile);
                _oodfea.Result = OpenResult.Success;
                OnOpenedFileEvent(null, _oodfea);
                return _file;
            }
            catch
            {
                MessageBox.Show(StaticData.LocaleProv.GetValue("messages.errors.io-file-load-error"), StaticData.LocaleProv.GetValue("messages.titles.error"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                _oodfea.Result = OpenResult.Error;
                OnOpenedFileEvent(null, _oodfea);
                return null;
            }
        }
    }

    public sealed class OnOpenedFileEventArgs
    {
        public Opener.OpenResult Result { get; set; }
        public Project ProjectFile { get; set; }
    }

    public sealed class OnOpeningFileEventArgs
    {
        public int Progress { get; set; }
        public ProgressBarStyle ProgressStyle { get; set; }
    }
}
