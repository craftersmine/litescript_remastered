using craftersmine.LocalizerLib;
using System;
using System.Collections.Generic;
using System.IO;
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
            StaticData.AppData = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "LiteScriptIDE");
            StaticData.InstallerDir = Path.Combine(StaticData.AppData, "Plugins\\Installer");
            StaticData.PluginsDir = Path.Combine(StaticData.AppData, "Plugins");

            string _currlocale = File.ReadAllText(Path.Combine(StaticData.AppData, "Locales\\currentlocale.setting"));
            string _path = Path.Combine(StaticData.AppData, "Locales\\" + _currlocale + ".lang");
            StaticData.LocaleProv = new LocalizationProvider(_path);
            Dictionary<string, string> _args = new Dictionary<string, string>();
            try
            {
                if (Directory.Exists(StaticData.InstallerDir))
                    Directory.Delete(StaticData.InstallerDir, true);
                Directory.CreateDirectory(StaticData.InstallerDir);
            }
            catch
            {
                MessageBox.Show(StaticData.LocaleProv.GetValue("app.pluginmanager.install-wizard.status.failed-clean-temp-dir"), StaticData.LocaleProv.GetValue("messages.titles.error"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                Environment.Exit(0);
            }
            foreach(var arg in args)
            {
                string[] _arg = arg.Split('=');
                if (_arg[0] == "-do")
                    _args.Add("do", _arg[1]);
                if (_arg[0] == "-file")
                    _args.Add("file", _arg[1]);
                if (_arg[0] == "-id")
                    _args.Add("id", _arg[1]);
            }
            try
            {
                if (_args["do"] != string.Empty || _args["id"] != string.Empty)
                {
                    if (_args["do"].ToLower() == "install")
                        Application.Run(new Install(_args["file"]));
                    if (_args["do"].ToLower() == "remove")
                        Application.Run(new Remove(_args["id"]));
                }
                else { MessageBox.Show(StaticData.LocaleProv.GetValue("app.pluginmanager.install-wizard.status.no-correct-set-arguments"), StaticData.LocaleProv.GetValue("messages.titles.error"), MessageBoxButtons.OK, MessageBoxIcon.Error); Environment.Exit(0); }
            }
            catch (Exception ex)
            { //MessageBox.Show("{YOU_NOT_SET_ARGS}", "{ERROR}", MessageBoxButtons.OK, MessageBoxIcon.Error); Environment.Exit(0);
                throw ex;
            }
        }
    }
}
