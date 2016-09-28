using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using craftersmine.LiteScript.Ide.Core.Data;

namespace craftersmine.LiteScript.Ide.Core
{
    public sealed class Saver
    {
        public delegate void OnSavingFileDelegate(object sender, OnSavingFileEventArgs e);
        public delegate void OnSavedFileDelegate(object sender, OnSavedFileEventArgs e);

        public static event OnSavingFileDelegate OnSavingFileEvent;
        public static event OnSavedFileDelegate OnSavedFileEvent;

        public enum SaveResult { Success, Error }

        public static void SaveProject(Project proj)
        {
            OnSavingFileEventArgs _osfea = new OnSavingFileEventArgs();
            OnSavedFileEventArgs _osdfea = new OnSavedFileEventArgs();

            //string _scriptPathCtor = Path.Combine(proj.ProjRoot, proj.ProjName);
            string _scriptFileNameCtor = proj.ProjName + ".litescript";
            string _scriptFileCtor = Path.Combine(proj.ProjRoot, _scriptFileNameCtor);
            _osfea.Progress = 20;
            _osfea.ProgressStyle = ProgressBarStyle.Continuous;
            OnSavingFileEvent(null, _osfea);
            try
            {
                File.WriteAllText(_scriptFileCtor, proj.FileContents);
                _osfea.Progress = 75;
                _osdfea.Result = SaveResult.Success;
                OnSavedFileEvent(null, _osdfea);
            }
            catch
            {
                _osdfea.Result = SaveResult.Error;
                OnSavedFileEvent(null, _osdfea);
                MessageBox.Show(StaticData.LocaleProv.GetValue("messages.errors.io-file-cannot-be-written"), StaticData.LocaleProv.GetValue("messages.titles.error"), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static void SaveScript(string path, string contents)
        {
            OnSavingFileEventArgs _osfea = new OnSavingFileEventArgs();
            OnSavedFileEventArgs _osdfea = new OnSavedFileEventArgs();
            
            _osfea.Progress = 20;
            _osfea.ProgressStyle = ProgressBarStyle.Continuous;
            OnSavingFileEvent(null, _osfea);
            try
            {
                File.WriteAllText(path, contents);
                _osfea.Progress = 75;
                _osdfea.Result = SaveResult.Success;
                OnSavedFileEvent(null, _osdfea);
            }
            catch
            {
                _osdfea.Result = SaveResult.Error;
                OnSavedFileEvent(null, _osdfea);
                MessageBox.Show(StaticData.LocaleProv.GetValue("messages.errors.io-file-cannot-be-written"), StaticData.LocaleProv.GetValue("messages.titles.error"), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }

    public sealed class OnSavingFileEventArgs
    {
        public int Progress { get; set; }
        public ProgressBarStyle ProgressStyle { get; set; }
    }

    public sealed class OnSavedFileEventArgs
    {
        public Saver.SaveResult Result { get; set; }
    }
}
