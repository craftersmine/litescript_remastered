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
        }

        private void ok_Click(object sender, EventArgs e)
        {
            ScriptCreationData.Directory = directoryPath.Text;
            ScriptCreationData.Name = projnameBox.Text;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
