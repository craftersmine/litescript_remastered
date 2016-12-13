using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Nini.Ini;
using craftersmine.LocalizerLib;

namespace craftersmine.LiteScript.Ide.PluginManager
{
    public partial class Remove : Form
    {
        private string pluginname = "";
        private string[] reflibs = { };
        private string mainlib = "";
        private string _id;

        public enum Stage { CollectingData, Removing, End, Cancel, Close }
        public bool _isCloseNeeded = false;

        private Stage _stg = Stage.CollectingData;
        private LocalizationProvider _lprov = StaticData.LocaleProv;

        private List<string> _files = new List<string>();
        private string _resDir = "";
        private string _metafile = "";

        private string _l_finish;

        private bool _isSuccessful = true;

        public Remove(string id)
        {
            InitializeComponent();

            _id = id;

            string metafile = Path.Combine(StaticData.PluginsDir, _id + "_pkgmeta.pkgmeta");
            _metafile = metafile;

            if (File.Exists(metafile))
            {
                IniDocument _ini = new IniDocument(metafile);
                pluginname = _ini.Sections["Package"].GetValue("plugin-name");
                mainlib = _ini.Sections["Package"].GetValue("plugin-lib");
                reflibs = _ini.Sections["Package"].GetValue("referenced-libs").Split('|');

                plugin_name.Text = pluginname;
            }

            tip.Text = _lprov.GetValue("app.pluginmanager.remove-wizard.tip.start");
            cancel.Text = _lprov.GetValue("app.pluginmanager.remove-wizard.button.cancel");
            ok.Text = _lprov.GetValue("app.pluginmanager.remove-wizard.button.next");
            _l_finish = _lprov.GetValue("app.pluginmanager.install-wizard.button.finish");
        }

        private void StageWorker()
        {
            switch (_stg)
            {
                case Stage.CollectingData:
                    progress.Visible = true;
                    status.Visible = true;
                    ok.Enabled = false;
                    cancel.Enabled = false;
                    tip.Text = _lprov.GetValue("app.pluginmanager.remove-wizard.tip.collecting-data");
                    status.Text = _lprov.GetValue("app.pluginmanager.remove-wizard.status.collecting-data");
                    _files.Add(Path.Combine(StaticData.PluginsDir, mainlib));
                    progress.Value = 10;
                    foreach (var lib in reflibs)
                    {
                        _files.Add(Path.Combine(StaticData.PluginsDir, lib));
                        progress.Value++;
                    }
                    _files.Add(_metafile);
                    _resDir = Path.Combine(StaticData.PluginsDir, _id + "_Res");
                    progress.Value += 15;
                    _stg = Stage.Removing;
                    StageWorker();
                    break;
                case Stage.Removing:
                    
                    foreach (var file in _files)
                    {
                        status.Text = _lprov.GetValue("app.pluginmanager.remove-wizard.status.removing-file") + " " + Path.GetFileName(file);
                        try
                        {
                            File.Delete(file);
                        }
                        catch
                        {
                            _stg = Stage.End;
                            _isSuccessful = false;
                            StageWorker();
                        }
                    }
                    status.Text = _lprov.GetValue("app.pluginmanager.remove-wizard.status.removing-res");
                    try
                    {
                        Directory.Delete(_resDir, true);
                        progress.Value += 35;
                    }
                    catch
                    {
                        _stg = Stage.End;
                        _isSuccessful = false;
                        StageWorker();
                    }
                    _stg = Stage.End;
                    StageWorker();
                    break;
                case Stage.End:
                    ok.Text = _l_finish;
                    tip.Text = _lprov.GetValue("app.pluginmanager.remove-wizard.tip.successful-completed");
                    progress.Visible = false;
                    ok.Enabled = false;
                    try
                    {
                        Directory.Delete(StaticData.InstallerDir, true);
                    }
                    catch (Exception ex)
                    {

                    }
                    progress.Value = 80;
                    progress.Visible = false;
                    if (_isSuccessful)
                        status.Text = _lprov.GetValue("app.pluginmanager.remove-wizard.status.successful-completed");
                    else status.Text = _lprov.GetValue("app.pluginmanager.remove-wizard.status.failed-remove");
                    ok.Enabled = true;
                    cancel.Visible = false;
                    _isCloseNeeded = true;
                    _stg = Stage.Close;
                    break;
                case Stage.Close:
                    _isCloseNeeded = true;
                    this.Close();
                    break;
                case Stage.Cancel:
                    try
                    {
                        Directory.Delete(StaticData.InstallerDir, true);
                    }
                    catch { }
                    this.Close();
                    break;
            }
        }

        private void Remove_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!_isCloseNeeded)
            {
                var dlg = MessageBox.Show(_lprov.GetValue("app.pluginmanager.remove-wizard.message.cancel-installation"), _lprov.GetValue("messages.titles.question"), MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                switch (dlg)
                {
                    case DialogResult.Yes:
                        try
                        {
                            Directory.Delete(StaticData.InstallerDir);
                        }
                        catch
                        { }
                        Environment.Exit(0);
                        break;
                    case DialogResult.No:
                        e.Cancel = true;
                        break;
                }
            }
            else Environment.Exit(0);
        }

        private void ok_Click(object sender, EventArgs e)
        {
            StageWorker();
        }

        private void cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
