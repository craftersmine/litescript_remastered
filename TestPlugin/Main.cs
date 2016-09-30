using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using craftersmine.LiteScript.Api;
using System.Windows.Forms;

namespace TestPlugin
{
    public class Main : IIdePlugin
    {
        public string Name { get { return "TestPlugin"; } }
        public string Id { get { return "id_testplugin"; } }
        public string Site { get { return "http://example.com"; } }
        public string Author { get { return "craftersmine"; } }
        public Version Version { get { return new Version(1, 0, 0); } }
        public string Description { get { return "Test plugin!"; } }

        private Logger _logger;
        private ToolStrip _toolbox;
        private ToolStripMenuItem _menu;
        public IIdeHost _wnd;
        public static int ln = 0;

        public void OnStart()
        {
            _logger = new Logger("plugin1");
            _logger.Log("INFO", "Plugin 1 is loading...");
            _toolbox = new ToolStrip();
            ToolStripButton _btn = new ToolStripButton("button1");
            _btn.Click += Main_Click;
            _toolbox.Items.Add(_btn);
            _menu = new ToolStripMenuItem();
            _menu.Text = "plugin1menu";
            ToolStripMenuItem _1item = new ToolStripMenuItem("1");
            _1item.Click += _1item_Click;
            _menu.DropDownItems.Add(_1item);
            _menu.DropDownItems.Add("2");
        }

        private void _1item_Click(object sender, EventArgs e)
        {
            _wnd.ChangeStatus("Current project is " + _wnd.CurrentProject.ProjName);
        }

        private void Main_Click(object sender, EventArgs e)
        {
            var dlg = new Form1().ShowDialog();
            switch(dlg)
            {
                case DialogResult.OK:
                    _wnd.GotoLine(ln);
                    _wnd.ChangeStatus("Line changed!");
                    break;
            }
        }

        public void OnRunning(IIdeHost appWindow)
        {
            _logger.Log("INFO", "Plugin 1 loaded!");
            _wnd = appWindow;
            _wnd.AddMenuEntry(_menu);
            _wnd.AddToolBar(_toolbox);
            _wnd.ChangeStatus("Plugin 1 loaded!");
        }

        public void OnStop()
        {
            _logger.Log("INFO", "Plugin 1 unloading...");
        }
    }
}
