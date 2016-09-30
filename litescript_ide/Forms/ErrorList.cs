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

namespace craftersmine.LiteScript.Ide.Forms
{
    public partial class ErrorList : Form
    {
        public ErrorList(List<string> errors)
        {
            InitializeComponent();
            foreach (var err in errors)
            {
                // d:\TestProjects\ProjSaveTest\build\ProjSaveTest.cs(10,17): warning CS0219: Переменной "_var" присвоено значение, но оно ни разу не использовалось
                string[] ln_splt = err.Split(':');
                string[] err_id = ln_splt[2].Split(' ');
                string desc = ln_splt[3].Substring(1);
                const int errIcnId = 0;
                const int warnIcnId = 1;
                int id = 0;
                if (err_id[2].Contains("error"))
                    id = errIcnId;
                else if (err_id[2].Contains("warning"))
                    id = warnIcnId;
                listView1.Items.Add(new ListViewItem(new string[] { "", err_id[2], desc }, id));
            }
            tip.Text = StaticData.LocaleProv.GetValue("forms.errorlist.controls.tip");
            listView1.Columns[1].Text = StaticData.LocaleProv.GetValue("forms.errorlist.controls.list.id");
            listView1.Columns[2].Text = StaticData.LocaleProv.GetValue("forms.errorlist.controls.list.description");
            Text = StaticData.LocaleProv.GetValue("forms.errorlist.title");
            ok.Text = StaticData.LocaleProv.GetValue("forms.common.button.ok");
        }

        private void ok_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
