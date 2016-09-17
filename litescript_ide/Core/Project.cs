using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace craftersmine.LiteScript.Ide.Core
{
    public sealed class Project
    {
        public string FileContents { get; set; }
        public string ProjRoot { get; set; }
        public string ProjName { get; set; }
    }
}
