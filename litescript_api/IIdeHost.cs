using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace craftersmine.LiteScript.Api
{
    /// <summary>
    /// Represents IDE Form integration
    /// </summary>
    public interface IIdeHost
    {
        /// <summary>
        /// Add's new menu strip in menu bar
        /// </summary>
        /// <param name="item"><see cref="System.Windows.Forms.ToolStripMenuItem"/> for addition</param>
        void AddMenuEntry(ToolStripMenuItem item);
        /// <summary>
        /// Add's new toolbar strip in toolbar
        /// </summary>
        /// <param name="item"><see cref="System.Windows.Forms.ToolStripPanel"/> for addition</param>
        void AddToolBar(ToolStrip toolbar);

        /// <summary>
        /// Changes text in status bar
        /// </summary>
        /// <param name="status">Text of new status value</param>
        void ChangeStatus(string status);

        string GetEditorContent();
        void SetEditorContent(string content);
        void ReplaceEditorContent(string from, string to);

        void GotoLine(int line);

        Project CurrentProject { get; }
        string CurrentIdeLocale { get; }
    }
}