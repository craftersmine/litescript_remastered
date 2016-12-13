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
using ICSharpCode.SharpZipLib.Zip;
using ICSharpCode.SharpZipLib.Core;
using Nini.Ini;
using craftersmine.LocalizerLib;

namespace craftersmine.LiteScript.Ide.PluginManager
{
    public partial class Install : Form
    {
        public string plgid;
        public string filepath;
        public enum Stage { Extracting, LicenseAgreement, LicenseAgreed, LicenseDisagreed, Install, End, Cancel, Close }
        public Stage stg = Stage.Extracting;
        public string plgInstallerDir;
        public bool _isCloseNeeded = false;
        public IniDocument _packagecontents_file;
        public bool _isValid_packageContents = true;
        public LocalizationProvider _localeprov;
        public bool _isSuccessful = true;

        private string _l_accept;
        private string _l_next;
        private string _l_finish;

        public Install(string file)
        {
            InitializeComponent();
            plugin_name.Text = "";
            _localeprov = StaticData.LocaleProv;
            _l_accept = _localeprov.GetValue("app.pluginmanager.install-wizard.button.accept");
            _l_finish = _localeprov.GetValue("app.pluginmanager.install-wizard.button.finish");
            _l_next = _localeprov.GetValue("app.pluginmanager.install-wizard.button.next");
            cancel.Text = _localeprov.GetValue("app.pluginmanager.install-wizard.button.cancel");
            tip.Text = _localeprov.GetValue("app.pluginmanager.install-wizard.tip.start");
            acceptAgreement.Text = _localeprov.GetValue("app.pluginmanager.install-wizard.accept-license-agreement-checkbox");
            ok.Text = _l_next;

            filepath = file;
            plgid = Path.GetFileNameWithoutExtension(file);
            plgInstallerDir = Path.Combine(StaticData.InstallerDir, plgid);
            stg = Stage.Extracting;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            StageWorker();
        }

        private void cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Install_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!_isCloseNeeded)
            {
                var dlg = MessageBox.Show(_localeprov.GetValue("app.pluginmanager.install-wizard.message.cancel-installation"), _localeprov.GetValue("messages.titles.question"), MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                switch (dlg)
                {
                    case DialogResult.Yes:
                        try
                        {
                            Directory.Delete(plgInstallerDir);
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

        private void acceptAgreement_CheckedChanged(object sender, EventArgs e)
        {
            if (acceptAgreement.Checked)
            {
                ok.Enabled = true;
                cancel.Enabled = true;
                progress.Value = 45;
                stg = Stage.LicenseAgreed;
            }
            else
            {
                ok.Enabled = false;
                cancel.Enabled = true;
            }
        }

        private void StageWorker()
        {
            switch (stg)
            {
                case Stage.Extracting:
                    progress.Visible = true;
                    status.Visible = true;
                    status.Text = _localeprov.GetValue("app.pluginmanager.install-wizard.status.extracting-package");
                    progress.Value = 30;
                    FastZip _fz = new FastZip();
                    try
                    {
                        Directory.CreateDirectory(plgInstallerDir);
                    }
                    catch
                    {
                        MessageBox.Show(_localeprov.GetValue("app.pluginmanager.install-wizard.message.unable-extract-pkg"), _localeprov.GetValue("messages.titles.error"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                        Environment.Exit(0);
                    }
                    string pack = Path.Combine(StaticData.InstallerDir, filepath);
                    _fz.ExtractZip(pack, plgInstallerDir, null);
                    _packagecontents_file = new IniDocument(Path.Combine(plgInstallerDir, "package-contents.pkginf"));
                    plugin_name.Text = _packagecontents_file.Sections["Package"].GetValue("plugin-name");
                    richTextBox1.LoadFile(Path.Combine(plgInstallerDir, "LICENSE"), RichTextBoxStreamType.PlainText);
                    license.Visible = true;
                    stg = Stage.LicenseAgreement;
                    StageWorker();
                    break;
                case Stage.Install:
                    tip.Text = _localeprov.GetValue("app.pluginmanager.install-wizard.tip.installation");

                    progress.Visible = true;
                    status.Visible = true;
                    ok.Enabled = false;
                    cancel.Enabled = false;
                    license.Visible = false;
                    progress.Value = 50;
                    if (_packagecontents_file.Sections["Package"].Contains("plugin-lib") && _packagecontents_file.Sections["Package"].Contains("referenced-libs") && _packagecontents_file.Sections["Package"].Contains("plugin-id"))
                        _isValid_packageContents = true;
                    else _isValid_packageContents = false;

                    if (_isValid_packageContents)
                    {
                        string plglib = _packagecontents_file.Sections["Package"].GetValue("plugin-lib");
                        string reflibs = _packagecontents_file.Sections["Package"].GetValue("referenced-libs");
                        string plgid = _packagecontents_file.Sections["Package"].GetValue("plugin-id");

                        string[] reflibsarr = null;
                        bool _isRefLibsExists = false;
                        if (reflibs != "none")
                        {
                            reflibsarr = reflibs.Split('|');
                            _isRefLibsExists = true;
                        }
                        else
                            _isRefLibsExists = false;
                        try
                        {
                            status.Text = _localeprov.GetValue("app.pluginmanager.install-wizard.status.installing-main-lib");
                            if (!File.Exists(Path.Combine(StaticData.PluginsDir, plglib)))
                                File.Move(Path.Combine(plgInstallerDir, plglib), Path.Combine(StaticData.PluginsDir, plglib));
                            else
                            {
                                File.Delete(Path.Combine(StaticData.PluginsDir, plglib));
                                File.Move(Path.Combine(plgInstallerDir, plglib), Path.Combine(StaticData.PluginsDir, plglib));
                            }
                            progress.Value = 60;
                            if (_isRefLibsExists)
                                foreach (string lib in reflibsarr)
                                {
                                    status.Text = _localeprov.GetValue("app.pluginmanager.install-wizard.status.installing-referenced-lib") + ": " + lib;
                                    if (!File.Exists(Path.Combine(StaticData.PluginsDir, lib)))
                                        File.Move(Path.Combine(plgInstallerDir, lib), Path.Combine(StaticData.PluginsDir, lib));
                                    else
                                    {
                                        File.Delete(Path.Combine(StaticData.PluginsDir, lib));
                                        File.Move(Path.Combine(plgInstallerDir, lib), Path.Combine(StaticData.PluginsDir, lib));
                                    }
                                    progress.Value++;
                                }
                            status.Text = _localeprov.GetValue("app.pluginmanager.install-wizard.status.installing-resources");
                            if (!Directory.Exists(Path.Combine(StaticData.PluginsDir, plgid + "_Res")))
                                Directory.Move(Path.Combine(plgInstallerDir, plgid + "_Res"), Path.Combine(StaticData.PluginsDir, plgid + "_Res"));
                            else
                            {
                                Directory.Delete(Path.Combine(StaticData.PluginsDir, plgid + "_Res"), true);
                                Directory.Move(Path.Combine(plgInstallerDir, plgid + "_Res"), Path.Combine(StaticData.PluginsDir, plgid + "_Res"));
                            }
                            progress.Value = 70;
                            if (!File.Exists(Path.Combine(StaticData.PluginsDir, plgid + "_pkgmeta.pkgmeta")))
                                File.Move(Path.Combine(plgInstallerDir, "package-contents.pkginf"), Path.Combine(StaticData.PluginsDir, plgid + "_pkgmeta.pkgmeta"));
                            else
                            {
                                File.Delete(Path.Combine(StaticData.PluginsDir, plgid + "_pkgmeta.pkgmeta"));
                                File.Move(Path.Combine(plgInstallerDir, "package-contents.pkginf"), Path.Combine(StaticData.PluginsDir, plgid + "_pkgmeta.pkgmeta"));
                            }
                            stg = Stage.End;
                            StageWorker();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(_localeprov.GetValue("app.pluginmanager.install-wizard.message.unable-install-plugin"), _localeprov.GetValue("messages.titles.error"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                            Console.WriteLine(ex.Message + "\r\n" + ex.StackTrace );
                            stg = Stage.End;
                            _isSuccessful = false;
                            StageWorker();
                        }
                    }
                    else
                    {
                        MessageBox.Show(_localeprov.GetValue("app.pluginmanager.install-wizard.message.invalid-package-contents-file"), _localeprov.GetValue("messages.titles.error"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                        stg = Stage.End;
                        _isSuccessful = false;
                        StageWorker();
                    }
                    break;
                case Stage.LicenseAgreement:
                    tip.Text = _localeprov.GetValue("app.pluginmanager.install-wizard.tip.license");
                    ok.Text = _l_accept;
                    license.Visible = true;
                    progress.Visible = false;
                    ok.Enabled = false;
                    break;
                case Stage.End:
                    ok.Text = _l_finish;
                    tip.Text = _localeprov.GetValue("app.pluginmanager.install-wizard.tip.installation-complete");
                    try
                    { 
                        Directory.Delete(plgInstallerDir, true);
                    }
                    catch (Exception ex)
                    {

                    }
                    progress.Value = 80;
                    progress.Visible = false;
                    if (_isSuccessful)
                        status.Text = _localeprov.GetValue("app.pluginmanager.install-wizard.status.installation-successful-completed");
                    else _localeprov.GetValue("app.pluginmanager.install-wizard.status.installation-failed");
                    ok.Enabled = true;
                    cancel.Visible = false;
                    _isCloseNeeded = true;
                    stg = Stage.Close;
                    break;
                case Stage.Close:
                    _isCloseNeeded = true;
                    this.Close();
                    break;
                case Stage.Cancel:
                    try
                    {
                        Directory.Delete(plgInstallerDir, true);
                    }
                    catch { }
                    this.Close();
                    break;
                case Stage.LicenseAgreed:
                    stg = Stage.Install;
                    ok.Text = _l_next;
                    StageWorker();
                    break;
            }
        }
    }
}
