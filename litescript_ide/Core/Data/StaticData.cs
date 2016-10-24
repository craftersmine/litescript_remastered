using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using craftersmine.LocalizerLib;
using craftersmine.LiteScript.Api;
namespace craftersmine.LiteScript.Ide.Core.Data
{
    public sealed class StaticData
    {
        public static Project CurrentProject { get; set; }
        public static string AppRoot { get; set; }
        internal static Properties.Settings AppSettings { get; set; }
        public static LocalizationProvider LocaleProv { get; set; }
        public static Dictionary<bool, IIdePlugin> Plugins { get; set; }
        public static string AppData { get; set; }
        public static Logger DebugLogger { get; set; }
        public static string RunFilepath { get; set; }
    }
}
