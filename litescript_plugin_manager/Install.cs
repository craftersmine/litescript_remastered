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

namespace craftersmine.LiteScript.Ide.PluginManager
{
    public partial class Install : Form
    {
        public string plgid;
        public enum Stage { Extracting, LicenseAgreement, Install, Cancel }
        public Stage stg = Stage.Extracting;
        public string plgInstallerDir;
        public bool _isCloseNeeded = false;

        public Install(string plgId)
        {
            InitializeComponent();
            plgid = plgId;
            plgInstallerDir = Path.Combine(StaticData.InstallerDir, plgid);
            stg = Stage.Extracting;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            switch(stg)
            {
                case Stage.Extracting:
                    progress.Visible = true;
                    status.Visible = true;
                    status.Text = "{EXTRACTING_PLG_PKG}";
                    progress.Value = 25;
                    FastZip _fz = new FastZip();
                    try
                    {
                        Directory.CreateDirectory(plgInstallerDir);
                    }
                    catch
                    {
                        MessageBox.Show("{UNABLE_EXTRACT_PLG}", "{ERROR}", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        Environment.Exit(0);
                    }
                    _fz.ExtractZip(Path.Combine(StaticData.InstallerDir, plgid + ".lsxpkg"), plgInstallerDir, null);
                    richTextBox1.LoadFile(Path.Combine(plgInstallerDir, "LICENSE"), RichTextBoxStreamType.PlainText);
                    ok.Enabled = true;
                    license.Visible = true;
                    break;
                case Stage.LicenseAgreement:
                    if (acceptAgreement.Checked)
                    {
                        ok.Enabled = false;
                        cancel.Enabled = false;
                        license.Visible = false;
                        progress.Value = 50;
                        stg = Stage.Install;
                    }
                    else
                    {
                        ok.Enabled = false;
                        cancel.Enabled = true;
                        license.Visible = false;
                        progress.Visible = false;
                        status.Text = "{LICENSE_DISAGREED}";
                        stg = Stage.Cancel;
                    }
                    break;
                case Stage.Install:
                    try
                    {
                        File.Move(Path.Combine(plgInstallerDir, plgid + ".dll"), Path.Combine(StaticData.PluginsDir, plgid + ".dll"));
                        progress.Value = 75;
                        progress.Visible = false;
                        status.Text = "{PLUGIN_INSTALLED_SUCCESSFUL}";
                    }
                    catch
                    {
                        progress.Value = 75;
                        progress.Visible = false;
                        status.Text = "{ERROR_WHILE_PLUGIN_INSTALL}";
                    }
                    break;
            }
        }

        private void cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Install_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!_isCloseNeeded)
            {
                var dlg = MessageBox.Show("{CANCEL_PLUGIN_INSTALLATION}", "{INFO}", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
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
    }
}
