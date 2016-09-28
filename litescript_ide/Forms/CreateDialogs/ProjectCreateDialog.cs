using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using craftersmine.LiteScript.Ide.Core;
using craftersmine.LiteScript.Ide.Core.Data;

namespace craftersmine.LiteScript.Ide.Forms.CreateDialogs
{
    public partial class ProjectCreateDialog : Form
    {
        public ProjectCreateDialog()
        {
            InitializeComponent();
            directoryPath.Text = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            Text = StaticData.LocaleProv.GetValue("forms.create.project.title");
            tip.Text = StaticData.LocaleProv.GetValue("forms.create.project.controls.tip");
            dirTip.Text = StaticData.LocaleProv.GetValue("forms.create.project.controls.label.directory");
            browse.Text = StaticData.LocaleProv.GetValue("forms.create.project.controls.button.browse");
            projnameTip.Text = StaticData.LocaleProv.GetValue("forms.create.project.controls.label.project-name");
            projnameBox.Text = StaticData.LocaleProv.GetValue("forms.create.project.controls.textbox.project-unnamed");
            cancel.Text = StaticData.LocaleProv.GetValue("forms.create.project.controls.button.cancel");
            ok.Text = StaticData.LocaleProv.GetValue("forms.create.project.controls.button.ok");
            ok.Image = Image.FromFile(StaticData.AppRoot + "res\\iconsets\\" + StaticData.AppSettings.IconSet + "\\ok.png");
            cancel.Image = Image.FromFile(StaticData.AppRoot + "res\\iconsets\\" + StaticData.AppSettings.IconSet + "\\cancel.png");
            browse.Image = Image.FromFile(StaticData.AppRoot + "res\\iconsets\\" + StaticData.AppSettings.IconSet + "\\browse.png");
        }

        private void ok_Click(object sender, EventArgs e)
        {
            ProjectCreationData.ProjCreationType = Creator.CreationType.Project;
            ProjectCreationData.ProjectDir = directoryPath.Text;
            ProjectCreationData.ProjectName = projnameBox.Text;
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
