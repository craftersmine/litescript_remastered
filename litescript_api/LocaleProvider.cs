using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using craftersmine.LocalizerLib;

namespace craftersmine.LiteScript.Api
{
    /// <summary>
    /// Represents a logger. This class cannot be inherited
    /// </summary>
    public sealed class LocaleProvider
    {
        private Logger _localeLogger;
        /// <summary>
        /// Plugin ID
        /// </summary>
        public string PluginID { get; private set; }
        /// <summary>
        /// Locales Root
        /// </summary>
        public string LocalesRoot { get; private set; }
        /// <summary>
        /// Localization provider
        /// </summary>
        public LocalizationProvider LocalizationProvider { get; private set; }
        /// <summary>
        /// Locale name
        /// </summary>
        public string Locale { get; private set; }

        /// <summary>
        /// Constructs a new <see cref="LocaleProvider"/> object
        /// </summary>
        /// <param name="pluginId">Plugin ID</param>
        /// <param name="locale">Locale name</param>
        /// <param name="defaultLocale">Default locale name</param>
        public LocaleProvider(string pluginId, string locale, string defaultLocale)
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
                string _path = Path.Combine(LocalesRoot, defaultLocale + ".lang");
                LocalizationProvider = new LocalizationProvider(_path);
            }
        }

        /// <summary>
        /// Gets a localized string associated with specified key
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public string GetValue(string key)
        {
            return LocalizationProvider.GetValue(key);
        }
    }
}
