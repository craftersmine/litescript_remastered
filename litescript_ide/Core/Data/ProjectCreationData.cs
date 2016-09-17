using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace craftersmine.LiteScript.Ide.Core.Data
{
    public sealed class ProjectCreationData
    {
        public static string ProjectName { get; set; }
        public static string ProjectDir { get; set; }
        public static Creator.CreationType ProjCreationType { get; set; }
    }
}
