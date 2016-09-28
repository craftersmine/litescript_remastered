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

namespace craftersmine.LiteScript.Ide.Forms.CreateDialogs
{
    public partial class ScriptCreateDialog : Form
    {
        public ScriptCreateDialog()
        {
            InitializeComponent();
            directoryPath.Text = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            Text = StaticData.LocaleProv.GetValue("forms.create.script.title");
            tip.Text = StaticData.LocaleProv.GetValue("forms.create.script.controls.tip");
            dirTip.Text = StaticData.LocaleProv.GetValue("forms.create.script.controls.label.directory");
            browse.Text = StaticData.LocaleProv.GetValue("forms.create.script.controls.button.browse");
            projnameTip.Text = StaticData.LocaleProv.GetValue("forms.create.script.controls.label.script-name");
            projnameBox.Text = StaticData.LocaleProv.GetValue("forms.create.script.controls.textbox.script-unnamed");
            cancel.Text = StaticData.LocaleProv.GetValue("forms.create.script.controls.button.cancel");
            ok.Text = StaticData.LocaleProv.GetValue("forms.create.script.controls.button.ok");
            ok.Image = Image.FromFile(StaticData.AppRoot + "res\\iconsets\\" + StaticData.AppSettings.IconSet + "\\ok.png");
            cancel.Image = Image.FromFile(StaticData.AppRoot + "res\\iconsets\\" + StaticData.AppSettings.IconSet + "\\cancel.png");
            browse.Image = Image.FromFile(StaticData.AppRoot + "res\\iconsets\\" + StaticData.AppSettings.IconSet + "\\browse.png");
        }

        private void ok_Click(object sender, EventArgs e)
        {
            ScriptCreationData.Directory = directoryPath.Text;
            ScriptCreationData.Name = projnameBox.Text;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void cancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
