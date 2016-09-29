using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace craftersmine.LiteScript.Api
{
    public sealed class Logger
    {
        private string _loadTime;
        private string _file;

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
