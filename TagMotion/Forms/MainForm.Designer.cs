namespace Chrismo.TagMotion.Forms
{
	partial class MainForm
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		/// <summary>
		/// Disposes resources used by the form.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
            if(_Thread != null)
                if (_Thread.IsAlive)
                    _Thread.Abort();

			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.panel_Fill = new System.Windows.Forms.Panel();
            this.panel_Treeview = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.TreeView = new System.Windows.Forms.TreeView();
            this.contextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.copyToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.AutoTagToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.freeDBQueryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.storeIinTagsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.extractImageToFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel_Top = new System.Windows.Forms.Panel();
            this.PropertyGrid = new System.Windows.Forms.PropertyGrid();
            this.panel_Icons = new System.Windows.Forms.Panel();
            this.button_ReadSourceDirectory = new System.Windows.Forms.Button();
            this.button_Settings = new System.Windows.Forms.Button();
            this.button_SaveCollectionAs = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.button_Help = new System.Windows.Forms.Button();
            this.button_Filter = new System.Windows.Forms.Button();
            this.PictureBox = new System.Windows.Forms.PictureBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.ProgressBar = new System.Windows.Forms.ProgressBar();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.Statusbar = new System.Windows.Forms.ToolStripStatusLabel();
            this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.panel_Fill.SuspendLayout();
            this.panel_Treeview.SuspendLayout();
            this.panel1.SuspendLayout();
            this.contextMenu.SuspendLayout();
            this.panel_Top.SuspendLayout();
            this.panel_Icons.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel_Fill
            // 
            this.panel_Fill.Controls.Add(this.panel_Treeview);
            this.panel_Fill.Controls.Add(this.statusStrip1);
            this.panel_Fill.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_Fill.Location = new System.Drawing.Point(0, 0);
            this.panel_Fill.Name = "panel_Fill";
            this.panel_Fill.Size = new System.Drawing.Size(792, 768);
            this.panel_Fill.TabIndex = 75;
            // 
            // panel_Treeview
            // 
            this.panel_Treeview.Controls.Add(this.panel1);
            this.panel_Treeview.Controls.Add(this.panel_Top);
            this.panel_Treeview.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_Treeview.Location = new System.Drawing.Point(0, 0);
            this.panel_Treeview.Name = "panel_Treeview";
            this.panel_Treeview.Size = new System.Drawing.Size(792, 746);
            this.panel_Treeview.TabIndex = 82;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.TreeView);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 313);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(792, 433);
            this.panel1.TabIndex = 84;
            // 
            // TreeView
            // 
            this.TreeView.AllowDrop = true;
            this.TreeView.BackColor = System.Drawing.Color.Ivory;
            this.TreeView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TreeView.ContextMenuStrip = this.contextMenu;
            this.TreeView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TreeView.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TreeView.HideSelection = false;
            this.TreeView.ImeMode = System.Windows.Forms.ImeMode.Katakana;
            this.TreeView.Indent = 16;
            this.TreeView.ItemHeight = 16;
            this.TreeView.Location = new System.Drawing.Point(0, 0);
            this.TreeView.Name = "TreeView";
            this.TreeView.Size = new System.Drawing.Size(792, 433);
            this.TreeView.TabIndex = 1;
            this.TreeView.DragDrop += new System.Windows.Forms.DragEventHandler(this.OnDragDrop);
            this.TreeView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.TreeView_AfterSelect);
            this.TreeView.DragEnter += new System.Windows.Forms.DragEventHandler(this.OnDragEnter);
            this.TreeView.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.OnKeyPress);
            this.TreeView.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.TreeViewNode_MouseClick);
            // 
            // contextMenu
            // 
            this.contextMenu.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.contextMenu.Font = new System.Drawing.Font("Tahoma", 8F);
            this.contextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.copyToolStripMenuItem1,
            this.AutoTagToolStripMenuItem,
            this.freeDBQueryToolStripMenuItem,
            this.storeIinTagsToolStripMenuItem,
            this.extractImageToFileToolStripMenuItem,
            this.deleteToolStripMenuItem});
            this.contextMenu.Name = "contextMenuStrip1";
            this.contextMenu.Size = new System.Drawing.Size(188, 158);
            this.contextMenu.Text = "Context Menu";
            // 
            // copyToolStripMenuItem1
            // 
            this.copyToolStripMenuItem1.Image = global::Chrismo.TagMotion.Properties.Resources.edit_copy;
            this.copyToolStripMenuItem1.Name = "copyToolStripMenuItem1";
            this.copyToolStripMenuItem1.Size = new System.Drawing.Size(187, 22);
            this.copyToolStripMenuItem1.Text = "Copy";
            this.copyToolStripMenuItem1.Click += new System.EventHandler(this.Copy_Click);
            // 
            // AutoTagToolStripMenuItem
            // 
            this.AutoTagToolStripMenuItem.Name = "AutoTagToolStripMenuItem";
            this.AutoTagToolStripMenuItem.Size = new System.Drawing.Size(187, 22);
            this.AutoTagToolStripMenuItem.Text = "AutoTag";
            this.AutoTagToolStripMenuItem.Click += new System.EventHandler(this.AutoTag_Click);
            // 
            // freeDBQueryToolStripMenuItem
            // 
            this.freeDBQueryToolStripMenuItem.Name = "freeDBQueryToolStripMenuItem";
            this.freeDBQueryToolStripMenuItem.Size = new System.Drawing.Size(187, 22);
            this.freeDBQueryToolStripMenuItem.Text = "FreeDB Query";
            this.freeDBQueryToolStripMenuItem.Click += new System.EventHandler(this.FreeDBQuery_Click);
            // 
            // storeIinTagsToolStripMenuItem
            // 
            this.storeIinTagsToolStripMenuItem.Name = "storeIinTagsToolStripMenuItem";
            this.storeIinTagsToolStripMenuItem.Size = new System.Drawing.Size(187, 22);
            this.storeIinTagsToolStripMenuItem.Text = "Store Image In Tags";
            this.storeIinTagsToolStripMenuItem.Click += new System.EventHandler(this.StoreImage_Click);
            // 
            // extractImageToFileToolStripMenuItem
            // 
            this.extractImageToFileToolStripMenuItem.Name = "extractImageToFileToolStripMenuItem";
            this.extractImageToFileToolStripMenuItem.Size = new System.Drawing.Size(187, 22);
            this.extractImageToFileToolStripMenuItem.Text = "Extract Image To File";
            this.extractImageToFileToolStripMenuItem.Click += new System.EventHandler(this.ExtractImage_Click);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Image = global::Chrismo.TagMotion.Properties.Resources.process_stop1;
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(187, 22);
            this.deleteToolStripMenuItem.Text = "Delete";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.Delete_Click);
            // 
            // panel_Top
            // 
            this.panel_Top.Controls.Add(this.PropertyGrid);
            this.panel_Top.Controls.Add(this.panel_Icons);
            this.panel_Top.Controls.Add(this.PictureBox);
            this.panel_Top.Controls.Add(this.panel2);
            this.panel_Top.Controls.Add(this.ProgressBar);
            this.panel_Top.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel_Top.Location = new System.Drawing.Point(0, 0);
            this.panel_Top.Name = "panel_Top";
            this.panel_Top.Size = new System.Drawing.Size(792, 313);
            this.panel_Top.TabIndex = 82;
            // 
            // PropertyGrid
            // 
            this.PropertyGrid.BackColor = System.Drawing.Color.Ivory;
            this.PropertyGrid.CommandsDisabledLinkColor = System.Drawing.Color.DarkGray;
            this.PropertyGrid.CommandsLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.PropertyGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PropertyGrid.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PropertyGrid.HelpBackColor = System.Drawing.Color.Ivory;
            this.PropertyGrid.HelpVisible = false;
            this.PropertyGrid.ImeMode = System.Windows.Forms.ImeMode.Katakana;
            this.PropertyGrid.LargeButtons = true;
            this.PropertyGrid.LineColor = System.Drawing.Color.Khaki;
            this.PropertyGrid.Location = new System.Drawing.Point(0, 40);
            this.PropertyGrid.Name = "PropertyGrid";
            this.PropertyGrid.PropertySort = System.Windows.Forms.PropertySort.Categorized;
            this.PropertyGrid.Size = new System.Drawing.Size(494, 258);
            this.PropertyGrid.TabIndex = 82;
            this.PropertyGrid.ToolbarVisible = false;
            this.PropertyGrid.ViewBackColor = System.Drawing.Color.Ivory;
            this.PropertyGrid.PropertyValueChanged += new System.Windows.Forms.PropertyValueChangedEventHandler(this.PropertyGrid_ValueChanged);
            // 
            // panel_Icons
            // 
            this.panel_Icons.BackColor = System.Drawing.Color.Ivory;
            this.panel_Icons.Controls.Add(this.button_ReadSourceDirectory);
            this.panel_Icons.Controls.Add(this.button_Settings);
            this.panel_Icons.Controls.Add(this.button_SaveCollectionAs);
            this.panel_Icons.Controls.Add(this.panel3);
            this.panel_Icons.Controls.Add(this.button_Filter);
            this.panel_Icons.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel_Icons.Location = new System.Drawing.Point(0, 0);
            this.panel_Icons.Name = "panel_Icons";
            this.panel_Icons.Size = new System.Drawing.Size(494, 40);
            this.panel_Icons.TabIndex = 2;
            // 
            // button_ReadSourceDirectory
            // 
            this.button_ReadSourceDirectory.BackgroundImage = global::Chrismo.TagMotion.Properties.Resources.media_playback_start;
            this.button_ReadSourceDirectory.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.button_ReadSourceDirectory.FlatAppearance.BorderSize = 0;
            this.button_ReadSourceDirectory.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_ReadSourceDirectory.Location = new System.Drawing.Point(3, 2);
            this.button_ReadSourceDirectory.Name = "button_ReadSourceDirectory";
            this.button_ReadSourceDirectory.Size = new System.Drawing.Size(35, 35);
            this.button_ReadSourceDirectory.TabIndex = 1;
            this.button_ReadSourceDirectory.TabStop = false;
            this.toolTip.SetToolTip(this.button_ReadSourceDirectory, "Read Source Directory");
            this.button_ReadSourceDirectory.UseVisualStyleBackColor = true;
            this.button_ReadSourceDirectory.Click += new System.EventHandler(this.ReadSourceDirectory_Click);
            // 
            // button_Settings
            // 
            this.button_Settings.BackgroundImage = global::Chrismo.TagMotion.Properties.Resources.preferences_system;
            this.button_Settings.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.button_Settings.FlatAppearance.BorderSize = 0;
            this.button_Settings.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_Settings.Location = new System.Drawing.Point(44, 2);
            this.button_Settings.Name = "button_Settings";
            this.button_Settings.Size = new System.Drawing.Size(35, 35);
            this.button_Settings.TabIndex = 0;
            this.button_Settings.TabStop = false;
            this.toolTip.SetToolTip(this.button_Settings, "Settings");
            this.button_Settings.UseVisualStyleBackColor = true;
            this.button_Settings.Click += new System.EventHandler(this.Settings_Click);
            // 
            // button_SaveCollectionAs
            // 
            this.button_SaveCollectionAs.BackgroundImage = global::Chrismo.TagMotion.Properties.Resources.document_save_as;
            this.button_SaveCollectionAs.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.button_SaveCollectionAs.FlatAppearance.BorderSize = 0;
            this.button_SaveCollectionAs.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_SaveCollectionAs.Location = new System.Drawing.Point(126, 2);
            this.button_SaveCollectionAs.Name = "button_SaveCollectionAs";
            this.button_SaveCollectionAs.Size = new System.Drawing.Size(35, 35);
            this.button_SaveCollectionAs.TabIndex = 2;
            this.button_SaveCollectionAs.TabStop = false;
            this.toolTip.SetToolTip(this.button_SaveCollectionAs, "Save Collection As ...");
            this.button_SaveCollectionAs.UseVisualStyleBackColor = true;
            this.button_SaveCollectionAs.Click += new System.EventHandler(this.SaveCollectionAs_Click);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.button1);
            this.panel3.Controls.Add(this.button_Help);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel3.Location = new System.Drawing.Point(410, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(84, 40);
            this.panel3.TabIndex = 7;
            // 
            // button1
            // 
            this.button1.BackgroundImage = global::Chrismo.TagMotion.Properties.Resources.dialog_information;
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(44, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(35, 35);
            this.button1.TabIndex = 5;
            this.button1.TabStop = false;
            this.toolTip.SetToolTip(this.button1, "About");
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.About_Click);
            // 
            // button_Help
            // 
            this.button_Help.BackgroundImage = global::Chrismo.TagMotion.Properties.Resources.help_browser;
            this.button_Help.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.button_Help.FlatAppearance.BorderSize = 0;
            this.button_Help.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_Help.Location = new System.Drawing.Point(3, 2);
            this.button_Help.Name = "button_Help";
            this.button_Help.Size = new System.Drawing.Size(35, 35);
            this.button_Help.TabIndex = 4;
            this.button_Help.TabStop = false;
            this.toolTip.SetToolTip(this.button_Help, "Help");
            this.button_Help.UseVisualStyleBackColor = true;
            this.button_Help.Click += new System.EventHandler(this.Help_Click);
            // 
            // button_Filter
            // 
            this.button_Filter.BackgroundImage = global::Chrismo.TagMotion.Properties.Resources.system_search;
            this.button_Filter.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.button_Filter.FlatAppearance.BorderSize = 0;
            this.button_Filter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_Filter.Location = new System.Drawing.Point(85, 2);
            this.button_Filter.Name = "button_Filter";
            this.button_Filter.Size = new System.Drawing.Size(35, 35);
            this.button_Filter.TabIndex = 3;
            this.button_Filter.TabStop = false;
            this.toolTip.SetToolTip(this.button_Filter, "Filter");
            this.button_Filter.UseVisualStyleBackColor = true;
            this.button_Filter.Click += new System.EventHandler(this.Filter_Click);
            // 
            // PictureBox
            // 
            this.PictureBox.BackColor = System.Drawing.Color.Ivory;
            this.PictureBox.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("PictureBox.BackgroundImage")));
            this.PictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.PictureBox.Dock = System.Windows.Forms.DockStyle.Right;
            this.PictureBox.ErrorImage = null;
            this.PictureBox.InitialImage = null;
            this.PictureBox.Location = new System.Drawing.Point(494, 0);
            this.PictureBox.Name = "PictureBox";
            this.PictureBox.Size = new System.Drawing.Size(298, 298);
            this.PictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.PictureBox.TabIndex = 81;
            this.PictureBox.TabStop = false;
            // 
            // panel2
            // 
            this.panel2.Location = new System.Drawing.Point(207, 419);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(565, 159);
            this.panel2.TabIndex = 83;
            // 
            // ProgressBar
            // 
            this.ProgressBar.BackColor = System.Drawing.Color.Ivory;
            this.ProgressBar.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ProgressBar.ForeColor = System.Drawing.Color.PaleGoldenrod;
            this.ProgressBar.Location = new System.Drawing.Point(0, 298);
            this.ProgressBar.Name = "ProgressBar";
            this.ProgressBar.Size = new System.Drawing.Size(792, 15);
            this.ProgressBar.Step = 1;
            this.ProgressBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.ProgressBar.TabIndex = 83;
            // 
            // statusStrip1
            // 
            this.statusStrip1.BackColor = System.Drawing.Color.Ivory;
            this.statusStrip1.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Statusbar});
            this.statusStrip1.Location = new System.Drawing.Point(0, 746);
            this.statusStrip1.Margin = new System.Windows.Forms.Padding(10);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(792, 22);
            this.statusStrip1.TabIndex = 78;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // Statusbar
            // 
            this.Statusbar.Name = "Statusbar";
            this.Statusbar.Size = new System.Drawing.Size(56, 17);
            this.Statusbar.Text = "TagMotion";
            // 
            // closeToolStripMenuItem
            // 
            this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            this.closeToolStripMenuItem.Size = new System.Drawing.Size(32, 19);
            // 
            // closeToolStripMenuItem1
            // 
            this.closeToolStripMenuItem1.Name = "closeToolStripMenuItem1";
            this.closeToolStripMenuItem1.Size = new System.Drawing.Size(32, 19);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(792, 768);
            this.Controls.Add(this.panel_Fill);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TagMotion";
            this.panel_Fill.ResumeLayout(false);
            this.panel_Fill.PerformLayout();
            this.panel_Treeview.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.contextMenu.ResumeLayout(false);
            this.panel_Top.ResumeLayout(false);
            this.panel_Icons.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

		private System.Windows.Forms.Panel panel_Top;
		private System.Windows.Forms.Panel panel_Treeview;
        private System.Windows.Forms.ToolStripMenuItem copyToolStripMenuItem1;
        private System.Windows.Forms.ContextMenuStrip contextMenu;
        private System.Windows.Forms.PictureBox PictureBox;
		private System.Windows.Forms.TreeView TreeView;
		private System.Windows.Forms.StatusStrip statusStrip1;
		private System.Windows.Forms.ToolStripStatusLabel Statusbar;
		private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem1;
		private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
		private System.Windows.Forms.Panel panel_Fill;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.ProgressBar ProgressBar;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PropertyGrid PropertyGrid;
        private System.Windows.Forms.Panel panel_Icons;
        private System.Windows.Forms.Button button_Settings;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.Button button_ReadSourceDirectory;
        private System.Windows.Forms.Button button_SaveCollectionAs;
        private System.Windows.Forms.Button button_Filter;
        private System.Windows.Forms.Button button_Help;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.ToolStripMenuItem AutoTagToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem storeIinTagsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem extractImageToFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem freeDBQueryToolStripMenuItem;
	}
}
