namespace Artfulbits.Android.Localization
{
	partial class MainForm
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose( bool disposing )
		{
			if( disposing && ( components != null ) )
			{
				components.Dispose();
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            System.Windows.Forms.ListViewItem listViewItem1 = new System.Windows.Forms.ListViewItem(new string[] {
            "Test",
            "Value1",
            "Value2"}, -1);
            this.lblProjectPath = new System.Windows.Forms.Label();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.fbdProjectBrowser = new System.Windows.Forms.FolderBrowserDialog();
            this.popupActions = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.nextEmptyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.previousEmptyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copyFromOriginalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
            this.refrToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripSeparator();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuYandex = new System.Windows.Forms.ToolStripMenuItem();
            this.imgStates = new System.Windows.Forms.ImageList(this.components);
            this.stripActions = new System.Windows.Forms.ToolStrip();
            this.btnSave = new System.Windows.Forms.ToolStripButton();
            this.btnRefresh = new System.Windows.Forms.ToolStripButton();
            this.stripOpenFolder = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnNext = new System.Windows.Forms.ToolStripButton();
            this.btnPrev = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btnCopyOrig = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.btnAddLine = new System.Windows.Forms.ToolStripButton();
            this.btnRemoveLine = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.stripTranslate = new System.Windows.Forms.ToolStripButton();
            this.layoutMain = new System.Windows.Forms.TableLayoutPanel();
            this.lvStrings = new Artfulbits.Android.Localization.GUI.Controls.ListViewEx();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lblInfo = new System.Windows.Forms.Label();
            this.btnCreateFolder = new System.Windows.Forms.Button();
            this.comboResourceFolder = new System.Windows.Forms.ComboBox();
            this.comboResourceFile = new System.Windows.Forms.ComboBox();
            this.layoutFiles = new System.Windows.Forms.TableLayoutPanel();
            this.btnEditExternal = new System.Windows.Forms.Button();
            this.btnRemoveFile = new System.Windows.Forms.Button();
            this.toolTipMain = new System.Windows.Forms.ToolTip(this.components);
            this.popupAbout = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.aboutToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.workerAutoTranslate = new System.ComponentModel.BackgroundWorker();
            this.statusTranslate = new System.Windows.Forms.StatusStrip();
            this.stripTranslateInfo = new System.Windows.Forms.ToolStripStatusLabel();
            this.prgTranslation = new System.Windows.Forms.ToolStripProgressBar();
            this.btnTransCancel = new System.Windows.Forms.ToolStripStatusLabel();
            this.fileWatcher = new System.IO.FileSystemWatcher();
            this.popupActions.SuspendLayout();
            this.stripActions.SuspendLayout();
            this.layoutMain.SuspendLayout();
            this.layoutFiles.SuspendLayout();
            this.popupAbout.SuspendLayout();
            this.statusTranslate.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fileWatcher)).BeginInit();
            this.SuspendLayout();
            // 
            // lblProjectPath
            // 
            this.lblProjectPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblProjectPath.Location = new System.Drawing.Point(12, 12);
            this.lblProjectPath.Name = "lblProjectPath";
            this.lblProjectPath.Size = new System.Drawing.Size(467, 23);
            this.lblProjectPath.TabIndex = 0;
            this.lblProjectPath.Text = "<path to the Android project>";
            this.lblProjectPath.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.toolTipMain.SetToolTip(this.lblProjectPath, "Path to selected project");
            // 
            // btnBrowse
            // 
            this.btnBrowse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBrowse.Location = new System.Drawing.Point(485, 12);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(75, 23);
            this.btnBrowse.TabIndex = 1;
            this.btnBrowse.Text = "&Browse...";
            this.toolTipMain.SetToolTip(this.btnBrowse, "Click to select Android application folder");
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // fbdProjectBrowser
            // 
            this.fbdProjectBrowser.Description = "Select project";
            this.fbdProjectBrowser.ShowNewFolderButton = false;
            // 
            // popupActions
            // 
            this.popupActions.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.editToolStripMenuItem,
            this.toolStripMenuItem1,
            this.nextEmptyToolStripMenuItem,
            this.previousEmptyToolStripMenuItem,
            this.copyFromOriginalToolStripMenuItem,
            this.toolStripMenuItem2,
            this.deleteToolStripMenuItem,
            this.toolStripMenuItem3,
            this.refrToolStripMenuItem,
            this.toolStripMenuItem4,
            this.optionsToolStripMenuItem,
            this.aboutToolStripMenuItem,
            this.menuYandex});
            this.popupActions.Name = "popupActions";
            this.popupActions.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.popupActions.Size = new System.Drawing.Size(234, 226);
            this.popupActions.Opening += new System.ComponentModel.CancelEventHandler(this.popupActions_Opening);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.E)));
            this.editToolStripMenuItem.Size = new System.Drawing.Size(233, 22);
            this.editToolStripMenuItem.Text = "&Edit...";
            this.editToolStripMenuItem.Click += new System.EventHandler(this.editToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(230, 6);
            // 
            // nextEmptyToolStripMenuItem
            // 
            this.nextEmptyToolStripMenuItem.Image = global::Artfulbits.Android.Localization.Properties.Resources.arrowdown_blue16;
            this.nextEmptyToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.nextEmptyToolStripMenuItem.Name = "nextEmptyToolStripMenuItem";
            this.nextEmptyToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.Down)));
            this.nextEmptyToolStripMenuItem.Size = new System.Drawing.Size(233, 22);
            this.nextEmptyToolStripMenuItem.Text = "Go to Next empty";
            this.nextEmptyToolStripMenuItem.Click += new System.EventHandler(this.nextEmptyToolStripMenuItem_Click);
            // 
            // previousEmptyToolStripMenuItem
            // 
            this.previousEmptyToolStripMenuItem.Image = global::Artfulbits.Android.Localization.Properties.Resources.arrowup_blue16;
            this.previousEmptyToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.previousEmptyToolStripMenuItem.Name = "previousEmptyToolStripMenuItem";
            this.previousEmptyToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.Up)));
            this.previousEmptyToolStripMenuItem.Size = new System.Drawing.Size(233, 22);
            this.previousEmptyToolStripMenuItem.Text = "Go to Previous empty";
            this.previousEmptyToolStripMenuItem.Click += new System.EventHandler(this.previousEmptyToolStripMenuItem_Click);
            // 
            // copyFromOriginalToolStripMenuItem
            // 
            this.copyFromOriginalToolStripMenuItem.Image = global::Artfulbits.Android.Localization.Properties.Resources.arrowright_green16;
            this.copyFromOriginalToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.copyFromOriginalToolStripMenuItem.Name = "copyFromOriginalToolStripMenuItem";
            this.copyFromOriginalToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.Right)));
            this.copyFromOriginalToolStripMenuItem.Size = new System.Drawing.Size(233, 22);
            this.copyFromOriginalToolStripMenuItem.Text = "&Copy from original";
            this.copyFromOriginalToolStripMenuItem.Click += new System.EventHandler(this.copyFromOriginalToolStripMenuItem_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(230, 6);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Image = global::Artfulbits.Android.Localization.Properties.Resources.minus16;
            this.deleteToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D)));
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(233, 22);
            this.deleteToolStripMenuItem.Text = "&Delete";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(230, 6);
            // 
            // refrToolStripMenuItem
            // 
            this.refrToolStripMenuItem.Image = global::Artfulbits.Android.Localization.Properties.Resources.refresh16;
            this.refrToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.refrToolStripMenuItem.Name = "refrToolStripMenuItem";
            this.refrToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F5;
            this.refrToolStripMenuItem.Size = new System.Drawing.Size(233, 22);
            this.refrToolStripMenuItem.Text = "&Refresh";
            this.refrToolStripMenuItem.Click += new System.EventHandler(this.refrToolStripMenuItem_Click);
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(230, 6);
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(233, 22);
            this.optionsToolStripMenuItem.Text = "&Options...";
            this.optionsToolStripMenuItem.Click += new System.EventHandler(this.optionsToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(233, 22);
            this.aboutToolStripMenuItem.Text = "&About...";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // menuYandex
            // 
            this.menuYandex.CheckOnClick = true;
            this.menuYandex.Name = "menuYandex";
            this.menuYandex.Size = new System.Drawing.Size(233, 22);
            this.menuYandex.Text = "Use yandex api for translate";
            // 
            // imgStates
            // 
            this.imgStates.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgStates.ImageStream")));
            this.imgStates.TransparentColor = System.Drawing.Color.Magenta;
            this.imgStates.Images.SetKeyName(0, "alarm16.bmp");
            this.imgStates.Images.SetKeyName(1, "about16.bmp");
            this.imgStates.Images.SetKeyName(2, "tick_all16.bmp");
            this.imgStates.Images.SetKeyName(3, "verify_document16.bmp");
            this.imgStates.Images.SetKeyName(4, "tick16_h.bmp");
            this.imgStates.Images.SetKeyName(5, "contact_delete16a_h.bmp");
            // 
            // stripActions
            // 
            this.stripActions.Enabled = false;
            this.stripActions.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.stripActions.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnSave,
            this.btnRefresh,
            this.stripOpenFolder,
            this.toolStripSeparator1,
            this.btnNext,
            this.btnPrev,
            this.toolStripSeparator2,
            this.btnCopyOrig,
            this.toolStripSeparator3,
            this.btnAddLine,
            this.btnRemoveLine,
            this.toolStripSeparator4,
            this.stripTranslate});
            this.stripActions.Location = new System.Drawing.Point(0, 0);
            this.stripActions.Name = "stripActions";
            this.stripActions.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.stripActions.Size = new System.Drawing.Size(549, 25);
            this.stripActions.Stretch = true;
            this.stripActions.TabIndex = 0;
            // 
            // btnSave
            // 
            this.btnSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnSave.Image = global::Artfulbits.Android.Localization.Properties.Resources.save16;
            this.btnSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(23, 22);
            this.btnSave.Text = "Save changes";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnRefresh.Image = global::Artfulbits.Android.Localization.Properties.Resources.refresh16;
            this.btnRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(23, 22);
            this.btnRefresh.Text = "Refresh Document";
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // stripOpenFolder
            // 
            this.stripOpenFolder.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.stripOpenFolder.Image = global::Artfulbits.Android.Localization.Properties.Resources.move_to16;
            this.stripOpenFolder.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.stripOpenFolder.Name = "stripOpenFolder";
            this.stripOpenFolder.Size = new System.Drawing.Size(23, 22);
            this.stripOpenFolder.Text = "Open folder...";
            this.stripOpenFolder.Click += new System.EventHandler(this.stripOpenFolder_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // btnNext
            // 
            this.btnNext.Image = global::Artfulbits.Android.Localization.Properties.Resources.arrowdown_blue16;
            this.btnNext.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(88, 22);
            this.btnNext.Text = "Next Empty";
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // btnPrev
            // 
            this.btnPrev.Image = global::Artfulbits.Android.Localization.Properties.Resources.arrowup_blue16;
            this.btnPrev.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnPrev.Name = "btnPrev";
            this.btnPrev.Size = new System.Drawing.Size(87, 22);
            this.btnPrev.Text = "Prev Empty";
            this.btnPrev.Click += new System.EventHandler(this.btnPrev_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // btnCopyOrig
            // 
            this.btnCopyOrig.Image = global::Artfulbits.Android.Localization.Properties.Resources.arrowright_green16;
            this.btnCopyOrig.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnCopyOrig.Name = "btnCopyOrig";
            this.btnCopyOrig.Size = new System.Drawing.Size(129, 22);
            this.btnCopyOrig.Text = "Copy from Original";
            this.btnCopyOrig.Click += new System.EventHandler(this.btnCopyOrig_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // btnAddLine
            // 
            this.btnAddLine.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnAddLine.Image = global::Artfulbits.Android.Localization.Properties.Resources.plus16;
            this.btnAddLine.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAddLine.Name = "btnAddLine";
            this.btnAddLine.Size = new System.Drawing.Size(23, 22);
            this.btnAddLine.Text = "Add Line";
            this.btnAddLine.Click += new System.EventHandler(this.btnAddLine_Click);
            // 
            // btnRemoveLine
            // 
            this.btnRemoveLine.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnRemoveLine.Image = global::Artfulbits.Android.Localization.Properties.Resources.minus16;
            this.btnRemoveLine.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnRemoveLine.Name = "btnRemoveLine";
            this.btnRemoveLine.Size = new System.Drawing.Size(23, 22);
            this.btnRemoveLine.Text = "Remove Line";
            this.btnRemoveLine.Click += new System.EventHandler(this.btnRemoveLine_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 25);
            // 
            // stripTranslate
            // 
            this.stripTranslate.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.stripTranslate.Image = ((System.Drawing.Image)(resources.GetObject("stripTranslate.Image")));
            this.stripTranslate.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.stripTranslate.Name = "stripTranslate";
            this.stripTranslate.Size = new System.Drawing.Size(96, 22);
            this.stripTranslate.Text = "Auto Translate...";
            this.stripTranslate.ToolTipText = resources.GetString("stripTranslate.ToolTipText");
            this.stripTranslate.Click += new System.EventHandler(this.stripTranslate_Click);
            // 
            // layoutMain
            // 
            this.layoutMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.layoutMain.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.layoutMain.ColumnCount = 1;
            this.layoutMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.layoutMain.Controls.Add(this.stripActions, 0, 0);
            this.layoutMain.Controls.Add(this.lvStrings, 0, 1);
            this.layoutMain.Controls.Add(this.lblInfo, 0, 2);
            this.layoutMain.Location = new System.Drawing.Point(11, 74);
            this.layoutMain.Name = "layoutMain";
            this.layoutMain.RowCount = 3;
            this.layoutMain.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.layoutMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.layoutMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.layoutMain.Size = new System.Drawing.Size(549, 339);
            this.layoutMain.TabIndex = 3;
            // 
            // lvStrings
            // 
            this.lvStrings.ColumnOrderArray = new int[] {
        0,
        1,
        2};
            this.lvStrings.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.lvStrings.ContextMenuStrip = this.popupActions;
            this.lvStrings.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvStrings.Enabled = false;
            this.lvStrings.FullRowSelect = true;
            this.lvStrings.GridLines = true;
            this.lvStrings.HideSelection = false;
            listViewItem1.StateImageIndex = 0;
            this.lvStrings.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem1});
            this.lvStrings.Location = new System.Drawing.Point(3, 28);
            this.lvStrings.Name = "lvStrings";
            this.lvStrings.ShowGroups = false;
            this.lvStrings.Size = new System.Drawing.Size(543, 276);
            this.lvStrings.StateImageList = this.imgStates;
            this.lvStrings.TabIndex = 1;
            this.lvStrings.TileSize = new System.Drawing.Size(1, 1);
            this.lvStrings.UseCompatibleStateImageBehavior = false;
            this.lvStrings.View = System.Windows.Forms.View.Details;
            this.lvStrings.SelectedIndexChanged += new System.EventHandler(this.lvStrings_SelectedIndexChanged);
            this.lvStrings.DoubleClick += new System.EventHandler(this.lvStrings_DoubleClick);
            this.lvStrings.KeyUp += new System.Windows.Forms.KeyEventHandler(this.lvStrings_KeyUp);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Name";
            this.columnHeader1.Width = 185;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Original Value";
            this.columnHeader2.Width = 168;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Local Value";
            this.columnHeader3.Width = 180;
            // 
            // lblInfo
            // 
            this.lblInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblInfo.Location = new System.Drawing.Point(3, 307);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(543, 32);
            this.lblInfo.TabIndex = 2;
            this.lblInfo.Text = resources.GetString("lblInfo.Text");
            this.lblInfo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnCreateFolder
            // 
            this.btnCreateFolder.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnCreateFolder.Enabled = false;
            this.btnCreateFolder.Image = global::Artfulbits.Android.Localization.Properties.Resources.plus16;
            this.btnCreateFolder.Location = new System.Drawing.Point(232, 2);
            this.btnCreateFolder.Margin = new System.Windows.Forms.Padding(2);
            this.btnCreateFolder.Name = "btnCreateFolder";
            this.btnCreateFolder.Size = new System.Drawing.Size(24, 23);
            this.btnCreateFolder.TabIndex = 1;
            this.toolTipMain.SetToolTip(this.btnCreateFolder, "Create new localization folder");
            this.btnCreateFolder.UseVisualStyleBackColor = true;
            this.btnCreateFolder.Click += new System.EventHandler(this.btnCreateFolder_Click);
            // 
            // comboResourceFolder
            // 
            this.comboResourceFolder.Dock = System.Windows.Forms.DockStyle.Fill;
            this.comboResourceFolder.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboResourceFolder.Enabled = false;
            this.comboResourceFolder.FormattingEnabled = true;
            this.comboResourceFolder.Location = new System.Drawing.Point(3, 3);
            this.comboResourceFolder.Name = "comboResourceFolder";
            this.comboResourceFolder.Size = new System.Drawing.Size(224, 21);
            this.comboResourceFolder.TabIndex = 0;
            this.toolTipMain.SetToolTip(this.comboResourceFolder, "Select from list localization which you want to edit");
            this.comboResourceFolder.SelectedIndexChanged += new System.EventHandler(this.comboResourceFolder_SelectedIndexChanged);
            this.comboResourceFolder.TextChanged += new System.EventHandler(this.comboResourceFolder_TextChanged);
            // 
            // comboResourceFile
            // 
            this.comboResourceFile.Dock = System.Windows.Forms.DockStyle.Fill;
            this.comboResourceFile.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboResourceFile.Enabled = false;
            this.comboResourceFile.FormattingEnabled = true;
            this.comboResourceFile.Location = new System.Drawing.Point(261, 3);
            this.comboResourceFile.Name = "comboResourceFile";
            this.comboResourceFile.Size = new System.Drawing.Size(224, 21);
            this.comboResourceFile.TabIndex = 2;
            this.toolTipMain.SetToolTip(this.comboResourceFile, "Select file for comparing and editing");
            this.comboResourceFile.SelectedIndexChanged += new System.EventHandler(this.comboResourceFile_SelectedIndexChanged);
            this.comboResourceFile.TextChanged += new System.EventHandler(this.comboResourceFile_TextChanged);
            // 
            // layoutFiles
            // 
            this.layoutFiles.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.layoutFiles.AutoSize = true;
            this.layoutFiles.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.layoutFiles.ColumnCount = 5;
            this.layoutFiles.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.layoutFiles.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.layoutFiles.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.layoutFiles.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.layoutFiles.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.layoutFiles.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.layoutFiles.Controls.Add(this.btnEditExternal, 4, 0);
            this.layoutFiles.Controls.Add(this.comboResourceFolder, 0, 0);
            this.layoutFiles.Controls.Add(this.btnCreateFolder, 1, 0);
            this.layoutFiles.Controls.Add(this.comboResourceFile, 2, 0);
            this.layoutFiles.Controls.Add(this.btnRemoveFile, 3, 0);
            this.layoutFiles.Location = new System.Drawing.Point(12, 41);
            this.layoutFiles.Name = "layoutFiles";
            this.layoutFiles.RowCount = 1;
            this.layoutFiles.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.layoutFiles.Size = new System.Drawing.Size(544, 27);
            this.layoutFiles.TabIndex = 2;
            // 
            // btnEditExternal
            // 
            this.btnEditExternal.Enabled = false;
            this.btnEditExternal.Image = global::Artfulbits.Android.Localization.Properties.Resources.rename16;
            this.btnEditExternal.Location = new System.Drawing.Point(518, 2);
            this.btnEditExternal.Margin = new System.Windows.Forms.Padding(2);
            this.btnEditExternal.Name = "btnEditExternal";
            this.btnEditExternal.Size = new System.Drawing.Size(24, 23);
            this.btnEditExternal.TabIndex = 4;
            this.toolTipMain.SetToolTip(this.btnEditExternal, "Open file in external editor. External editor defined in *.config file.");
            this.btnEditExternal.UseVisualStyleBackColor = true;
            this.btnEditExternal.Click += new System.EventHandler(this.btnEditExternal_Click);
            // 
            // btnRemoveFile
            // 
            this.btnRemoveFile.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnRemoveFile.Enabled = false;
            this.btnRemoveFile.Image = global::Artfulbits.Android.Localization.Properties.Resources.minus16;
            this.btnRemoveFile.Location = new System.Drawing.Point(490, 2);
            this.btnRemoveFile.Margin = new System.Windows.Forms.Padding(2);
            this.btnRemoveFile.Name = "btnRemoveFile";
            this.btnRemoveFile.Size = new System.Drawing.Size(24, 23);
            this.btnRemoveFile.TabIndex = 3;
            this.toolTipMain.SetToolTip(this.btnRemoveFile, "Delete file from localization");
            this.btnRemoveFile.UseVisualStyleBackColor = true;
            this.btnRemoveFile.Click += new System.EventHandler(this.btnRemoveFile_Click);
            // 
            // popupAbout
            // 
            this.popupAbout.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem1});
            this.popupAbout.Name = "popupAbout";
            this.popupAbout.Size = new System.Drawing.Size(136, 26);
            // 
            // aboutToolStripMenuItem1
            // 
            this.aboutToolStripMenuItem1.Name = "aboutToolStripMenuItem1";
            this.aboutToolStripMenuItem1.ShortcutKeys = System.Windows.Forms.Keys.F1;
            this.aboutToolStripMenuItem1.Size = new System.Drawing.Size(135, 22);
            this.aboutToolStripMenuItem1.Text = "&About...";
            this.aboutToolStripMenuItem1.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // workerAutoTranslate
            // 
            this.workerAutoTranslate.WorkerReportsProgress = true;
            this.workerAutoTranslate.WorkerSupportsCancellation = true;
            this.workerAutoTranslate.DoWork += new System.ComponentModel.DoWorkEventHandler(this.workerAutoTranslate_DoWork);
            this.workerAutoTranslate.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.workerAutoTranslate_ProgressChanged);
            this.workerAutoTranslate.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.workerAutoTranslate_RunWorkerCompleted);
            // 
            // statusTranslate
            // 
            this.statusTranslate.AutoSize = false;
            this.statusTranslate.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.stripTranslateInfo,
            this.prgTranslation,
            this.btnTransCancel});
            this.statusTranslate.Location = new System.Drawing.Point(0, 422);
            this.statusTranslate.Name = "statusTranslate";
            this.statusTranslate.Size = new System.Drawing.Size(572, 24);
            this.statusTranslate.TabIndex = 4;
            // 
            // stripTranslateInfo
            // 
            this.stripTranslateInfo.Name = "stripTranslateInfo";
            this.stripTranslateInfo.Size = new System.Drawing.Size(68, 19);
            this.stripTranslateInfo.Text = "Translation:";
            // 
            // prgTranslation
            // 
            this.prgTranslation.Margin = new System.Windows.Forms.Padding(8, 3, 1, 3);
            this.prgTranslation.Name = "prgTranslation";
            this.prgTranslation.Size = new System.Drawing.Size(100, 18);
            // 
            // btnTransCancel
            // 
            this.btnTransCancel.AutoSize = false;
            this.btnTransCancel.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.btnTransCancel.BorderStyle = System.Windows.Forms.Border3DStyle.Raised;
            this.btnTransCancel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnTransCancel.Margin = new System.Windows.Forms.Padding(8, 2, 8, 1);
            this.btnTransCancel.Name = "btnTransCancel";
            this.btnTransCancel.Size = new System.Drawing.Size(43, 21);
            this.btnTransCancel.Text = "Abort";
            this.btnTransCancel.Click += new System.EventHandler(this.btnTransCancel_Click);
            // 
            // fileWatcher
            // 
            this.fileWatcher.EnableRaisingEvents = true;
            this.fileWatcher.SynchronizingObject = this;
            this.fileWatcher.Changed += new System.IO.FileSystemEventHandler(this.watcher_Changed);
            this.fileWatcher.Created += new System.IO.FileSystemEventHandler(this.fileWatcher_Created);
            this.fileWatcher.Deleted += new System.IO.FileSystemEventHandler(this.fileWatcher_Deleted);
            this.fileWatcher.Renamed += new System.IO.RenamedEventHandler(this.fileWatcher_Renamed);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(572, 446);
            this.ContextMenuStrip = this.popupAbout;
            this.Controls.Add(this.statusTranslate);
            this.Controls.Add(this.layoutMain);
            this.Controls.Add(this.layoutFiles);
            this.Controls.Add(this.btnBrowse);
            this.Controls.Add(this.lblProjectPath);
            this.MinimumSize = new System.Drawing.Size(580, 480);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Android Applications Localization Helper";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.popupActions.ResumeLayout(false);
            this.stripActions.ResumeLayout(false);
            this.stripActions.PerformLayout();
            this.layoutMain.ResumeLayout(false);
            this.layoutMain.PerformLayout();
            this.layoutFiles.ResumeLayout(false);
            this.popupAbout.ResumeLayout(false);
            this.statusTranslate.ResumeLayout(false);
            this.statusTranslate.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fileWatcher)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label lblProjectPath;
		private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.FolderBrowserDialog fbdProjectBrowser;
		private Artfulbits.Android.Localization.GUI.Controls.ListViewEx lvStrings;
		private System.Windows.Forms.ColumnHeader columnHeader1;
		private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
    private System.Windows.Forms.ToolStrip stripActions;
    private System.Windows.Forms.ToolStripButton btnNext;
    private System.Windows.Forms.ToolStripButton btnPrev;
    private System.Windows.Forms.ToolStripButton btnCopyOrig;
    private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
    private System.Windows.Forms.ToolStripButton btnRefresh;
    private System.Windows.Forms.ToolStripButton btnAddLine;
    private System.Windows.Forms.ToolStripButton btnRemoveLine;
    private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
    private System.Windows.Forms.ToolStripButton btnSave;
    private System.Windows.Forms.TableLayoutPanel layoutMain;
    private System.Windows.Forms.ImageList imgStates;
    private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
    private System.Windows.Forms.ContextMenuStrip popupActions;
    private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem copyFromOriginalToolStripMenuItem;
    private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
    private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
    private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
    private System.Windows.Forms.ToolStripMenuItem nextEmptyToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem previousEmptyToolStripMenuItem;
    private System.Windows.Forms.Label lblInfo;
    private System.Windows.Forms.ToolStripSeparator toolStripMenuItem3;
    private System.Windows.Forms.ToolStripMenuItem refrToolStripMenuItem;
    private System.Windows.Forms.Button btnCreateFolder;
    private System.Windows.Forms.ComboBox comboResourceFolder;
    private System.Windows.Forms.ComboBox comboResourceFile;
    private System.Windows.Forms.TableLayoutPanel layoutFiles;
    private System.Windows.Forms.Button btnRemoveFile;
    private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
    private System.Windows.Forms.ToolStripSeparator toolStripMenuItem4;
    private System.Windows.Forms.Button btnEditExternal;
    private System.Windows.Forms.ToolTip toolTipMain;
    private System.Windows.Forms.ContextMenuStrip popupAbout;
    private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem1;
    private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
    private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
    private System.Windows.Forms.ToolStripButton stripTranslate;
    private System.ComponentModel.BackgroundWorker workerAutoTranslate;
    private System.Windows.Forms.StatusStrip statusTranslate;
    private System.Windows.Forms.ToolStripStatusLabel stripTranslateInfo;
    private System.Windows.Forms.ToolStripProgressBar prgTranslation;
    private System.Windows.Forms.ToolStripStatusLabel btnTransCancel;
    private System.Windows.Forms.ToolStripButton stripOpenFolder;
    private System.IO.FileSystemWatcher fileWatcher;
        private System.Windows.Forms.ToolStripMenuItem menuYandex;
    }
}

