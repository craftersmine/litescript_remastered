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
using craftersmine.LiteScript.Ide.Forms.CreateDialogs;
using craftersmine.LiteScript.Ide.Core.Data;

namespace craftersmine.LiteScript.Ide
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            Creator.OnCreationCompletedEvent += Creator_OnCreationCompletedEvent;
            Creator.OnCreationProgressChangedEvent += Creator_OnCreationProgressChangedEvent;
        }

        private void Creator_OnCreationProgressChangedEvent(object sender, OnCreationProgressChangedEventArgs e)
        {
            progress.Value = e.Progress;
            progress.Style = e.ProgressStyle;
            status.Text = "{CREATING_PROJ}";
        }

        private void Creator_OnCreationCompletedEvent(object sender, OnCreationCompletedEventArgs e)
        {
            progress.Visible = false;
            status.Text = "{PROJ_CREATED}";
            // TODO: Realize after-creation open
        }

        private void newClicked(object sender, EventArgs e)
        {
            string name = ((ToolStripMenuItem)(sender)).Name;
            switch (name)
            {
                case "scriptNewMenu":
                    ScriptCreateDialog scd = new ScriptCreateDialog();
                    var dlg1 = scd.ShowDialog();
                    switch (dlg1)
                    {
                        case DialogResult.OK:
                            welcomePanel.Visible = false;
                            saveAsBtn.Enabled = true;
                            saveBtn.Enabled = true;
                            progress.Visible = true;
                            Creator.Create(Creator.CreationType.Script, ScriptCreationData.Directory, ScriptCreationData.Name);
                            break;
                        case DialogResult.Cancel:
                            welcomePanel.Visible = true;
                            saveAsBtn.Enabled = false;
                            saveBtn.Enabled = false;
                            break;
                    }
                    break;
                case "projNewMenu":
                    ProjectCreateDialog pcd = new ProjectCreateDialog();
                    var dlg = pcd.ShowDialog();
                    switch(dlg)
                    {
                        case DialogResult.OK:
                            welcomePanel.Visible = false;
                            saveAsBtn.Enabled = true;
                            saveBtn.Enabled = true;
                            progress.Visible = true;
                            Creator.Create(ProjectCreationData.ProjCreationType, ProjectCreationData.ProjectDir, ProjectCreationData.ProjectName);
                            break;
                        case DialogResult.Cancel:
                            welcomePanel.Visible = true;
                            saveAsBtn.Enabled = false;
                            saveBtn.Enabled = false;
                            break;
                    }
                    break;
            }
        }
    }
}
