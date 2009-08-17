namespace Chrismo.TagMotion.Forms
{
    partial class HelpBox
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.button_OK = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.listBox2 = new System.Windows.Forms.ListBox();
            this.listBox3 = new System.Windows.Forms.ListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.listBox4 = new System.Windows.Forms.ListBox();
            this.label4 = new System.Windows.Forms.Label();
            this.listBox5 = new System.Windows.Forms.ListBox();
            this.label5 = new System.Windows.Forms.Label();
            this.listBox6 = new System.Windows.Forms.ListBox();
            this.label6 = new System.Windows.Forms.Label();
            this.listBox7 = new System.Windows.Forms.ListBox();
            this.label7 = new System.Windows.Forms.Label();
            this.listBox8 = new System.Windows.Forms.ListBox();
            this.label8 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button_OK
            // 
            this.button_OK.BackColor = System.Drawing.Color.Ivory;
            this.button_OK.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.button_OK.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_OK.Location = new System.Drawing.Point(273, 453);
            this.button_OK.Name = "button_OK";
            this.button_OK.Size = new System.Drawing.Size(100, 32);
            this.button_OK.TabIndex = 87;
            this.button_OK.Text = "OK";
            this.button_OK.UseVisualStyleBackColor = false;
            this.button_OK.Click += new System.EventHandler(this.button_OK_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(125, 15);
            this.label1.TabIndex = 91;
            this.label1.Text = "Supported File Types";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 73);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 15);
            this.label2.TabIndex = 92;
            this.label2.Text = "File Structure";
            // 
            // listBox1
            // 
            this.listBox1.BackColor = System.Drawing.Color.Ivory;
            this.listBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listBox1.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 14;
            this.listBox1.Items.AddRange(new object[] {
            "Audio: mp3, flac, ogg, m4a",
            "Image: jpg, jpeg, png, gif"});
            this.listBox1.Location = new System.Drawing.Point(12, 28);
            this.listBox1.Name = "listBox1";
            this.listBox1.SelectionMode = System.Windows.Forms.SelectionMode.None;
            this.listBox1.Size = new System.Drawing.Size(150, 28);
            this.listBox1.TabIndex = 93;
            // 
            // listBox2
            // 
            this.listBox2.BackColor = System.Drawing.Color.Ivory;
            this.listBox2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listBox2.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBox2.FormattingEnabled = true;
            this.listBox2.ItemHeight = 14;
            this.listBox2.Items.AddRange(new object[] {
            "%RECORDARTIST: The Artist of the Record.",
            "                           (e.g. \"Various Artists\" for a compilation)",
            "%REDORDTITLE: The Name of the Record.",
            "%ARTIST: The Name of the artist of the track.",
            "%TITLE: The name of the track.",
            "%TRACK: The number of the track.",
            "%LABEL: The Label where the record was released.",
            "%RELEASE: The catalogue number of the record",
            "%YEAR: The Year when the record was released.",
            "%BITRATE: The Bitrate of the record or track",
            "                 (depending on the File Structure)",
            "%DIR: The Original DirectoryName"});
            this.listBox2.Location = new System.Drawing.Point(12, 92);
            this.listBox2.Name = "listBox2";
            this.listBox2.SelectionMode = System.Windows.Forms.SelectionMode.None;
            this.listBox2.Size = new System.Drawing.Size(283, 168);
            this.listBox2.TabIndex = 94;
            // 
            // listBox3
            // 
            this.listBox3.BackColor = System.Drawing.Color.Ivory;
            this.listBox3.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listBox3.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBox3.FormattingEnabled = true;
            this.listBox3.ItemHeight = 14;
            this.listBox3.Items.AddRange(new object[] {
            "You can drag and drop directories directly into the Treeview.",
            "The directory will be read immidiatly.",
            "The directory is not added to the Source Directory list."});
            this.listBox3.Location = new System.Drawing.Point(12, 295);
            this.listBox3.Name = "listBox3";
            this.listBox3.SelectionMode = System.Windows.Forms.SelectionMode.None;
            this.listBox3.Size = new System.Drawing.Size(312, 42);
            this.listBox3.TabIndex = 96;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 277);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(88, 15);
            this.label3.TabIndex = 95;
            this.label3.Text = "Drag and Drop";
            // 
            // listBox4
            // 
            this.listBox4.BackColor = System.Drawing.Color.Ivory;
            this.listBox4.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listBox4.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBox4.FormattingEnabled = true;
            this.listBox4.ItemHeight = 14;
            this.listBox4.Items.AddRange(new object[] {
            "Changeable properties: Artist, Label, Release, Genre",
            "If you change a property of the Collection, the property",
            "of all the Records in the Collection will be changed.",
            "(So use with care!)"});
            this.listBox4.Location = new System.Drawing.Point(12, 373);
            this.listBox4.Name = "listBox4";
            this.listBox4.SelectionMode = System.Windows.Forms.SelectionMode.None;
            this.listBox4.Size = new System.Drawing.Size(283, 56);
            this.listBox4.TabIndex = 98;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(12, 354);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(126, 15);
            this.label4.TabIndex = 97;
            this.label4.Text = "Collection Properties";
            // 
            // listBox5
            // 
            this.listBox5.BackColor = System.Drawing.Color.Ivory;
            this.listBox5.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listBox5.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBox5.FormattingEnabled = true;
            this.listBox5.ItemHeight = 14;
            this.listBox5.Items.AddRange(new object[] {
            "You can save the Collection as txt, html and xml file.",
            "If you save it as txt-file, the current selected File Structure",
            "defines the structure of the list."});
            this.listBox5.Location = new System.Drawing.Point(330, 28);
            this.listBox5.Name = "listBox5";
            this.listBox5.SelectionMode = System.Windows.Forms.SelectionMode.None;
            this.listBox5.Size = new System.Drawing.Size(305, 42);
            this.listBox5.TabIndex = 100;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(327, 10);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(104, 15);
            this.label5.TabIndex = 99;
            this.label5.Text = "Saving Collection";
            // 
            // listBox6
            // 
            this.listBox6.BackColor = System.Drawing.Color.Ivory;
            this.listBox6.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listBox6.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBox6.FormattingEnabled = true;
            this.listBox6.ItemHeight = 14;
            this.listBox6.Items.AddRange(new object[] {
            "Please note, that if you delete an item from the Treeview,",
            "the selected item (Record, Song or Picture) will be deleted",
            "from disc.",
            "(Note: It will not be moved to the Recycle Bin!)"});
            this.listBox6.Location = new System.Drawing.Point(330, 106);
            this.listBox6.Name = "listBox6";
            this.listBox6.SelectionMode = System.Windows.Forms.SelectionMode.None;
            this.listBox6.Size = new System.Drawing.Size(305, 56);
            this.listBox6.TabIndex = 102;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(327, 87);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(88, 15);
            this.label6.TabIndex = 101;
            this.label6.Text = "Deleting Items";
            // 
            // listBox7
            // 
            this.listBox7.BackColor = System.Drawing.Color.Ivory;
            this.listBox7.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listBox7.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBox7.FormattingEnabled = true;
            this.listBox7.ItemHeight = 14;
            this.listBox7.Items.AddRange(new object[] {
            "Here you can define a range for the Bitrate and the",
            "Release Year of the records in your collection.",
            "It\'s just a filter for the Treeview, no files are deleted."});
            this.listBox7.Location = new System.Drawing.Point(330, 197);
            this.listBox7.Name = "listBox7";
            this.listBox7.SelectionMode = System.Windows.Forms.SelectionMode.None;
            this.listBox7.Size = new System.Drawing.Size(305, 42);
            this.listBox7.TabIndex = 104;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(327, 179);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(35, 15);
            this.label7.TabIndex = 103;
            this.label7.Text = "Filter";
            // 
            // listBox8
            // 
            this.listBox8.BackColor = System.Drawing.Color.Ivory;
            this.listBox8.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listBox8.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBox8.FormattingEnabled = true;
            this.listBox8.ItemHeight = 14;
            this.listBox8.Items.AddRange(new object[] {
            "It does the same as Copy Item, but instead of copying the",
            "Record, Song or Image, only a 0 KB file will be created.",
            "This is much faster then copying, of course.",
            "This function enables you to test File Structures very easily."});
            this.listBox8.Location = new System.Drawing.Point(330, 275);
            this.listBox8.Name = "listBox8";
            this.listBox8.SelectionMode = System.Windows.Forms.SelectionMode.None;
            this.listBox8.Size = new System.Drawing.Size(305, 56);
            this.listBox8.TabIndex = 106;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(327, 256);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(101, 15);
            this.label8.TabIndex = 105;
            this.label8.Text = "Dummy Creation";
            // 
            // HelpBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Ivory;
            this.ClientSize = new System.Drawing.Size(647, 499);
            this.Controls.Add(this.button_OK);
            this.Controls.Add(this.listBox8);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.listBox7);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.listBox6);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.listBox5);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.listBox4);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.listBox3);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.listBox2);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "HelpBox";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Help";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Button button_OK;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.ListBox listBox2;
        private System.Windows.Forms.ListBox listBox3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListBox listBox4;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ListBox listBox5;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ListBox listBox6;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ListBox listBox7;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ListBox listBox8;
        private System.Windows.Forms.Label label8;
    }
}