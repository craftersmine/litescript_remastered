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
    public partial class PluginManager : Form
    {
        public Api.IIdePlugin _selectedPlg;
        public PluginManager()
        {
            InitializeComponent();

            tip.Text = StaticData.LocaleProv.GetValue("forms.pluginmanager.controls.tip");
            nametip.Text = StaticData.LocaleProv.GetValue("forms.pluginmanager.controls.name");
            versiontip.Text = StaticData.LocaleProv.GetValue("forms.pluginmanager.controls.version");
            authortip.Text = StaticData.LocaleProv.GetValue("forms.pluginmanager.controls.author");
            desctip.Text = StaticData.LocaleProv.GetValue("forms.pluginmanager.controls.description");
            sitetip.Text = StaticData.LocaleProv.GetValue("forms.pluginmanager.controls.site");

            list.Columns[1].Text = StaticData.LocaleProv.GetValue("forms.pluginmanager.controls.name");
            list.Columns[2].Text = StaticData.LocaleProv.GetValue("forms.pluginmanager.controls.version");

            Text = StaticData.LocaleProv.GetValue("forms.pluginmanager.title");

            deleteplg.Text = StaticData.LocaleProv.GetValue("forms.pluginmanager.controls.button.delete");
            checkupdates.Text = StaticData.LocaleProv.GetValue("forms.common.button.checkupdates");
            selplgtip.Text = StaticData.LocaleProv.GetValue("forms.pluginmanager.controls.select-plugin-tip");

            checkupdates.Image = Image.FromFile(Core.Data.StaticData.AppRoot + "res\\iconsets\\" + Core.Data.StaticData.AppSettings.IconSet + "\\checkupdates.png");
            deleteplg.Image = Image.FromFile(Core.Data.StaticData.AppRoot + "res\\iconsets\\" + Core.Data.StaticData.AppSettings.IconSet + "\\delete.png");

            Cursor = Cursors.WaitCursor;
            foreach (var plg in StaticData.Plugins)
            {
                int img = 0;
                if (plg.Key)
                    img = 1;
                list.Items.Add(new ListViewItem(new string[] { null, plg.Value.Name, plg.Value.Version.ToString() }, img));
            }
            Cursor = Cursors.Default;

            
        }

        private void siteval_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string link = siteval.Text;
            System.Diagnostics.Process.Start(link);
        }

        private void list_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            try
            {
                string plgname = list.SelectedItems[0].SubItems[1].Text;
                foreach (var item in StaticData.Plugins)
                {
                    _selectedPlg = item.Value;
                    if (_selectedPlg.Name == plgname)
                    {
                        nameval.Text = _selectedPlg.Name;
                        authorval.Text = _selectedPlg.Author;
                        siteval.Text = _selectedPlg.Site;
                        versionval.Text = _selectedPlg.Version.ToString();
                        descval.Text = _selectedPlg.Description;
                        panel1.Visible = true;
                    }
                }
            }
            catch
            {

            }
        }

        private void deleteplg_Click(object sender, EventArgs e)
        {
            try
            {
                string filepath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "LiteScriptIDE\\Plugins", _selectedPlg.Id + ".dll");
                File.Delete(filepath);
                list.Items.Remove(new ListViewItem(new string[] { null, _selectedPlg.Name, _selectedPlg.Version.ToString() }));
            }
            catch
            {
                
            }
        }
    }
}
