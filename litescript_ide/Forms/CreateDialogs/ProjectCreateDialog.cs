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
            // LOCALE: Realize locale load for ProjectCreateDialog
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
