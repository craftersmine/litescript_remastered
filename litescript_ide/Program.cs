﻿using System;
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
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            try
            {
                StaticData.AppData = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "LiteScriptIDE");
                StaticData.RunFilepath = "";
                foreach (var arg in args)
                {
                    string[] arg_splt = arg.Split('=');
                    if (arg_splt[0] == "-file")
                        StaticData.RunFilepath = arg_splt[1];
                    else StaticData.RunFilepath = "";
                }
                if(Directory.Exists(Path.Combine(StaticData.AppData, "Logs")))
                    Directory.Delete(Path.Combine(StaticData.AppData, "Logs"), true);
                Directory.CreateDirectory(Path.Combine(StaticData.AppData, "Logs"));
                StaticData.DebugLogger = new Logger("IDE");
                StaticData.DebugLogger.Log("INFO", "Setting app root...");
                StaticData.AppRoot = Application.StartupPath + "\\";
                StaticData.DebugLogger.Log("INFO", "Loading settings...");
                StaticData.AppSettings = new Properties.Settings();
                if (StaticData.AppSettings.ProjectsPath == string.Empty)
                {
                    StaticData.AppSettings.ProjectsPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                    StaticData.AppSettings.Save();
                }
                if (!Directory.Exists(StaticData.AppData))
                {
                    Directory.CreateDirectory(Path.Combine(StaticData.AppData, "Logs"));
                    Directory.CreateDirectory(Path.Combine(StaticData.AppData, "Plugins"));
                    Directory.CreateDirectory(Path.Combine(StaticData.AppData, "Locales"));
                    Directory.CreateDirectory(Path.Combine(StaticData.AppData, "Plugins\\Installer"));
                }
                StaticData.DebugLogger.Log("INFO", "Loading localization provider...");
                StaticData.LocaleProv = new LocalizationProvider(StaticData.AppData + "\\Locales\\" + StaticData.AppSettings.Locale + ".lang");
                File.WriteAllText(Path.Combine(StaticData.AppData, "Locales\\currentlocale.setting"), StaticData.AppSettings.Locale);
                StaticData.DebugLogger.Log("INFO", "Running app...");
                Application.Run(new MainForm());
            }
            catch (Exception ex)
            {
                string[] texts = { "God, I feel bad", "Who is crashed me?", "Oh.. Great, I lose all your work", "Ok, I crashed! You will not mind if I'm going to fold all the settings?", "Do not worry, here's cookies" };
                int rnd = new Random().Next(texts.Length);
                string log = string.Format("========= LiteScript IDE Crashlog =========\r\n\r\n{4}\r\n\r\nMessage: {0}\r\nInner Exception: {1}\r\nSource module: {2}\r\n\r\nStack Trace:\r\n{3}\r\n\r\nPlease send this log at support@litescript.hol.es. This will solve the problem faster!", ex.Message, ex.InnerException, ex.Source, ex.StackTrace, texts[rnd]);

                StaticData.DebugLogger.Log("ERROR", log);
                MessageBox.Show("A Fatal Error has occured!\r\n\r\nApplication was crashed and reset all settings to Default, we are dont know why that happened, but you can send log from your Desktop at support@litescript.hol.es", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                
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
