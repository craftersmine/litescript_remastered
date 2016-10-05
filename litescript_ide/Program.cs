using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using craftersmine.LiteScript.Ide.Core.Data;
using craftersmine.LocalizerLib;
using craftersmine.LiteScript.Ide.Core;
using System.IO;

namespace craftersmine.LiteScript.Ide
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            try
            {
                DebugLogger.Write("INFO", "Setting app root...");
                StaticData.AppRoot = Application.StartupPath + "\\";
                DebugLogger.Write("INFO", "Loading settings...");
                StaticData.AppSettings = new Properties.Settings();
                DebugLogger.Write("INFO", "Setting app-data...");
                StaticData.AppData = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "LiteScriptIDE");
                if (StaticData.AppSettings.ProjectsPath == string.Empty)
                {
                    StaticData.AppSettings.ProjectsPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                    StaticData.AppSettings.Save();
                }
                if (!Directory.Exists(StaticData.AppData))
                {
                    Directory.CreateDirectory(Path.Combine(StaticData.AppData, "Logs"));
                    Directory.CreateDirectory(Path.Combine(StaticData.AppData, "Plugins"));
                    Directory.CreateDirectory(Path.Combine(StaticData.AppData, "Plugins\\Installer"));
                }
                DebugLogger.Write("INFO", "Loading localization provider...");
                StaticData.LocaleProv = new LocalizationProvider(StaticData.AppRoot + "\\Locales\\" + StaticData.AppSettings.Locale + ".lang");
                DebugLogger.Write("INFO", "Running app...");
                Application.Run(new MainForm());
            }
            catch (Exception ex)
            {
                string[] texts = { "God, I feel bad", "Who is crashed me?", "Oh.. Great, I lose all your work", "Ok, I crashed! You will not mind if I'm going to fold all the settings?", "Do not worry, here's cookies" };
                DebugLogger.Write("ERROR", "A Fatal Error has occured! Application was crashed and reset all settings to Default, we are dont know why that happened, but we can send log from your Desktop at support@litescript.hol.es");
                MessageBox.Show("A Fatal Error has occured!\r\n\r\nApplication was crashed and reset all settings to Default, we are dont know why that happened, but you can send log from your Desktop at support@litescript.hol.es", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                int rnd = new Random().Next(texts.Length);
                string log = string.Format("========= LiteScript IDE Crashlog =========\r\n\r\n{4}\r\n\r\nMessage: {0}\r\nInner Exception: {1}\r\nSource module: {2}\r\n\r\nStack Trace:\r\n{3}\r\n\r\nPlease send this log at support@litescript.hol.es. This will solve the problem faster!", ex.Message, ex.InnerException, ex.Source, ex.StackTrace, texts[rnd]);
                string logPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory), "litescript-crashlog-" + DateTime.Now.ToString().Replace(':', '-').Replace(' ', '_') + ".log");
                File.WriteAllText(logPath, log);
                StaticData.AppSettings.Locale = "Russian";
                StaticData.AppSettings.IconSet = "Default";
                StaticData.AppSettings.ProjectsPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                StaticData.AppSettings.Save();
                Environment.Exit(0);
            }
        }
    }
}
