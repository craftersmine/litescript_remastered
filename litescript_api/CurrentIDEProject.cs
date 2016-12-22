using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace craftersmine.LiteScript.Api
{
    /// <summary>
    /// Represents a project
    /// </summary>
    public class Project
    {
        /// <summary>
        /// File contents. Like editor code
        /// </summary>
        public string FileContents { get; set; }
        /// <summary>
        /// Project root directory
        /// </summary>
        public string ProjRoot { get; set; }
        /// <summary>
        /// Project name
        /// </summary>
        public string ProjName { get; set; }
    }
}
