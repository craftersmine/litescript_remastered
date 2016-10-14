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

namespace craftersmine.LiteScript.Ide.PluginManager
{
    public partial class Install : Form
    {
        public string plgid;
        public enum Stage { Extracting, LicenseAgreement, Install, End, Cancel }
        public Stage stg = Stage.Extracting;
        public string plgInstallerDir;
        public bool _isCloseNeeded = false;
        ZipFile zip;

        public Install(string plgId)
        {
            InitializeComponent();
            plgid = plgId;
            plgInstallerDir = Path.Combine(StaticData.InstallerDir, plgid);
            stg = Stage.Extracting;
            zip = new ZipFile(Path.Combine(StaticData.InstallerDir, plgid + ".lsxpkg"));
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
                    //FastZip _fz = new FastZip();
                    try
                    {
                        Directory.CreateDirectory(plgInstallerDir);
                    }
                    catch
                    {
                        MessageBox.Show("{UNABLE_EXTRACT_PLG}", "{ERROR}", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        Environment.Exit(0);
                    }
                    //_fz.ExtractZip(Path.Combine(StaticData.InstallerDir, plgid + ".lsxpkg"), StaticData.PluginsDir, null);
                    richTextBox1.LoadFile(Path.Combine(StaticData.PluginsDir, "LICENSE"), RichTextBoxStreamType.PlainText);
                    license.Visible = true;
                    stg = Stage.LicenseAgreement;

                    break;
                case Stage.LicenseAgreement:
                    break;
                case Stage.End:
                    string licensepath = Path.Combine(StaticData.PluginsDir, "LICENSE");
                    File.Move(licensepath, Path.Combine(StaticData.PluginsDir, plgid + "_LICENSE"));
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

        private void acceptAgreement_CheckedChanged(object sender, EventArgs e)
        {
            if (acceptAgreement.Checked)
            {
                ok.Enabled = false;
                cancel.Enabled = false;
                license.Visible = false;
                progress.Value = 50;
                stg = Stage.End;
                button1_Click(null, null);
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
        }
    }
}
