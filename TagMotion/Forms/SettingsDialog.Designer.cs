namespace Chrismo.TagMotion.Forms
{
	partial class SettingsDialog
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
            this.label_DestinationFolder = new System.Windows.Forms.Label();
            this.label_SourceFolder = new System.Windows.Forms.Label();
            this.label_FileStructure = new System.Windows.Forms.Label();
            this.ComboBox_FileStructure = new System.Windows.Forms.ComboBox();
            this.ComboBox_DestinationDir = new System.Windows.Forms.ComboBox();
            this.ComboBox_SourceDir = new System.Windows.Forms.ComboBox();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.Button_DeleteFileStructure = new System.Windows.Forms.Button();
            this.Button_AddFileStructure = new System.Windows.Forms.Button();
            this.Button_DeleteDestinationDir = new System.Windows.Forms.Button();
            this.Button_DeleteSourceDir = new System.Windows.Forms.Button();
            this.Button_AddDestinationDir = new System.Windows.Forms.Button();
            this.Button_AddSourceDir = new System.Windows.Forms.Button();
            this.Button_OK = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.TextBox_InfoFileTypes = new System.Windows.Forms.TextBox();
            this.comboBox_SortType = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.checkBox_DummyCreation = new System.Windows.Forms.CheckBox();
            this.checkBox_FreeDBQuery = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // label_DestinationFolder
            // 
            this.label_DestinationFolder.AutoSize = true;
            this.label_DestinationFolder.BackColor = System.Drawing.Color.Ivory;
            this.label_DestinationFolder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label_DestinationFolder.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_DestinationFolder.Location = new System.Drawing.Point(9, 79);
            this.label_DestinationFolder.Name = "label_DestinationFolder";
            this.label_DestinationFolder.Size = new System.Drawing.Size(126, 15);
            this.label_DestinationFolder.TabIndex = 55;
            this.label_DestinationFolder.Text = "Destination Directory";
            // 
            // label_SourceFolder
            // 
            this.label_SourceFolder.AutoSize = true;
            this.label_SourceFolder.BackColor = System.Drawing.Color.Ivory;
            this.label_SourceFolder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label_SourceFolder.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_SourceFolder.Location = new System.Drawing.Point(9, 11);
            this.label_SourceFolder.Name = "label_SourceFolder";
            this.label_SourceFolder.Size = new System.Drawing.Size(103, 15);
            this.label_SourceFolder.TabIndex = 54;
            this.label_SourceFolder.Text = "Source Directory";
            // 
            // label_FileStructure
            // 
            this.label_FileStructure.AutoSize = true;
            this.label_FileStructure.BackColor = System.Drawing.Color.Ivory;
            this.label_FileStructure.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label_FileStructure.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_FileStructure.Location = new System.Drawing.Point(9, 147);
            this.label_FileStructure.Name = "label_FileStructure";
            this.label_FileStructure.Size = new System.Drawing.Size(83, 15);
            this.label_FileStructure.TabIndex = 63;
            this.label_FileStructure.Text = "File Structure";
            // 
            // ComboBox_FileStructure
            // 
            this.ComboBox_FileStructure.BackColor = System.Drawing.Color.Ivory;
            this.ComboBox_FileStructure.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboBox_FileStructure.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ComboBox_FileStructure.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ComboBox_FileStructure.ForeColor = System.Drawing.Color.Black;
            this.ComboBox_FileStructure.FormattingEnabled = true;
            this.ComboBox_FileStructure.Location = new System.Drawing.Point(16, 164);
            this.ComboBox_FileStructure.MaxDropDownItems = 50;
            this.ComboBox_FileStructure.Name = "ComboBox_FileStructure";
            this.ComboBox_FileStructure.Size = new System.Drawing.Size(646, 22);
            this.ComboBox_FileStructure.TabIndex = 91;
            // 
            // ComboBox_DestinationDir
            // 
            this.ComboBox_DestinationDir.BackColor = System.Drawing.Color.Ivory;
            this.ComboBox_DestinationDir.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboBox_DestinationDir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ComboBox_DestinationDir.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ComboBox_DestinationDir.ForeColor = System.Drawing.Color.Black;
            this.ComboBox_DestinationDir.FormattingEnabled = true;
            this.ComboBox_DestinationDir.Location = new System.Drawing.Point(16, 96);
            this.ComboBox_DestinationDir.MaxDropDownItems = 50;
            this.ComboBox_DestinationDir.Name = "ComboBox_DestinationDir";
            this.ComboBox_DestinationDir.Size = new System.Drawing.Size(646, 22);
            this.ComboBox_DestinationDir.TabIndex = 92;
            // 
            // ComboBox_SourceDir
            // 
            this.ComboBox_SourceDir.BackColor = System.Drawing.Color.Ivory;
            this.ComboBox_SourceDir.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboBox_SourceDir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ComboBox_SourceDir.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ComboBox_SourceDir.ForeColor = System.Drawing.Color.Black;
            this.ComboBox_SourceDir.FormattingEnabled = true;
            this.ComboBox_SourceDir.Location = new System.Drawing.Point(16, 28);
            this.ComboBox_SourceDir.MaxDropDownItems = 50;
            this.ComboBox_SourceDir.Name = "ComboBox_SourceDir";
            this.ComboBox_SourceDir.Size = new System.Drawing.Size(646, 22);
            this.ComboBox_SourceDir.TabIndex = 93;
            // 
            // Button_DeleteFileStructure
            // 
            this.Button_DeleteFileStructure.BackColor = System.Drawing.Color.Ivory;
            this.Button_DeleteFileStructure.BackgroundImage = global::Chrismo.TagMotion.Properties.Resources.list_remove;
            this.Button_DeleteFileStructure.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.Button_DeleteFileStructure.FlatAppearance.BorderSize = 0;
            this.Button_DeleteFileStructure.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Button_DeleteFileStructure.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Button_DeleteFileStructure.Location = new System.Drawing.Point(627, 191);
            this.Button_DeleteFileStructure.Name = "Button_DeleteFileStructure";
            this.Button_DeleteFileStructure.Size = new System.Drawing.Size(35, 35);
            this.Button_DeleteFileStructure.TabIndex = 90;
            this.toolTip.SetToolTip(this.Button_DeleteFileStructure, "Delete File Structure");
            this.Button_DeleteFileStructure.UseVisualStyleBackColor = false;
            this.Button_DeleteFileStructure.Click += new System.EventHandler(this.Button_DeleteFileStructure_Click);
            // 
            // Button_AddFileStructure
            // 
            this.Button_AddFileStructure.BackColor = System.Drawing.Color.Ivory;
            this.Button_AddFileStructure.BackgroundImage = global::Chrismo.TagMotion.Properties.Resources.list_add;
            this.Button_AddFileStructure.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.Button_AddFileStructure.FlatAppearance.BorderSize = 0;
            this.Button_AddFileStructure.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Button_AddFileStructure.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Button_AddFileStructure.Location = new System.Drawing.Point(586, 191);
            this.Button_AddFileStructure.Name = "Button_AddFileStructure";
            this.Button_AddFileStructure.Size = new System.Drawing.Size(35, 35);
            this.Button_AddFileStructure.TabIndex = 89;
            this.toolTip.SetToolTip(this.Button_AddFileStructure, "Add File Structure");
            this.Button_AddFileStructure.UseVisualStyleBackColor = false;
            this.Button_AddFileStructure.Click += new System.EventHandler(this.Button_AddFileStructure_Click);
            // 
            // Button_DeleteDestinationDir
            // 
            this.Button_DeleteDestinationDir.BackColor = System.Drawing.Color.Ivory;
            this.Button_DeleteDestinationDir.BackgroundImage = global::Chrismo.TagMotion.Properties.Resources.list_remove;
            this.Button_DeleteDestinationDir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.Button_DeleteDestinationDir.FlatAppearance.BorderSize = 0;
            this.Button_DeleteDestinationDir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Button_DeleteDestinationDir.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Button_DeleteDestinationDir.Location = new System.Drawing.Point(627, 123);
            this.Button_DeleteDestinationDir.Name = "Button_DeleteDestinationDir";
            this.Button_DeleteDestinationDir.Size = new System.Drawing.Size(35, 35);
            this.Button_DeleteDestinationDir.TabIndex = 88;
            this.toolTip.SetToolTip(this.Button_DeleteDestinationDir, "Delete Destination Directory");
            this.Button_DeleteDestinationDir.UseVisualStyleBackColor = false;
            this.Button_DeleteDestinationDir.Click += new System.EventHandler(this.Button_DeleteDestinationDir_Click);
            // 
            // Button_DeleteSourceDir
            // 
            this.Button_DeleteSourceDir.BackColor = System.Drawing.Color.Ivory;
            this.Button_DeleteSourceDir.BackgroundImage = global::Chrismo.TagMotion.Properties.Resources.list_remove;
            this.Button_DeleteSourceDir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.Button_DeleteSourceDir.FlatAppearance.BorderSize = 0;
            this.Button_DeleteSourceDir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Button_DeleteSourceDir.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Button_DeleteSourceDir.Location = new System.Drawing.Point(627, 55);
            this.Button_DeleteSourceDir.Name = "Button_DeleteSourceDir";
            this.Button_DeleteSourceDir.Size = new System.Drawing.Size(35, 35);
            this.Button_DeleteSourceDir.TabIndex = 87;
            this.toolTip.SetToolTip(this.Button_DeleteSourceDir, "Delete Source Directory");
            this.Button_DeleteSourceDir.UseVisualStyleBackColor = false;
            this.Button_DeleteSourceDir.Click += new System.EventHandler(this.Button_DeleteSourceDir_Click);
            // 
            // Button_AddDestinationDir
            // 
            this.Button_AddDestinationDir.BackColor = System.Drawing.Color.Ivory;
            this.Button_AddDestinationDir.BackgroundImage = global::Chrismo.TagMotion.Properties.Resources.list_add;
            this.Button_AddDestinationDir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.Button_AddDestinationDir.FlatAppearance.BorderSize = 0;
            this.Button_AddDestinationDir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Button_AddDestinationDir.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Button_AddDestinationDir.Location = new System.Drawing.Point(586, 123);
            this.Button_AddDestinationDir.Name = "Button_AddDestinationDir";
            this.Button_AddDestinationDir.Size = new System.Drawing.Size(35, 35);
            this.Button_AddDestinationDir.TabIndex = 82;
            this.toolTip.SetToolTip(this.Button_AddDestinationDir, "Add Destination Directory");
            this.Button_AddDestinationDir.UseVisualStyleBackColor = false;
            this.Button_AddDestinationDir.Click += new System.EventHandler(this.Button_AddDestinationDir_Click);
            // 
            // Button_AddSourceDir
            // 
            this.Button_AddSourceDir.BackColor = System.Drawing.Color.Ivory;
            this.Button_AddSourceDir.BackgroundImage = global::Chrismo.TagMotion.Properties.Resources.list_add;
            this.Button_AddSourceDir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.Button_AddSourceDir.FlatAppearance.BorderSize = 0;
            this.Button_AddSourceDir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Button_AddSourceDir.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Button_AddSourceDir.Location = new System.Drawing.Point(586, 55);
            this.Button_AddSourceDir.Name = "Button_AddSourceDir";
            this.Button_AddSourceDir.Size = new System.Drawing.Size(35, 35);
            this.Button_AddSourceDir.TabIndex = 81;
            this.toolTip.SetToolTip(this.Button_AddSourceDir, "Add Source Directory");
            this.Button_AddSourceDir.UseVisualStyleBackColor = false;
            this.Button_AddSourceDir.Click += new System.EventHandler(this.Button_AddSourceDir_Click);
            // 
            // Button_OK
            // 
            this.Button_OK.BackColor = System.Drawing.Color.Ivory;
            this.Button_OK.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.Button_OK.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Button_OK.Location = new System.Drawing.Point(283, 417);
            this.Button_OK.Name = "Button_OK";
            this.Button_OK.Size = new System.Drawing.Size(100, 30);
            this.Button_OK.TabIndex = 80;
            this.Button_OK.Text = "OK";
            this.toolTip.SetToolTip(this.Button_OK, "OK");
            this.Button_OK.UseVisualStyleBackColor = false;
            this.Button_OK.Click += new System.EventHandler(this.Button_OKClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Ivory;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label1.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(9, 215);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 15);
            this.label1.TabIndex = 94;
            this.label1.Text = "Info FileTypes";
            // 
            // TextBox_InfoFileTypes
            // 
            this.TextBox_InfoFileTypes.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TextBox_InfoFileTypes.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TextBox_InfoFileTypes.Location = new System.Drawing.Point(12, 232);
            this.TextBox_InfoFileTypes.Name = "TextBox_InfoFileTypes";
            this.TextBox_InfoFileTypes.Size = new System.Drawing.Size(650, 13);
            this.TextBox_InfoFileTypes.TabIndex = 95;
            this.TextBox_InfoFileTypes.Leave += new System.EventHandler(this.TextBox_InfoFileTypes_Leave);
            // 
            // comboBox_SortType
            // 
            this.comboBox_SortType.BackColor = System.Drawing.Color.Ivory;
            this.comboBox_SortType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_SortType.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboBox_SortType.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox_SortType.ForeColor = System.Drawing.Color.Black;
            this.comboBox_SortType.FormattingEnabled = true;
            this.comboBox_SortType.Items.AddRange(new object[] {
            "Path",
            "CreationTime",
            "Artist",
            "Year",
            "Release"});
            this.comboBox_SortType.Location = new System.Drawing.Point(16, 295);
            this.comboBox_SortType.MaxDropDownItems = 50;
            this.comboBox_SortType.Name = "comboBox_SortType";
            this.comboBox_SortType.Size = new System.Drawing.Size(646, 22);
            this.comboBox_SortType.TabIndex = 97;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Ivory;
            this.label2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label2.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(9, 278);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(90, 15);
            this.label2.TabIndex = 96;
            this.label2.Text = "Sort Collection";
            // 
            // checkBox_DummyCreation
            // 
            this.checkBox_DummyCreation.AutoSize = true;
            this.checkBox_DummyCreation.Location = new System.Drawing.Point(12, 345);
            this.checkBox_DummyCreation.Name = "checkBox_DummyCreation";
            this.checkBox_DummyCreation.Size = new System.Drawing.Size(148, 17);
            this.checkBox_DummyCreation.TabIndex = 98;
            this.checkBox_DummyCreation.Text = "Activate Dummy Creation";
            this.checkBox_DummyCreation.UseVisualStyleBackColor = true;
            // 
            // checkBox_FreeDBQuery
            // 
            this.checkBox_FreeDBQuery.AutoSize = true;
            this.checkBox_FreeDBQuery.Location = new System.Drawing.Point(12, 368);
            this.checkBox_FreeDBQuery.Name = "checkBox_FreeDBQuery";
            this.checkBox_FreeDBQuery.Size = new System.Drawing.Size(137, 17);
            this.checkBox_FreeDBQuery.TabIndex = 99;
            this.checkBox_FreeDBQuery.Text = "Activate FreeDB Query";
            this.checkBox_FreeDBQuery.UseVisualStyleBackColor = true;
            // 
            // SettingsDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(674, 459);
            this.Controls.Add(this.checkBox_FreeDBQuery);
            this.Controls.Add(this.checkBox_DummyCreation);
            this.Controls.Add(this.comboBox_SortType);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.TextBox_InfoFileTypes);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ComboBox_SourceDir);
            this.Controls.Add(this.ComboBox_DestinationDir);
            this.Controls.Add(this.ComboBox_FileStructure);
            this.Controls.Add(this.Button_DeleteFileStructure);
            this.Controls.Add(this.Button_AddFileStructure);
            this.Controls.Add(this.Button_DeleteDestinationDir);
            this.Controls.Add(this.Button_DeleteSourceDir);
            this.Controls.Add(this.Button_AddDestinationDir);
            this.Controls.Add(this.Button_AddSourceDir);
            this.Controls.Add(this.Button_OK);
            this.Controls.Add(this.label_DestinationFolder);
            this.Controls.Add(this.label_SourceFolder);
            this.Controls.Add(this.label_FileStructure);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "SettingsDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Settings";
            this.ResumeLayout(false);
            this.PerformLayout();

        }
		public System.Windows.Forms.Button Button_AddDestinationDir;
		public System.Windows.Forms.Button Button_AddSourceDir;
        public System.Windows.Forms.Button Button_OK;
        public System.Windows.Forms.Label label_FileStructure;
		public System.Windows.Forms.Label label_SourceFolder;
        public System.Windows.Forms.Label label_DestinationFolder;
        public System.Windows.Forms.Button Button_DeleteDestinationDir;
        public System.Windows.Forms.Button Button_DeleteSourceDir;
        public System.Windows.Forms.Button Button_DeleteFileStructure;
        public System.Windows.Forms.Button Button_AddFileStructure;
        public System.Windows.Forms.ComboBox ComboBox_FileStructure;
        public System.Windows.Forms.ComboBox ComboBox_DestinationDir;
        public System.Windows.Forms.ComboBox ComboBox_SourceDir;
        private System.Windows.Forms.ToolTip toolTip;
        public System.Windows.Forms.Label label1;
        public System.Windows.Forms.TextBox TextBox_InfoFileTypes;
        public System.Windows.Forms.ComboBox comboBox_SortType;
        public System.Windows.Forms.Label label2;
        public System.Windows.Forms.CheckBox checkBox_DummyCreation;
        public System.Windows.Forms.CheckBox checkBox_FreeDBQuery;
	}
}
