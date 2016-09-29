using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace craftersmine.LiteScript.Ide.Forms
{
    public partial class About : Form
    {
        public About()
        {
            InitializeComponent();
            button1.Text = Core.Data.StaticData.LocaleProv.GetValue("forms.common.button.ok");
            button2.Text = Core.Data.StaticData.LocaleProv.GetValue("forms.common.button.checkupdates");
            button2.Image = Image.FromFile(Core.Data.StaticData.AppRoot + "res\\iconsets\\" + Core.Data.StaticData.AppSettings.IconSet + "\\checkupdates.png");
            button1.Image = Image.FromFile(Core.Data.StaticData.AppRoot + "res\\iconsets\\" + Core.Data.StaticData.AppSettings.IconSet + "\\ok.png");
            Text = Core.Data.StaticData.LocaleProv.GetValue("forms.about.title");
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
