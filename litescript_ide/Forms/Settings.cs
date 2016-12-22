using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using craftersmine.LiteScript.Ide.Core.Data;
using System.IO;

namespace craftersmine.LiteScript.Ide.Forms
{
    public partial class Settings : Form
    {
        public Settings()
        {
            InitializeComponent();

            // === Locales ===
            Text = StaticData.LocaleProv.GetValue("forms.settings.title");
            
            downloadmore.Text = StaticData.LocaleProv.GetValue("forms.settings.controls.download-more-link");
            projectsDirtip.Text = StaticData.LocaleProv.GetValue("forms.settings.controls.tip.project-dir");
            langtip.Text = StaticData.LocaleProv.GetValue("forms.settings.controls.tip.language");
            iconsettip.Text = StaticData.LocaleProv.GetValue("forms.settings.controls.tip.iconset");
            restarttip.Text = StaticData.LocaleProv.GetValue("forms.settings.controls.tip.restart");

            ok.Text = StaticData.LocaleProv.GetValue("forms.common.button.ok");
            cancel.Text = StaticData.LocaleProv.GetValue("forms.common.button.cancel");
            browse.Text = StaticData.LocaleProv.GetValue("forms.settings.controls.browse");

            // === Iconset ===
            ok.Image = Image.FromFile(StaticData.AppRoot + "res\\iconsets\\" + StaticData.AppSettings.IconSet + "\\ok.png");
            cancel.Image = Image.FromFile(StaticData.AppRoot + "res\\iconsets\\" + StaticData.AppSettings.IconSet + "\\cancel.png");
            browse.Image = Image.FromFile(StaticData.AppRoot + "res\\iconsets\\" + StaticData.AppSettings.IconSet + "\\browse.png");

            // === Load ===
            foreach (var fl in Directory.EnumerateFiles(Path.Combine(StaticData.AppData, "Locales"), "*.lang"))
            {
                langs.Items.Add(Path.GetFileNameWithoutExtension(fl));
            }
            langs.SelectedItem = StaticData.AppSettings.Locale;
            foreach (var fl in Directory.EnumerateDirectories(Path.Combine(StaticData.AppRoot, "res\\iconsets")))
            {
                iconsets.Items.Add(Path.GetFileNameWithoutExtension(fl));
            }
            iconsets.SelectedItem = StaticData.AppSettings.IconSet;
            directory.Text = StaticData.AppSettings.ProjectsPath;
            folderBrowserDialog1.SelectedPath = StaticData.AppSettings.ProjectsPath;
        }

        private void downloadmore_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Close();
        }

        private void browse_Click(object sender, EventArgs e)
        {
            var dlg = folderBrowserDialog1.ShowDialog();
            switch (dlg)
            {
                case DialogResult.OK:
                    directory.Text = folderBrowserDialog1.SelectedPath;
                    break;
                case DialogResult.Cancel:
                    break;
            }
        }

        private void ok_Click(object sender, EventArgs e)
        {
            StaticData.AppSettings.IconSet = iconsets.SelectedItem.ToString();
            StaticData.AppSettings.Locale = langs.SelectedItem.ToString();
            StaticData.AppSettings.ProjectsPath = directory.Text;
            StaticData.AppSettings.Save();
            this.Close();
        }

        private void cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
