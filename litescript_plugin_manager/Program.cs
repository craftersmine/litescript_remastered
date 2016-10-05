using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace craftersmine.LiteScript.Ide.PluginManager
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Dictionary<string, string> _args = new Dictionary<string, string>();
            foreach(var arg in args)
            {
                string[] _arg = arg.Split('=');
                if (_arg[0] == "-do")
                    _args.Add("do", _arg[1]);
                if (_arg[0] == "-id")
                    _args.Add("id", _arg[1]);
            }
            if (_args["do"] != string.Empty && _args["id"] != string.Empty)
            {
                if (_args["do"].ToLower() == "install")
                    Application.Run(new Install(_args["id"]));
                if (_args["do"].ToLower() == "remove")
                    Application.Run(new Remove(_args["id"]));
            }
        }
    }
}
