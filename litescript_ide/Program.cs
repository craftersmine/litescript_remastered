using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using craftersmine.LiteScript.Ide.Core.Data;
using craftersmine.LocalizerLib;
using craftersmine.LiteScript.Ide.Core;

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
            DebugLogger.Write("INFO", "Setting app root...");
            StaticData.AppRoot = Application.StartupPath + "\\";
            DebugLogger.Write("INFO", "Loading settings...");
            StaticData.AppSettings = new Properties.Settings();
            try
            {
                DebugLogger.Write("INFO", "Loading localization provider...");
                StaticData.LocaleProv = new LocalizationProvider(StaticData.AppRoot + "\\Locales\\" + StaticData.AppSettings.Locale + ".lang");
                DebugLogger.Write("INFO", "Running app...");
                Application.Run(new MainForm());
            }
            catch
            {
                DebugLogger.Write("ERROR", "Localization Error! Unable find localizaton file! Application locale will setted to default and closed. Try to open an app again, if error exists - send feedback");
                MessageBox.Show("Localization Error!\r\n\r\nUnable find localizaton file! Application locale will setted to default and closed. Try to open an app again, if error exists - send feedback", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                StaticData.AppSettings.Locale = "Russian";
                StaticData.AppSettings.Save();
                Environment.Exit(0);
            }
        }
    }
}
