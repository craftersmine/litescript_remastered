using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
using craftersmine.LiteScript.Ide.Core;
using craftersmine.LiteScript.Ide.Forms.CreateDialogs;
using craftersmine.LiteScript.Ide.Core.Data;
using craftersmine.LiteScript.Ide.Forms;
using craftersmine.LiteScript.Api;

namespace craftersmine.LiteScript.Ide
{
    public partial class MainForm : Form, IIdeHost
    {
        public Project _currProj = null;
        public bool _isProject = false;
        public bool _isNeededClosed = false;
        public bool _isProjectOrScriptLoaded = false;
        public Project _projToSave = null;
        public string _scriptPath = "";
        public List<string> _latestErrs = new List<string>();
        public PluginLoader _pl;

        public MainForm()
        {
            InitializeComponent();
            LoadPlugins();
            Creator.OnCreationCompletedEvent += Creator_OnCreationCompletedEvent;
            Creator.OnCreationProgressChangedEvent += Creator_OnCreationProgressChangedEvent;
            Opener.OnOpeningFileEvent += Opener_OnOpeningFileEvent;
            Opener.OnOpenedFileEvent += Opener_OnOpenedFileEvent;
            Saver.OnSavedFileEvent += Saver_OnSavedFileEvent;
            Saver.OnSavingFileEvent += Saver_OnSavingFileEvent;
            Builder.OnBuildCompletedEvent += Builder_OnBuildCompletedEvent;
            Builder.OnBuildRunningEvent += Builder_OnBuildRunningEvent;
            LoadSyntaxHl();
            // LOCALE: Realize locale load for MainForm
            LoadLocales();
            RunPlugins();
        }

        private void Builder_OnBuildRunningEvent(object sender, OnBuildRunningEventArgs e)
        {
            progress.Value = e.Progress;
            progress.Style = e.ProgressStyle;
            statusbar.Text = StaticData.LocaleProv.GetValue("forms.main.status.building-project");
        }

        private void Builder_OnBuildCompletedEvent(object sender, OnBuildCompletedEventArgs e)
        {
            switch (e.Result)
            {
                case Builder.BuildResult.Error:
                    statusbar.Text = StaticData.LocaleProv.GetValue("forms.main.status.build-failed");
                    ErrorList el = new ErrorList(e.ErrorAndWarningList);
                    _latestErrs = e.ErrorAndWarningList;
                    el.ShowDialog();
                    break;
                case Builder.BuildResult.Success:
                    statusbar.Text = StaticData.LocaleProv.GetValue("forms.main.status.build-success");
                    break;
            }
        }

        private void Opener_OnOpenedFileEvent(object sender, OnOpenedFileEventArgs e)
        {
            switch (e.Result)
            {
                case Opener.OpenResult.Success:
                    _currProj = e.ProjectFile;
                    progress.Visible = false;
                    statusbar.Text = StaticData.LocaleProv.GetValue("forms.main.status.opened-project");
                    _isProjectOrScriptLoaded = true;
                    string _fl = _currProj.FileContents;
                    Text += " - " + _currProj.ProjName;
                    editorBox.Text = _fl;
                    _projToSave = _currProj;
                    break;
                case Opener.OpenResult.Error:
                    LockAll();
                    break;
            }
        }

        private void Saver_OnSavingFileEvent(object sender, OnSavingFileEventArgs e)
        {
            progress.Value = e.Progress;
            progress.Style = e.ProgressStyle;
            statusbar.Text = StaticData.LocaleProv.GetValue("forms.main.status.saving-project");
        }

        private void Saver_OnSavedFileEvent(object sender, OnSavedFileEventArgs e)
        {
            switch (e.Result)
            {
                case Saver.SaveResult.Success:
                    progress.Visible = false;
                    statusbar.Text = StaticData.LocaleProv.GetValue("forms.main.status.saved-project");
                    break;
                case Saver.SaveResult.Error:
                    progress.Visible = false;
                    statusbar.Text = StaticData.LocaleProv.GetValue("forms.main.status.save-project-error");
                    break;
            }
        }

        private void Opener_OnOpeningFileEvent(object sender, OnOpeningFileEventArgs e)
        {
            progress.Value = e.Progress;
            progress.Style = e.ProgressStyle;
            statusbar.Text = StaticData.LocaleProv.GetValue("forms.main.status.opening-project");
        }

        private void Creator_OnCreationProgressChangedEvent(object sender, OnCreationProgressChangedEventArgs e)
        {
            progress.Value = e.Progress;
            progress.Style = e.ProgressStyle;
            statusbar.Text = StaticData.LocaleProv.GetValue("forms.main.status.creating-project");
        }

        private void Creator_OnCreationCompletedEvent(object sender, OnCreationCompletedEventArgs e)
        {
            switch (e.Result)
            {
                case Creator.CreationResult.Success:
                    statusbar.Text = StaticData.LocaleProv.GetValue("forms.main.status.created-project");
                    if (_isProject)
                    {
                        string _filenameCtor = ProjectCreationData.ProjectName + ".lsproj";
                        string _projFldrCtor = Path.Combine(ProjectCreationData.ProjectDir, ProjectCreationData.ProjectName);
                        string _projFCtor = Path.Combine(_projFldrCtor, _filenameCtor);
                        Opener.OpenProject(_projFCtor);
                    }
                    else
                    {
                        string _filenameCtor = ScriptCreationData.Name + ".litescript";
                        string _projFCtor = Path.Combine(ScriptCreationData.Directory, _filenameCtor);
                        editorBox.Text = Opener.OpenScript(_projFCtor);
                    }
                    break;
                case Creator.CreationResult.Error:
                    LockAll();
                    break;
            }
        }

        private void newClicked(object sender, EventArgs e)
        {
            string name = ((ToolStripMenuItem)(sender)).Name;
            switch (name)
            {
                case "scriptNewMenu":
                    ScriptCreateDialog scd = new ScriptCreateDialog();
                    var dlg1 = scd.ShowDialog();
                    switch (dlg1)
                    {
                        case DialogResult.OK:
                            welcomePanel.Visible = false;
                            editorPanel.Visible = true;
                            saveBtn.Enabled = true;
                            progress.Visible = true;
                            Creator.Create(Creator.CreationType.Script, ScriptCreationData.Directory, ScriptCreationData.Name);
                            break;
                        case DialogResult.Cancel:
                            welcomePanel.Visible = true;
                            editorPanel.Visible = false;
                            saveBtn.Enabled = false;
                            break;
                    }
                    break;
                case "projNewMenu":
                    ProjectCreateDialog pcd = new ProjectCreateDialog();
                    var dlg = pcd.ShowDialog();
                    switch(dlg)
                    {
                        case DialogResult.OK:
                            welcomePanel.Visible = false;
                            editorPanel.Visible = true;
                            UnlockAll();
                            progress.Visible = true;
                            _isProject = true;
                            Creator.Create(ProjectCreationData.ProjCreationType, ProjectCreationData.ProjectDir, ProjectCreationData.ProjectName);
                            break;
                        case DialogResult.Cancel:
                            break;
                    }
                    break;
            }
        }

        private void newLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ProjectCreateDialog pcd1 = new ProjectCreateDialog();
            var dlg2 = pcd1.ShowDialog();
            switch (dlg2)
            {
                case DialogResult.OK:
                    welcomePanel.Visible = false;
                    editorPanel.Visible = true;
                    UnlockAll();
                    progress.Visible = true;
                    _isProject = true;
                    Creator.Create(ProjectCreationData.ProjCreationType, ProjectCreationData.ProjectDir, ProjectCreationData.ProjectName);
                    
                    break;
                case DialogResult.Cancel:
                    break;
            }
        }

        private void openClicked(object sender, EventArgs e)
        {
            if (_isProjectOrScriptLoaded)
            {
                var dlg = MessageBox.Show("{SAVE_BEFORE_QUIT}", "{INFO}", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information);
                switch (dlg)
                {
                    case DialogResult.Yes:
                        //LockAll();
                        _projToSave = _currProj;
                        if (_currProj == null)
                            Saver.SaveScript(_scriptPath, editorBox.Text);
                        else if ((_currProj != null) && (_projToSave != null) && (_scriptPath == ""))
                        {
                            _projToSave.FileContents = editorBox.Text;
                            Saver.SaveProject(_projToSave);
                        }
                        var dlg1 = openDialog.ShowDialog(this);
                        switch (dlg1)
                        {
                            case DialogResult.OK:
                                if (openDialog.FileName.EndsWith("lsproj"))
                                {
                                    _isProject = true;
                                    Opener.OpenProject(openDialog.FileName);
                                    StaticData.CurrentProject = _currProj;
                                    editorBox.Text = _currProj.FileContents;
                                    welcomePanel.Visible = false;
                                    editorPanel.Visible = true;
                                    UnlockAll();
                                }
                                else if (openDialog.FileName.EndsWith("litescript"))
                                {
                                    _isProject = false;
                                    _scriptPath = openDialog.FileName;
                                    editorBox.Text = Opener.OpenScript(openDialog.FileName);
                                    welcomePanel.Visible = false;
                                    editorPanel.Visible = true;
                                    UnlockAll();
                                }
                                break;
                            case DialogResult.Cancel:
                                break;
                        }
                        break;
                    case DialogResult.No:
                        //LockAll();
                        var dlg2 = openDialog.ShowDialog(this);
                        switch (dlg2)
                        {
                            case DialogResult.OK:
                                if (openDialog.FileName.EndsWith("lsproj"))
                                {
                                    _isProject = true;
                                    Opener.OpenProject(openDialog.FileName);
                                    StaticData.CurrentProject = _currProj;
                                    editorBox.Text = _currProj.FileContents;
                                    welcomePanel.Visible = false;
                                    editorPanel.Visible = true;
                                    UnlockAll();
                                }
                                else if (openDialog.FileName.EndsWith("litescript"))
                                {
                                    _isProject = false;
                                    _scriptPath = openDialog.FileName;
                                    editorBox.Text = Opener.OpenScript(openDialog.FileName);
                                    welcomePanel.Visible = false;
                                    editorPanel.Visible = true;
                                    UnlockAll();
                                }
                                break;
                            case DialogResult.Cancel:
                                break;
                        }
                        break;
                    case DialogResult.Cancel:
                        return;
                }
            }
            else
            {
                var dlg = openDialog.ShowDialog(this);
                switch (dlg)
                {
                    case DialogResult.OK:
                        if (openDialog.FileName.EndsWith("lsproj"))
                        {
                            _isProject = true;
                            Opener.OpenProject(openDialog.FileName);
                            StaticData.CurrentProject = _currProj;
                            editorBox.Text = _currProj.FileContents;
                            welcomePanel.Visible = false;
                            editorPanel.Visible = true;
                            UnlockAll();
                        }
                        else if (openDialog.FileName.EndsWith("litescript"))
                        {
                            _isProject = false;
                            _scriptPath = openDialog.FileName;
                            editorBox.Text = Opener.OpenScript(openDialog.FileName);
                            StaticData.CurrentProject = _currProj;
                            welcomePanel.Visible = false;
                            editorPanel.Visible = true;
                            UnlockAll();
                        }
                        break;
                    case DialogResult.Cancel:
                        break;
                }
            }
        }

        private void UnlockAll()
        {
            editmenu.Enabled = true;
            scriptmenu.Enabled = true;
            saveMenu.Enabled = true;
            saveBtn.Enabled = true;
            undoBtn.Enabled = true;
            redoBtn.Enabled = true;
            copyBtn.Enabled = true;
            cutBtn.Enabled = true;
            pasteBtn.Enabled = true;
            runBtn.Enabled = true;
            buildBtn.Enabled = true;
        }

        private void LockAll()
        {
            editmenu.Enabled = false;
            scriptmenu.Enabled = false;
            saveMenu.Enabled = false;
            saveBtn.Enabled = false;
            undoBtn.Enabled = false;
            redoBtn.Enabled = false;
            copyBtn.Enabled = false;
            cutBtn.Enabled = false;
            pasteBtn.Enabled = false;
            runBtn.Enabled = false;
            buildBtn.Enabled = false;
        }

        private void closeMenu_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_isNeededClosed || !_isProjectOrScriptLoaded)
            {
                #region =========== API INTEGRATION ============
                StopPlugins();
                #endregion
                Environment.Exit(0);
            }
            else
            {
                var dlg = MessageBox.Show(StaticData.LocaleProv.GetValue("message.save-before-quit"), StaticData.LocaleProv.GetValue("message.save-before-quit.title"), MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information);
                switch (dlg)
                {
                    case DialogResult.Yes:
                        //LockAll();
                        _projToSave = _currProj;
                        if (_currProj == null)
                            Saver.SaveScript(_scriptPath, editorBox.Text);
                        else if ((_currProj != null) && (_projToSave != null) && (_scriptPath == ""))
                        {
                            _projToSave.FileContents = editorBox.Text;
                            Saver.SaveProject(_projToSave);
                        }
                        _isNeededClosed = true;
                        Environment.Exit(0);
                        break;
                    case DialogResult.No:
                        //LockAll();
                        _isNeededClosed = true;
                        Environment.Exit(0);
                        break;
                    case DialogResult.Cancel:
                        e.Cancel = true;
                        break;
                }
            }
        }

        private void editorBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void saveClicked(object sender, EventArgs e)
        {
            _projToSave = _currProj;
            if (_currProj == null)
                Saver.SaveScript(_scriptPath, editorBox.Text);
            else if ((_currProj != null) && (_projToSave != null) && (_scriptPath == ""))
            {
                _projToSave.FileContents = editorBox.Text;
                Saver.SaveProject(_projToSave);
            }
        }

        private void openLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (_isProjectOrScriptLoaded)
            {
                var dlg = MessageBox.Show("{SAVE_BEFORE_QUIT}", "{INFO}", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information);
                switch (dlg)
                {
                    case DialogResult.Yes:
                        //LockAll();
                        _projToSave = _currProj;
                        if (_currProj == null)
                            Saver.SaveScript(_scriptPath, editorBox.Text);
                        else if ((_currProj != null) && (_projToSave != null) && (_scriptPath == ""))
                        {
                            _projToSave.FileContents = editorBox.Text;
                            Saver.SaveProject(_projToSave);
                        }
                        var dlg1 = openDialog.ShowDialog(this);
                        switch (dlg1)
                        {
                            case DialogResult.OK:
                                if (openDialog.FileName.EndsWith("lsproj"))
                                {
                                    _isProject = true;
                                    Opener.OpenProject(openDialog.FileName);
                                    StaticData.CurrentProject = _currProj;
                                    editorBox.Text = _currProj.FileContents;
                                    welcomePanel.Visible = false;
                                    editorPanel.Visible = true;
                                    UnlockAll();
                                }
                                else if (openDialog.FileName.EndsWith("litescript"))
                                {
                                    _isProject = false;
                                    _scriptPath = openDialog.FileName;
                                    editorBox.Text = Opener.OpenScript(openDialog.FileName);
                                    welcomePanel.Visible = false;
                                    editorPanel.Visible = true;
                                    UnlockAll();
                                }
                                break;
                            case DialogResult.Cancel:
                                break;
                        }
                        break;
                    case DialogResult.No:
                        //LockAll();
                        var dlg2 = openDialog.ShowDialog(this);
                        switch (dlg2)
                        {
                            case DialogResult.OK:
                                if (openDialog.FileName.EndsWith("lsproj"))
                                {
                                    _isProject = true;
                                    Opener.OpenProject(openDialog.FileName);
                                    StaticData.CurrentProject = _currProj;
                                    editorBox.Text = _currProj.FileContents;
                                    welcomePanel.Visible = false;
                                    editorPanel.Visible = true;
                                    UnlockAll();
                                }
                                else if (openDialog.FileName.EndsWith("litescript"))
                                {
                                    _isProject = false;
                                    _scriptPath = openDialog.FileName;
                                    editorBox.Text = Opener.OpenScript(openDialog.FileName);
                                    welcomePanel.Visible = false;
                                    editorPanel.Visible = true;
                                    UnlockAll();
                                }
                                break;
                            case DialogResult.Cancel:
                                break;
                        }
                        break;
                    case DialogResult.Cancel:
                        return;
                }
            }
            else
            {
                var dlg = openDialog.ShowDialog(this);
                switch (dlg)
                {
                    case DialogResult.OK:
                        if (openDialog.FileName.EndsWith("lsproj"))
                        {
                            _isProject = true;
                            Opener.OpenProject(openDialog.FileName);
                            StaticData.CurrentProject = _currProj;
                            editorBox.Text = _currProj.FileContents;
                            welcomePanel.Visible = false;
                            editorPanel.Visible = true;
                            UnlockAll();
                        }
                        else if (openDialog.FileName.EndsWith("litescript"))
                        {
                            _isProject = false;
                            _scriptPath = openDialog.FileName;
                            editorBox.Text = Opener.OpenScript(openDialog.FileName);
                            StaticData.CurrentProject = _currProj;
                            welcomePanel.Visible = false;
                            editorPanel.Visible = true;
                            UnlockAll();
                        }
                        break;
                    case DialogResult.Cancel:
                        break;
                }
            }
        }

        private void LoadSyntaxHl()
        {
            editorBox.Language = FastColoredTextBoxNS.Language.Custom;
            editorBox.DescriptionFile = Application.StartupPath + "\\res\\ls-syntax.xml";
        }

        private void runBtn_Click(object sender, EventArgs e)
        {
            saveClicked(null, e);
            Builder.RunBuild(_currProj.ProjRoot + "\\" + _currProj.ProjName + ".litescript", true);
        }

        private void buildBtn_Click(object sender, EventArgs e)
        {
            saveClicked(null, e);
            Builder.RunBuild(_currProj.ProjRoot + "\\" + _currProj.ProjName + ".litescript", false);
            
        }

        private void LoadLocales()
        {
            DebugLogger.Write("INFO", "Applying locales for form " + nameof(MainForm));
            Text = "LiteScript IDE version 1.0";
            #region =============== File menu =================

            // Root
            filemenu.Text = StaticData.LocaleProv.GetValue("forms.main.controls.menu.file");

            // New
            newMenu.Text = StaticData.LocaleProv.GetValue("forms.main.controls.menu.file.new.root");
            projNewMenu.Text = StaticData.LocaleProv.GetValue("forms.main.controls.menu.file.new.project");
            scriptNewMenu.Text = StaticData.LocaleProv.GetValue("forms.main.controls.menu.file.new.script");

            // Open
            openMenu.Text = StaticData.LocaleProv.GetValue("forms.main.controls.open");

            // Save
            saveMenu.Text = StaticData.LocaleProv.GetValue("forms.main.controls.save");
            
            // Close
            closeMenu.Text = StaticData.LocaleProv.GetValue("forms.main.controls.close");
            #endregion
            #region =============== Edit menu =================

            // Root
            editmenu.Text = StaticData.LocaleProv.GetValue("forms.main.controls.menu.edit");

            // Undo/redo
            undoMenu.Text = StaticData.LocaleProv.GetValue("forms.main.controls.undo");
            redoMenu.Text = StaticData.LocaleProv.GetValue("forms.main.controls.redo");
            
            // Clipboard operations
            cutMenu.Text = StaticData.LocaleProv.GetValue("forms.main.controls.cut");
            copyMenu.Text = StaticData.LocaleProv.GetValue("forms.main.controls.copy");
            pasteMenu.Text = StaticData.LocaleProv.GetValue("forms.main.controls.paste");
            
            // Delete
            deleteMenu.Text = StaticData.LocaleProv.GetValue("forms.main.controls.delete");

            // Selection/Clearing all
            selAllMenu.Text = StaticData.LocaleProv.GetValue("forms.main.controls.select-all");
            clearAll.Text = StaticData.LocaleProv.GetValue("forms.main.controls.clear-all");

            // Search
            findMenu.Text = StaticData.LocaleProv.GetValue("forms.main.controls.find");
            replMenu.Text = StaticData.LocaleProv.GetValue("forms.main.controls.replace");
            #endregion
            #region ============== Script menu ================

            // Root
            scriptmenu.Text = StaticData.LocaleProv.GetValue("forms.main.controls.menu.script");
            
            // Run/Build
            runMenu.Text = StaticData.LocaleProv.GetValue("forms.main.controls.run");
            buildMenu.Text = StaticData.LocaleProv.GetValue("forms.main.controls.build");

            // Open folders
            openBuildMenu.Text = StaticData.LocaleProv.GetValue("forms.main.controls.build.open");
            openProjRoot.Text = StaticData.LocaleProv.GetValue("forms.main.controls.open-project-root");

            // Error list
            errorlist.Text = StaticData.LocaleProv.GetValue("forms.main.controls.error-list");
            #endregion
            #region ============== Service menu ===============

            // Root
            servicemenu.Text = StaticData.LocaleProv.GetValue("forms.main.controls.menu.service");

            // Service items
            ideSetupMenu.Text = StaticData.LocaleProv.GetValue("forms.main.controls.settings");
            pluginMngrMenu.Text = StaticData.LocaleProv.GetValue("forms.main.controls.plugin-manager");
            downloadCenter.Text = StaticData.LocaleProv.GetValue("forms.main.controls.download-center");
            #endregion
            #region =============== Help menu =================

            // Root
            helpmenu.Text = StaticData.LocaleProv.GetValue("forms.main.controls.menu.help");

            // About/Site
            aboutMenu.Text = StaticData.LocaleProv.GetValue("forms.main.controls.about");
            ideSiteMenu.Text = StaticData.LocaleProv.GetValue("forms.main.controls.open-site");

            // Download Center
            downldCenterWebMenu.Text = StaticData.LocaleProv.GetValue("forms.main.controls.download-center-in-web");

            // Documentation
            docMenu.Text = StaticData.LocaleProv.GetValue("forms.main.controls.documentation");
            #endregion
            #region ================= Links ===================

            openLink.Text = StaticData.LocaleProv.GetValue("forms.main.controls.link.open");
            newLink.Text = StaticData.LocaleProv.GetValue("forms.main.controls.link.new");
            docLink.Text = StaticData.LocaleProv.GetValue("forms.main.controls.link.documentation");
            webLink.Text = StaticData.LocaleProv.GetValue("forms.main.controls.link.site");

            #endregion
            #region ================ Buttons ==================

            openBtn.Text = StaticData.LocaleProv.GetValue("forms.main.controls.open");
            saveBtn.Text = StaticData.LocaleProv.GetValue("forms.main.controls.save");

            undoBtn.Text = StaticData.LocaleProv.GetValue("forms.main.controls.undo");
            redoBtn.Text = StaticData.LocaleProv.GetValue("forms.main.controls.redo");

            copyBtn.Text = StaticData.LocaleProv.GetValue("forms.main.controls.copy");
            cutBtn.Text = StaticData.LocaleProv.GetValue("forms.main.controls.cut");
            pasteBtn.Text = StaticData.LocaleProv.GetValue("forms.main.controls.paste");

            runBtn.Text = StaticData.LocaleProv.GetValue("forms.main.controls.run");
            buildBtn.Text = StaticData.LocaleProv.GetValue("forms.main.controls.build");

            #endregion
            #region ================= Others ==================

            statusbar.Text = StaticData.LocaleProv.GetValue("forms.main.status.default");

            openDialog.Title = StaticData.LocaleProv.GetValue("dialogs.open.title");

            #endregion
        }

        #region ======= API INTEGRATION =======

        public void AddMenuEntry(ToolStripMenuItem item)
        {
            if (menuStrip1.InvokeRequired)
                menuStrip1.Invoke(new Action(() => { menuStrip1.Items.Add(item); }));
            else menuStrip1.Items.Add(item);
        }

        public void AddToolBar(ToolStrip toolbar)
        {
            if (toolStripContainer1.InvokeRequired)
                toolStripContainer1.Invoke(new Action(() => { toolStripContainer1.TopToolStripPanel.Controls.Add(toolbar); }));
            else toolStripContainer1.TopToolStripPanel.Controls.Add(toolbar);
        }

        public void ChangeStatus(string status)
        {
            statusbar.Text = status;
        }

        // Run, load, stop
        public void LoadPlugins()
        {
            DebugLogger.Write("PLGLDR\\INFO", "Loading plugins...");
            _pl = new PluginLoader();
            _pl.ScanPlugins(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "LiteScriptIDE", "Plugins"));
            StaticData.Plugins = new Dictionary<bool, IIdePlugin>();

            if (_pl.Plugins.Count < 1)
            {
                DebugLogger.Write("PLGLDR\\INFO", "No plugins found! Skipping all plugins load, run and stop operations!");
                return;
            }
            foreach (var plugin in _pl.Plugins)
            {
                DebugLogger.Write("PLGLDR\\INFO", "Loading plugin - " + plugin.Id + " version: " + plugin.Version.ToString());
                try
                {
                    plugin.OnStart();
                    StaticData.Plugins.Add(true, plugin);
                    DebugLogger.Write("PLGLDR\\FINE", "Loaded plugin - " + plugin.Id + " version: " + plugin.Version.ToString());
                }
                catch
                {
                    StaticData.Plugins.Add(false, plugin);
                    DebugLogger.Write("PLGLDR\\SEVERE", "Failed to load plugin - " + plugin.Id + " version: " + plugin.Version.ToString());
                }
            }
        }

        public void RunPlugins()
        {
            foreach (var plugin in StaticData.Plugins)
            {
                if (plugin.Key)
                    try
                    {
                        DebugLogger.Write("PLGLDR\\INFO", "Activating plugin - " + plugin.Value.Id + " version: " + plugin.Value.Version.ToString());
                        plugin.Value.OnRunning(this);
                        DebugLogger.Write("PLGLDR\\FINE", "Activated plugin - " + plugin.Value.Id + " version: " + plugin.Value.Version.ToString());
                    }
                    catch
                    {
                        DebugLogger.Write("PLGLDR\\SEVERE", "Failed to activate plugin - " + plugin.Value.Id + " version: " + plugin.Value.Version.ToString());
                    }
            }
        }

        public void StopPlugins()
        {
            foreach (var plugin in StaticData.Plugins)
            {
                if (plugin.Key)
                    try
                    {
                        DebugLogger.Write("PLGLDR\\INFO", "Stopping plugin - " + plugin.Value.Id + " version: " + plugin.Value.Version.ToString());
                        plugin.Value.OnStop();
                        DebugLogger.Write("PLGLDR\\FINE", "Stopped plugin - " + plugin.Value.Id + " version: " + plugin.Value.Version.ToString());
                    }
                    catch
                    {
                        DebugLogger.Write("PLGLDR\\SEVERE", "Failed to stop plugin - " + plugin.Value.Id + " version: " + plugin.Value.Version.ToString() + " Plugin data may be corrupted!");
                    }
            }
        }

        #endregion

        private void pluginMngrMenu_Click(object sender, EventArgs e)
        {
            PluginManager pm = new PluginManager();
            pm.ShowDialog();
        }

        private void errorlist_Click(object sender, EventArgs e)
        {
            ErrorList errl = new ErrorList(_latestErrs);
            errl.ShowDialog();
        }

        private void openBuildMenu_Click(object sender, EventArgs e)
        {
            string _path = Path.Combine(_currProj.ProjRoot, "build");
            System.Diagnostics.Process.Start("explorer.exe", _path);
        }

        private void openProjRoot_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("explorer.exe", _currProj.ProjRoot);
        }

        private void undoMenu_Click(object sender, EventArgs e)
        {
            editorBox.Undo();
        }

        private void redoMenu_Click(object sender, EventArgs e)
        {
            editorBox.Redo();
        }

        private void cutMenu_Click(object sender, EventArgs e)
        {
            editorBox.Cut();
        }

        private void copyMenu_Click(object sender, EventArgs e)
        {
            editorBox.Copy();
        }

        private void pasteMenu_Click(object sender, EventArgs e)
        {
            editorBox.Paste();
        }

        private void deleteMenu_Click(object sender, EventArgs e)
        {
            editorBox.SelectedText = "";
        }

        private void selAllMenu_Click(object sender, EventArgs e)
        {
            editorBox.SelectAll();
        }

        private void clearAll_Click(object sender, EventArgs e)
        {
            editorBox.Clear();
        }

        private void findMenu_Click(object sender, EventArgs e)
        {
            editorBox.ShowFindDialog();
        }

        private void replMenu_Click(object sender, EventArgs e)
        {
            editorBox.ShowReplaceDialog();
        }

        private void ideSetupMenu_Click(object sender, EventArgs e)
        {

        }

        private void aboutMenu_Click(object sender, EventArgs e)
        {
            About ab = new About();
            ab.ShowDialog();
        }

        private void docMenu_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://craftersmine-wiki.hol.es/wiki/LiteScript/");
        }

        private void ideSiteMenu_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://litescript.hol.es/");
        }

        private void downldCenterWebMenu_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://litescript.hol.es/download-center.html");
        }
    }
}
