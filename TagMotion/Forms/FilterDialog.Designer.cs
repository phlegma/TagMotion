namespace Chrismo.TagMotion.Forms
{
    partial class FilterDialog
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
            this.Button_OK = new System.Windows.Forms.Button();
            this.label_SourceFolder = new System.Windows.Forms.Label();
            this.textBox_BitrateMin = new System.Windows.Forms.TextBox();
            this.textBox_YearMin = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox_YearMax = new System.Windows.Forms.TextBox();
            this.textBox_BitrateMax = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.Type = new System.Windows.Forms.ComboBox();
            this.textBox_DurationMax = new System.Windows.Forms.TextBox();
            this.textBox_DurationMin = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.checkBox_CopyOnlyFilteredRecords = new System.Windows.Forms.CheckBox();
            this.textBox_Artist = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textBox_Label = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Button_OK
            // 
            this.Button_OK.BackColor = System.Drawing.Color.Ivory;
            this.Button_OK.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.Button_OK.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Button_OK.Location = new System.Drawing.Point(84, 251);
            this.Button_OK.Name = "Button_OK";
            this.Button_OK.Size = new System.Drawing.Size(100, 30);
            this.Button_OK.TabIndex = 80;
            this.Button_OK.Text = "OK";
            this.toolTip.SetToolTip(this.Button_OK, "OK");
            this.Button_OK.UseVisualStyleBackColor = false;
            this.Button_OK.Click += new System.EventHandler(this.Button_OKClick);
            // 
            // label_SourceFolder
            // 
            this.label_SourceFolder.AutoSize = true;
            this.label_SourceFolder.BackColor = System.Drawing.Color.Ivory;
            this.label_SourceFolder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label_SourceFolder.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_SourceFolder.ForeColor = System.Drawing.Color.Black;
            this.label_SourceFolder.Location = new System.Drawing.Point(9, 36);
            this.label_SourceFolder.Name = "label_SourceFolder";
            this.label_SourceFolder.Size = new System.Drawing.Size(45, 15);
            this.label_SourceFolder.TabIndex = 94;
            this.label_SourceFolder.Text = "Bitrate";
            this.label_SourceFolder.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textBox_BitrateMin
            // 
            this.textBox_BitrateMin.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_BitrateMin.ForeColor = System.Drawing.Color.Black;
            this.textBox_BitrateMin.Location = new System.Drawing.Point(82, 34);
            this.textBox_BitrateMin.Name = "textBox_BitrateMin";
            this.textBox_BitrateMin.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.textBox_BitrateMin.Size = new System.Drawing.Size(98, 20);
            this.textBox_BitrateMin.TabIndex = 95;
            this.textBox_BitrateMin.Text = "0";
            this.textBox_BitrateMin.Leave += new System.EventHandler(this.textBox_BitrateMin_Leave);
            // 
            // textBox_YearMin
            // 
            this.textBox_YearMin.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_YearMin.ForeColor = System.Drawing.Color.Black;
            this.textBox_YearMin.Location = new System.Drawing.Point(82, 60);
            this.textBox_YearMin.Name = "textBox_YearMin";
            this.textBox_YearMin.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.textBox_YearMin.Size = new System.Drawing.Size(98, 20);
            this.textBox_YearMin.TabIndex = 97;
            this.textBox_YearMin.Text = "0";
            this.textBox_YearMin.Leave += new System.EventHandler(this.textBox_YearMin_Leave);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Ivory;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label1.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(9, 62);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 15);
            this.label1.TabIndex = 96;
            this.label1.Text = "Year";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textBox_YearMax
            // 
            this.textBox_YearMax.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_YearMax.ForeColor = System.Drawing.Color.Black;
            this.textBox_YearMax.Location = new System.Drawing.Point(186, 60);
            this.textBox_YearMax.Name = "textBox_YearMax";
            this.textBox_YearMax.Size = new System.Drawing.Size(98, 20);
            this.textBox_YearMax.TabIndex = 99;
            this.textBox_YearMax.Text = "2100";
            this.textBox_YearMax.Leave += new System.EventHandler(this.textBox_YearMax_Leave);
            // 
            // textBox_BitrateMax
            // 
            this.textBox_BitrateMax.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_BitrateMax.ForeColor = System.Drawing.Color.Black;
            this.textBox_BitrateMax.Location = new System.Drawing.Point(186, 34);
            this.textBox_BitrateMax.Name = "textBox_BitrateMax";
            this.textBox_BitrateMax.Size = new System.Drawing.Size(98, 20);
            this.textBox_BitrateMax.TabIndex = 98;
            this.textBox_BitrateMax.Text = "1500";
            this.textBox_BitrateMax.Leave += new System.EventHandler(this.textBox_BitrateMax_Leave);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Ivory;
            this.label2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label2.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(9, 114);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 15);
            this.label2.TabIndex = 100;
            this.label2.Text = "Type";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Type
            // 
            this.Type.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Type.FormattingEnabled = true;
            this.Type.Items.AddRange(new object[] {
            "All Types",
            "MPEG Version 1 Audio, Layer 3",
            "MPEG Version 1 Audio, Layer 3 VBR",
            "Flac Audio",
            "Vorbis Version 0 Audio",
            "MPEG-4 Audio (mp4a)"});
            this.Type.Location = new System.Drawing.Point(82, 112);
            this.Type.Name = "Type";
            this.Type.Size = new System.Drawing.Size(202, 22);
            this.Type.TabIndex = 101;
            this.Type.Text = "All Types";
            // 
            // textBox_DurationMax
            // 
            this.textBox_DurationMax.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_DurationMax.ForeColor = System.Drawing.Color.Black;
            this.textBox_DurationMax.Location = new System.Drawing.Point(186, 86);
            this.textBox_DurationMax.Name = "textBox_DurationMax";
            this.textBox_DurationMax.Size = new System.Drawing.Size(98, 20);
            this.textBox_DurationMax.TabIndex = 104;
            this.textBox_DurationMax.Text = "500";
            this.textBox_DurationMax.Leave += new System.EventHandler(this.textBox_DurationMax_Leave);
            // 
            // textBox_DurationMin
            // 
            this.textBox_DurationMin.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_DurationMin.ForeColor = System.Drawing.Color.Black;
            this.textBox_DurationMin.Location = new System.Drawing.Point(82, 86);
            this.textBox_DurationMin.Name = "textBox_DurationMin";
            this.textBox_DurationMin.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.textBox_DurationMin.Size = new System.Drawing.Size(98, 20);
            this.textBox_DurationMin.TabIndex = 103;
            this.textBox_DurationMin.Text = "0";
            this.textBox_DurationMin.Leave += new System.EventHandler(this.textBox_DurationMin_Leave);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Ivory;
            this.label3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label3.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(9, 88);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 15);
            this.label3.TabIndex = 102;
            this.label3.Text = "Duration";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Ivory;
            this.label4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label4.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(161, 18);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(23, 14);
            this.label4.TabIndex = 105;
            this.label4.Text = "Min";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Ivory;
            this.label5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label5.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(183, 18);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(27, 14);
            this.label5.TabIndex = 106;
            this.label5.Text = "Max";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // checkBox_CopyOnlyFilteredRecords
            // 
            this.checkBox_CopyOnlyFilteredRecords.AutoSize = true;
            this.checkBox_CopyOnlyFilteredRecords.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox_CopyOnlyFilteredRecords.Location = new System.Drawing.Point(12, 218);
            this.checkBox_CopyOnlyFilteredRecords.Name = "checkBox_CopyOnlyFilteredRecords";
            this.checkBox_CopyOnlyFilteredRecords.Size = new System.Drawing.Size(158, 18);
            this.checkBox_CopyOnlyFilteredRecords.TabIndex = 107;
            this.checkBox_CopyOnlyFilteredRecords.Text = "Copy Only Filtered Records";
            this.checkBox_CopyOnlyFilteredRecords.UseVisualStyleBackColor = true;
            // 
            // textBox_Artist
            // 
            this.textBox_Artist.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_Artist.ForeColor = System.Drawing.Color.Black;
            this.textBox_Artist.Location = new System.Drawing.Point(82, 140);
            this.textBox_Artist.Name = "textBox_Artist";
            this.textBox_Artist.Size = new System.Drawing.Size(202, 20);
            this.textBox_Artist.TabIndex = 109;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Ivory;
            this.label6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label6.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(9, 142);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(38, 15);
            this.label6.TabIndex = 108;
            this.label6.Text = "Artist";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textBox_Label
            // 
            this.textBox_Label.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_Label.ForeColor = System.Drawing.Color.Black;
            this.textBox_Label.Location = new System.Drawing.Point(82, 166);
            this.textBox_Label.Name = "textBox_Label";
            this.textBox_Label.Size = new System.Drawing.Size(202, 20);
            this.textBox_Label.TabIndex = 111;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Ivory;
            this.label7.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label7.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(9, 168);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(38, 15);
            this.label7.TabIndex = 110;
            this.label7.Text = "Label";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FilterDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Ivory;
            this.ClientSize = new System.Drawing.Size(296, 293);
            this.Controls.Add(this.textBox_Label);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.textBox_Artist);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.checkBox_CopyOnlyFilteredRecords);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBox_DurationMax);
            this.Controls.Add(this.textBox_DurationMin);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.Type);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox_YearMax);
            this.Controls.Add(this.textBox_BitrateMax);
            this.Controls.Add(this.textBox_YearMin);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox_BitrateMin);
            this.Controls.Add(this.label_SourceFolder);
            this.Controls.Add(this.Button_OK);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FilterDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Filter";
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        public System.Windows.Forms.Button Button_OK;
        public System.Windows.Forms.Label label_SourceFolder;
        public System.Windows.Forms.Label label1;
        public System.Windows.Forms.TextBox textBox_BitrateMin;
        public System.Windows.Forms.TextBox textBox_YearMin;
        public System.Windows.Forms.TextBox textBox_YearMax;
        public System.Windows.Forms.TextBox textBox_BitrateMax;
        public System.Windows.Forms.Label label2;
        public System.Windows.Forms.ComboBox Type;
        public System.Windows.Forms.TextBox textBox_DurationMax;
        public System.Windows.Forms.TextBox textBox_DurationMin;
        public System.Windows.Forms.Label label3;
        private System.Windows.Forms.ToolTip toolTip;
        public System.Windows.Forms.Label label4;
        public System.Windows.Forms.Label label5;
        public System.Windows.Forms.CheckBox checkBox_CopyOnlyFilteredRecords;
        public System.Windows.Forms.TextBox textBox_Artist;
        public System.Windows.Forms.Label label6;
        public System.Windows.Forms.TextBox textBox_Label;
        public System.Windows.Forms.Label label7;
	}
}
