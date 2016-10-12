using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using craftersmine.LocalizerLib;

namespace craftersmine.LiteScript.Api
{
    public sealed class LocaleProvider
    {
        private Logger _localeLogger;
        public string PluginID { get; private set; }
        public string LocalesRoot { get; private set; }
        public LocalizationProvider LocalizationProvider { get; private set; }
        public string Locale { get; private set; }

        public LocaleProvider(string pluginId, string locale)
        {
            _localeLogger = new Logger("LocaleProvLog");
            PluginID = pluginId;
            _localeLogger.Log("DEBUG", "PluginID is " + PluginID);
            Locale = locale;
            _localeLogger.Log("DEBUG", "Locale is " + Locale);
            LocalesRoot = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "LiteScriptIDE\\Plugins\\" + PluginID + "_Res\\Locales");
            _localeLogger.Log("DEBUG", "LocalesRoot is " + LocalesRoot);
            try
            {
                _localeLogger.Log("INFO", "Trying load locales...");
                string _path = Path.Combine(LocalesRoot, Locale + ".lang");
                _localeLogger.Log("DEBUG", "Path to locale file is " + _path);
                LocalizationProvider = new LocalizationProvider(_path);
                _localeLogger.Log("INFO", "Trying load locales... OK!");
            }
            catch (Exception ex)
            {
                _localeLogger.Log("SEVERE", "Unable load resources! " + ex.Message + "\r\n" + ex.StackTrace);
                throw new Exception("Unable load locales for plugin");
            }
        }

        public string GetValue(string key)
        {
            return LocalizationProvider.GetValue(key);
        }
    }
}
