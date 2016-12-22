using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace craftersmine.LiteScript.Api
{
    /// <summary>
    /// Represents a logger. This class cannot be inherited
    /// </summary>
    public sealed class Logger
    {
        private string _loadTime;
        private string _file;

        /// <summary>
        /// Constructs a new <see cref="Logger"/> object
        /// </summary>
        /// <param name="name">Log name</param>
        public Logger(string name)
        {
            string directory = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "LiteScriptIDE", "Logs");
            if (!Directory.Exists(directory))
                Directory.CreateDirectory(directory);
            if (DateTime.Now.Hour.ToString().Length < 2)
                _loadTime = DateTime.Now.ToShortDateString() + "_0" + DateTime.Now.ToShortTimeString();
            else _loadTime = DateTime.Now.ToShortDateString() + "_" + DateTime.Now.ToShortTimeString();
            _file = Path.Combine(directory, name + "_" + _loadTime.Replace(':', '-') + ".log");
            File.WriteAllText(_file, "");
        }

        /// <summary>
        /// Adds a line in file
        /// </summary>
        /// <param name="prefix">Out prefix</param>
        /// <param name="contents">Out contents</param>
        public void Log(string prefix, string contents)
        {
            string _date;
            if (DateTime.Now.Hour.ToString().Length < 2)
                _date = DateTime.Now.ToShortDateString() + " 0" + DateTime.Now.ToShortTimeString();
            else _date = DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString();
            File.AppendAllText(_file, _date + " [" + prefix + "]" + " " + contents + "\r\n");
            Console.Write(_date + " [PLUGINOUT] [" + prefix + "]" + " " + contents + "\r\n");
        }
    }
}
