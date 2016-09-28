using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace craftersmine.LiteScript.Ide.Core
{
    public sealed class DebugLogger
    {
        public static void Write(string prefix, string contents)
        {
            Console.WriteLine(DateTime.Now + " [" + prefix + "] " + contents);
        }
    }
}
