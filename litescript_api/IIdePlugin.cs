using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace craftersmine.LiteScript.Api
{
    /// <summary>
    /// Represents an main plug-in objects
    /// </summary>
    public interface IIdePlugin
    {
        /// <summary>
        /// User-friendly name of plug-in
        /// </summary>
        string Name { get; }

        /// <summary>
        /// Plug-in id
        /// </summary>
        string Id { get; }

        /// <summary>
        /// Developer web site
        /// </summary>
        string Site { get; }

        /// <summary>
        /// Developer name, nickname, etc
        /// </summary>
        string Author { get; }

        /// <summary>
        /// Current plug-in version
        /// </summary>
        Version Version { get; }

        /// <summary>
        /// Description of plugin
        /// </summary>
        string Description { get; }

        /// <summary>
        /// Calls at IDE start. Can used for load settings, initialize objects, etc
        /// </summary>
        void OnStart();

        /// <summary>
        /// Calls at IDE is currently started. Can used for show objects to user
        /// </summary>
        /// <param name="appWindow">Main form interface</param>
        void OnRunning(IIdeHost appWindow);

        /// <summary>
        /// Calls at IDE is stopping and exiting. Can used for settings save, etc
        /// </summary>
        void OnStop();
    }
}
