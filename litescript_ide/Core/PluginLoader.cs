using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using craftersmine.LiteScript.Api;
using System.IO;

namespace craftersmine.LiteScript.Ide.Core
{
    public sealed class PluginLoader
    {
        public List<IIdePlugin> Plugins = new List<IIdePlugin>();

        public void ScanPlugins(string directory)
        {
            foreach (var file in Directory.EnumerateFiles(directory, "*.dll", SearchOption.AllDirectories))
                try
                {
                    var ass = Assembly.LoadFile(file);
                    foreach (var type in ass.GetTypes())
                    {
                        var i = type.GetInterface("IIdePlugin");
                        if (i != null)
                            Plugins.Add(ass.CreateInstance(type.FullName) as IIdePlugin);
                    }
                }
                catch { DebugLogger.Write("PLGLDR\\ERROR", "Cannot load " + file + " as plugin!"); }
        }
    }
}
