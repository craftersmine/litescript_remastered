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
        /// <param name="toolbar"><see cref="System.Windows.Forms.ToolStripPanel"/> for addition</param>
        void AddToolBar(ToolStrip toolbar);

        /// <summary>
        /// Changes text in status bar
        /// </summary>
        /// <param name="status">Text of new status value</param>
        void ChangeStatus(string status);

        /// <summary>
        /// Gets a code from editor
        /// </summary>
        /// <returns>Code from editor in <see cref="string"/> type</returns>
        string GetEditorContent();

        /// <summary>
        /// Replaces a all code in editor! We are not recommend use this
        /// </summary>
        /// <param name="content">Code to replace</param>
        void SetEditorContent(string content);

        /// <summary>
        /// Replaces string in code like <see cref="string.Replace(string, string)"/>
        /// </summary>
        /// <param name="from">Replacing <see cref="string"/></param>
        /// <param name="to">Into <see cref="string"/></param>
        void ReplaceEditorContent(string from, string to);

        /// <summary>
        /// Goto line in Editor
        /// </summary>
        /// <param name="line">Line number</param>
        void GotoLine(int line);

        /// <summary>
        /// Current opened project. Warning! May be <code>null</code>
        /// </summary>
        Project CurrentProject { get; }

        /// <summary>
        /// Current IDE Language and locale
        /// </summary>
        string CurrentIdeLocale { get; }
    }
}